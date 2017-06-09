using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Microsoft.Mixer;

public class InteractiveSettingsWindow : EditorWindow
{
    private static string appID;
    private static string projectVersionID;
    private static string mockAddcontrolID;
    public static Dictionary<string, Vector2> mockJoystickCoordinates;
    public static Dictionary<string, bool> mockIsIsSceneCurrent;
    private static string mockParticipantJoinUsername;
    private static string mockNewSceneSceneID;
    private static int selectedControlIndex;
    private static int loggingLevelSelectIndex;
    private static bool showAdvancedOptions;
    private static bool mockIsInteractive = false;
    public static Dictionary<string, bool> expandControlDetails;
    private const string CONFIG_FILE_NAME = "interactiveconfig.json";
    private bool shouldSwitchToRunInBackground = false;
    private bool sendMockReadyOnChangeToPlayMode = false;
    LoggingLevel currentLogLevel;
    private Vector2 scrollPos;
    private static bool showApiExplorer;

    // Control indexes
    private static int CONTROL_DROPDOWN_BUTTON_INDEX = 0;
    private static int CONTROL_JOYSTICK_BUTTON_INDEX = 1;

    private static string[] controlOptions;
    private static string[] logLevelOptions;
    private bool existingProjectInformation;

    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    void HandlePlayModeStateChanged()
    {
        if (EditorApplication.isPlaying && sendMockReadyOnChangeToPlayMode)
        {
            sendMockReadyOnChangeToPlayMode = false;
            InteractivityManager.SingletonInstance.OnInteractivityStateChanged += OnInteractivityStateChanged;
        }
    }

    private void OnInteractivityStateChanged(object sender, InteractivityStateChangedEventArgs e)
    {
        if (InteractivityManager.SingletonInstance.InteractivityState == InteractivityState.ShortCodeRequired)
        {
            mockIsInteractive = true;
            MockReady();
            // Add a default participant if there isn't one, otherwise simulated controls won't work.
            if (InteractivityManager.SingletonInstance.Participants.Count == 0)
            {
                MockParticipantJoin("Fake participant 1");
            }
        }
    }

    void Initialize()
    {
        // See if we have existing config data
        existingProjectInformation = TryReadConfigFile();
        if (!existingProjectInformation)
        {
            appID = "";
            projectVersionID = "";
        }

        titleContent = new GUIContent("Interactive Editor");

        mockAddcontrolID = string.Empty;
        mockNewSceneSceneID = InteractivityManager.SingletonInstance.GetCurrentScene();
        mockJoystickCoordinates = new Dictionary<string, Vector2>();
        mockIsIsSceneCurrent = new Dictionary<string, bool>();
        selectedControlIndex = 0;
        showAdvancedOptions = false;
        expandControlDetails = new Dictionary<string, bool>();

        EditorStyles.textArea.wordWrap = true;

        controlOptions = new string[]
           {
                "Button", "Joystick"
           };

        logLevelOptions = new string[]
           {
                "none", "minimal", "verbose"
           };

        InteractivityManager.useMockData = true;
        string loggingLevel = EditorPrefs.GetString("Interactive_LoggingLevel");
        loggingLevelSelectIndex = 0;
        switch (loggingLevel)
        {
            case "none":
                loggingLevelSelectIndex = 0;
                InteractivityManager.SingletonInstance.LoggingLevel = LoggingLevel.None;
                break;
            case "minimal":
                loggingLevelSelectIndex = 1;
                InteractivityManager.SingletonInstance.LoggingLevel = LoggingLevel.Minimal;
                break;
            case "verbose":
                loggingLevelSelectIndex = 2;
                InteractivityManager.SingletonInstance.LoggingLevel = LoggingLevel.Verbose;
                break;
            default:
                loggingLevelSelectIndex = 1;
                InteractivityManager.SingletonInstance.LoggingLevel = LoggingLevel.Minimal;
                break;
        };
        scrollPos = new Vector2();
        EditorApplication.playmodeStateChanged = HandlePlayModeStateChanged;
    }

    void OnGUI()
    {
        if (mockAddcontrolID == null)
        {
            Initialize();
        }

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        EditorGUILayout.BeginVertical();

        // This section is used for notifications
        if (Application.isPlaying &&
            !mockIsInteractive &&
           (InteractivityManager.SingletonInstance.InteractivityState == InteractivityState.InteractivityEnabled) &&
           !Application.runInBackground)
        {
            EditorGUILayout.LabelField("Warning: You may not recieve input from Mixer.", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("This game is currently set to pause when Unity loses focus. If you are using the Mixer website, Unity will be paused. You can fix this by pressing the button below.", MessageType.Info);
            if (GUILayout.Button("Run in background"))
            {
                shouldSwitchToRunInBackground = true;
            }
        }

        // Project information
        EditorGUILayout.LabelField("Project information", EditorStyles.boldLabel);
        appID = EditorGUILayout.TextField("OAuth Client ID", appID);
        projectVersionID = EditorGUILayout.TextField("Version ID", projectVersionID);
        if (appID == string.Empty ||
            projectVersionID == string.Empty)
        {
            EditorGUILayout.HelpBox("Please fill in the project information above. You can find the values for OAuth Client ID and project Version ID by launching the interactive studio.", MessageType.Info);
            if (GUILayout.Button("Get IDs from Interactive Studio"))
            {
                Application.OpenURL("https://mixer.com/i/studio");
            }
            SectionSeperator();
        }
        if (GUILayout.Button("Save project information"))
        {
            if (appID != string.Empty &&
                projectVersionID != string.Empty)
            {
                WriteConfigFile();
                EditorUtility.DisplayDialog("Project information saved successfully", "This Unity game is now associated with your interactive project.", "Close");
            }
            else
            {
                EditorUtility.DisplayDialog("Error: Could not save project information", "The OAuth Client ID and project Version ID cannot be empty.", "Close");
            }
        }

        SectionSeperator();

        if (!Application.isPlaying)
        {
            EditorGUILayout.LabelField("You need to be in play mode and interactive to simulate controls, participants and scenes.", EditorStyles.wordWrappedLabel);
            if (GUILayout.Button("Play and go interactive"))
            {
                sendMockReadyOnChangeToPlayMode = true;
                EditorApplication.isPlaying = true;
                mockIsInteractive = true;
            }
            EditorGUILayout.HelpBox("Note: The button above will only work in the Unity Editor. Outside the editor, your game will need to call the InteractivityManager.StartInteractive() method.", MessageType.Info);
        }
        else if (InteractivityManager.SingletonInstance.InteractivityState != InteractivityState.InteractivityEnabled &&
            !mockIsInteractive)
        {
            EditorGUILayout.LabelField("You must be in interactive mode to simulate controls, participants and scenes. You can fix this by clicking the Go Interactive button below.", EditorStyles.wordWrappedLabel);
            if (GUILayout.Button("Go interactive"))
            {
                mockIsInteractive = true;
                MockReady();
                // Add a default participant if there isn't one, otherwise simulated controls won't work.
                if (InteractivityManager.SingletonInstance.Participants.Count == 0)
                {
                    MockParticipantJoin("Fake participant 1");
                }
            }
            EditorGUILayout.HelpBox("Note: The button above will only work in the Unity Editor. Outside the editor, your game will need to call the InteractivityManager.StartInteractive() method.", MessageType.Info);
        }

        SectionSeperator();

        // Input Simulation
        EditorGUILayout.LabelField("Controls", EditorStyles.boldLabel);
        if (Application.isPlaying &&
            (InteractivityManager.SingletonInstance.InteractivityState == InteractivityState.InteractivityEnabled ||
            mockIsInteractive))
        {
            SectionSeperator();
            EditorGUILayout.LabelField("Add new mock controls by filling out the information and clicking the Add button below.", EditorStyles.wordWrappedLabel);
            EditorGUILayout.BeginHorizontal();
            mockAddcontrolID = EditorGUILayout.TextField(mockAddcontrolID);
            selectedControlIndex = EditorGUILayout.Popup("", selectedControlIndex, controlOptions, GUILayout.Width(96));
            if (GUILayout.Button("Add", GUILayout.Width(64)))
            {
                if (selectedControlIndex == CONTROL_DROPDOWN_BUTTON_INDEX)
                {
                    InteractivityManager.SingletonInstance.Buttons.Add(new InteractiveButtonControl(mockAddcontrolID, true, "", "", ""));
                }
                else if (selectedControlIndex == CONTROL_JOYSTICK_BUTTON_INDEX)
                {
                    InteractivityManager.SingletonInstance.Joysticks.Add(new InteractiveJoystickControl(mockAddcontrolID, true, "", "", ""));
                }
            }
            EditorGUILayout.EndHorizontal();

            List<InteractiveButtonControl> buttons = InteractivityManager.SingletonInstance.Buttons as List<InteractiveButtonControl>;
            List<InteractiveJoystickControl> joysticks = InteractivityManager.SingletonInstance.Joysticks as List<InteractiveJoystickControl>;
            List<InteractiveControl> controls = new List<InteractiveControl>();
            foreach (InteractiveButtonControl button in buttons)
            {
                controls.Add(button);
            }
            foreach (InteractiveJoystickControl joystick in joysticks)
            {
                controls.Add(joystick);
            }
            if (controls != null &&
                controls.Count > 0)
            {
                SectionSeperator();
                EditorGUILayout.LabelField("Controls", EditorStyles.boldLabel);

                EditorGUILayout.BeginVertical();
                for (var i = 0; i < controls.Count; i++)
                {
                    string currentcontrolID = controls[i].ControlID;
                    if (currentcontrolID != null &&
                        controls[i] as InteractiveButtonControl != null)
                    {
                        bool expanded;
                        if (!expandControlDetails.TryGetValue(currentcontrolID, out expanded))
                        {
                            expandControlDetails.Add(currentcontrolID, expanded);
                        }
                        expandControlDetails[currentcontrolID] = EditorGUILayout.Foldout(expandControlDetails[currentcontrolID], currentcontrolID);
                        if (expandControlDetails[currentcontrolID])
                        {
                            EditorGUILayout.BeginHorizontal();
                            if (GUILayout.Button("Press Down"))
                            {
                                string buttonInputMessage = buttonMessageTemplate.Replace("{{controlID}}", currentcontrolID).Replace("{{event}}", "mousedown");
                                InteractivityManager.SingletonInstance.SendMockWebSocketMessage(buttonInputMessage);
                            }
                            if (GUILayout.Button("Press Up"))
                            {
                                string buttonInputMessage = buttonMessageTemplate.Replace("{{controlID}}", currentcontrolID).Replace("{{event}}", "mouseup");
                                InteractivityManager.SingletonInstance.SendMockWebSocketMessage(buttonInputMessage);
                            }
                            if (GUILayout.Button("Remove"))
                            {
                                for (int j = 0; j < InteractivityManager.SingletonInstance.Buttons.Count; j++)
                                {
                                    if (currentcontrolID == InteractivityManager.SingletonInstance.Buttons[j].ControlID)
                                    {
                                        InteractivityManager.SingletonInstance.Buttons.RemoveAt(j);
                                    }
                                }
                            }
                            EditorGUILayout.EndHorizontal();
                        }
                    }
                    else if (controls[i] as InteractiveJoystickControl != null)
                    {
                        EditorGUILayout.BeginVertical();
                        bool expanded;
                        if (!expandControlDetails.TryGetValue(currentcontrolID, out expanded))
                        {
                            expandControlDetails.Add(currentcontrolID, expanded);
                        }
                        expandControlDetails[currentcontrolID] = EditorGUILayout.Foldout(expandControlDetails[currentcontrolID], currentcontrolID);
                        if (expandControlDetails[currentcontrolID])
                        {
                            Vector2 mockCoordinates = new Vector2();
                            if (!mockJoystickCoordinates.TryGetValue(currentcontrolID, out mockCoordinates))
                            {
                                mockJoystickCoordinates.Add(currentcontrolID, mockCoordinates);
                            }
                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField("x", GUILayout.Width(16));
                            mockCoordinates.x = EditorGUILayout.Slider(mockJoystickCoordinates[currentcontrolID].x, -1, 1);
                            EditorGUILayout.EndHorizontal();

                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField("y", GUILayout.Width(16));
                            mockCoordinates.y = EditorGUILayout.Slider(mockJoystickCoordinates[currentcontrolID].y, -1, 1);
                            EditorGUILayout.EndHorizontal();
                            mockJoystickCoordinates[currentcontrolID] = mockCoordinates;
                            if (GUILayout.Button("Remove"))
                            {
                                for (int j = 0; j < InteractivityManager.SingletonInstance.Joysticks.Count; j++)
                                {
                                    if (currentcontrolID == InteractivityManager.SingletonInstance.Joysticks[j].ControlID)
                                    {
                                        InteractivityManager.SingletonInstance.Joysticks.RemoveAt(j);
                                    }
                                }
                            }
                            string joystickInputMessage = joystickMessageTemplate.Replace("{{controlID}}", currentcontrolID)
                                .Replace("{{event}}", "move")
                                .Replace("{{x}}", mockJoystickCoordinates[currentcontrolID].x.ToString())
                                .Replace("{{y}}", mockJoystickCoordinates[currentcontrolID].y.ToString());

                            InteractivityManager.SingletonInstance.SendMockWebSocketMessage(joystickInputMessage);
                        }
                        EditorGUILayout.EndVertical();
                    }
                }
                EditorGUILayout.EndVertical();
            }
        }
        else
        {
            EditorGUILayout.LabelField("You need to be playing and in interactive mode to simulate controls.", EditorStyles.wordWrappedLabel);
        }

        // Participant simulation
        SectionSeperator();
        EditorGUILayout.LabelField("Participants", EditorStyles.boldLabel);
        if (Application.isPlaying &&
            (InteractivityManager.SingletonInstance.InteractivityState == InteractivityState.InteractivityEnabled ||
            mockIsInteractive))
        {
            EditorGUILayout.LabelField("Enter a username and click the Join button to add a participant.", EditorStyles.wordWrappedLabel);
            EditorGUILayout.BeginHorizontal();
            if (mockParticipantJoinUsername == null)
            {
                mockParticipantJoinUsername = "";
            }
            mockParticipantJoinUsername = EditorGUILayout.TextField(mockParticipantJoinUsername);
            if (GUILayout.Button("Join"))
            {
                MockParticipantJoin(mockParticipantJoinUsername);
            }
            EditorGUILayout.EndHorizontal();
            List<InteractiveParticipant> participants = InteractivityManager.SingletonInstance.Participants as List<InteractiveParticipant>;
            if (participants != null)
            {
                if (participants.Count > 0)
                {
                    SectionSeperator();
                    EditorGUILayout.LabelField("Participants", EditorStyles.boldLabel);
                }
                for (var i = 0; i < participants.Count; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(participants[i].UserName);
                    if (GUILayout.Button("Leave"))
                    {
                        MockParticipantLeave(participants[i].UserName);
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
        }
        else
        {
            EditorGUILayout.LabelField("You must be playing and in interactive mode to simulate participants.", EditorStyles.wordWrappedLabel);
        }

        SectionSeperator();

        // Scenes
        EditorGUILayout.LabelField("Change scenes", EditorStyles.boldLabel);
        if (Application.isPlaying &&
            (InteractivityManager.SingletonInstance.InteractivityState == InteractivityState.InteractivityEnabled ||
            mockIsInteractive))
        {
            SectionSeperator();

            EditorGUILayout.LabelField("Enter an ID for the scene, then click the Change button to change to that scene.", EditorStyles.wordWrappedLabel);
            EditorGUILayout.BeginHorizontal();
            if (mockNewSceneSceneID == null)
            {
                mockNewSceneSceneID = string.Empty;
            }
            mockNewSceneSceneID = EditorGUILayout.TextField(mockNewSceneSceneID);
            if (GUILayout.Button("Change"))
            {
                InteractivityManager.SingletonInstance.SetCurrentScene(mockNewSceneSceneID);
            }
            EditorGUILayout.EndHorizontal();
        }
        else
        {
            EditorGUILayout.LabelField("You need to be in play mode and interactive to change scenes.", EditorStyles.wordWrappedLabel);
        }

        SectionSeperator();

        if (InteractivityManager.SingletonInstance.InteractivityState == InteractivityState.InteractivityEnabled)
        {
            SectionSeperator();
            EditorGUILayout.LabelField("Stop Interactive", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Clicking the Stop Interactive button will simulate disconnecting from the Mixer Service.", EditorStyles.wordWrappedLabel);
            if (GUILayout.Button("Stop interactive"))
            {
                mockIsInteractive = false;
                InteractivityManager.SingletonInstance.StopInteractive();
            }
        }

        showAdvancedOptions = EditorGUILayout.Foldout(showAdvancedOptions, "Advanced settings", true, EditorStyles.foldout);
        if (showAdvancedOptions)
        {
            SectionSeperator();

            EditorGUILayout.LabelField("Log level", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Change the amount of informational logging from the Mixer SDK. The output will appear in the Unity Console.", EditorStyles.wordWrappedLabel);
            int oldLogLevelIndex = loggingLevelSelectIndex;
            loggingLevelSelectIndex = EditorGUILayout.Popup("", loggingLevelSelectIndex, logLevelOptions, GUILayout.Width(96));
            if (oldLogLevelIndex != loggingLevelSelectIndex)
            {
                string newLoggingLevel = string.Empty;
                switch (loggingLevelSelectIndex)
                {
                    case 0:
                        newLoggingLevel = "none";
                        InteractivityManager.SingletonInstance.LoggingLevel = LoggingLevel.None;
                        break;
                    case 1:
                        newLoggingLevel = "minimal";
                        InteractivityManager.SingletonInstance.LoggingLevel = LoggingLevel.Minimal;
                        break;
                    case 2:
                        newLoggingLevel = "verbose";
                        InteractivityManager.SingletonInstance.LoggingLevel = LoggingLevel.Verbose;
                        break;
                    default:
                        break;
                }
                EditorPrefs.SetString("Mixer_LoggingLevel", newLoggingLevel);
            }

            RenderApiExplorer();
        }

        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
    }

    void Update()
    {
        if (shouldSwitchToRunInBackground)
        {
            Application.runInBackground = true;
        }
    }

    private void SectionSeperator()
    {
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
    }

    private bool TryReadConfigFile()
    {
        var readSucceeded = false;
        string fullPathToConfigFile = Application.streamingAssetsPath + "/" + CONFIG_FILE_NAME;
        if (File.Exists(fullPathToConfigFile))
        {
            string configText = File.ReadAllText(fullPathToConfigFile);
            try
            {
                using (StringReader stringReader = new StringReader(configText))
                using (JsonTextReader jsonReader = new JsonTextReader(stringReader))
                {
                    while (jsonReader.Read())
                    {
                        if (jsonReader.Value != null)
                        {
                            string key = jsonReader.Value.ToString();
                            string lowercaseKey = key.ToLowerInvariant();
                            switch (lowercaseKey)
                            {
                                case "appid":
                                    jsonReader.Read();
                                    if (jsonReader.Value != null)
                                    {
                                        appID = jsonReader.Value.ToString();
                                    }
                                    break;
                                case "projectversionid":
                                    jsonReader.Read();
                                    if (jsonReader.Value != null)
                                    {
                                        projectVersionID = jsonReader.Value.ToString();
                                    }
                                    break;
                                default:
                                    // No-op. We don't throw an error because the SDK only implements a
                                    // subset of the total possible server messages so we expect to see
                                    // method messages that we don't know how to handle.
                                    break;
                            }
                        }
                    }
                }
                if (appID != string.Empty &&
                    projectVersionID != string.Empty)
                {
                    readSucceeded = true;
                }
            }
            catch
            {
                Debug.Log("Error: mixerconfig.json file could not be read. Make sure it is valid JSON and has the correct format.");
            }
        }
        return readSucceeded;
    }

    private void WriteConfigFile()
    {
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        string fullPathToConfigFile = Application.streamingAssetsPath + "/" + CONFIG_FILE_NAME;
        File.WriteAllText(fullPathToConfigFile, "{ \"AppID\": \"" + appID + "\", \"ProjectVersionID\":  \"" + projectVersionID + "\"}");
    }

    private void MockReady()
    {
        InteractivityManager.SingletonInstance.SendMockWebSocketMessage(readyMessage);
        InteractivityManager.SingletonInstance.DoWork();
    }

    private void MockParticipantJoin(string userID)
    {
        var participantJoinMessage = participantJoinMessageTemplate.Replace("{{UserName}}", userID);
        InteractivityManager.SingletonInstance.SendMockWebSocketMessage(participantJoinMessage);
        InteractivityManager.SingletonInstance.DoWork();
    }

    private void MockParticipantLeave(string userID)
    {
        var participantLeaveMessage = participantLeaveMessageTemplate.Replace("{{UserName}}", userID);
        InteractivityManager.SingletonInstance.SendMockWebSocketMessage(participantLeaveMessage);
        InteractivityManager.SingletonInstance.DoWork();
    }

    // API Explorer
    private Dictionary<string, bool> apiExpandGroupDetails;
    private void RenderApiExplorer()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        SectionSeperator();
        showApiExplorer = EditorGUILayout.Foldout(showApiExplorer, "API Explorer", true, EditorStyles.foldout);
        if (!showApiExplorer)
        {
            return;
        }
        else
        {
            // Groups
            EditorGUILayout.LabelField("Mixer.Groups", EditorStyles.boldLabel);
            foreach (InteractiveGroup group in MixerInteractive.Groups)
            {
                bool expanded;
                var currentGroupID = group.GroupID;
                if (!apiExpandGroupDetails.TryGetValue(currentGroupID, out expanded))
                {
                    apiExpandGroupDetails.Add(currentGroupID, expanded);
                }
                apiExpandGroupDetails[currentGroupID] = EditorGUILayout.Foldout(apiExpandGroupDetails[currentGroupID], currentGroupID);
                if (apiExpandGroupDetails[currentGroupID])
                {
                    EditorGUILayout.LabelField("GroupID: " + group.GroupID);
                    EditorGUILayout.LabelField("SceneID: " + group.SceneID);
                }
            }

            // Scenes

            // Participants

            // Buttons

            // Joysticks
        }
    }

    // Helper classes
    const string readyMessage =
    "{" +
    "  \"type\": \"method\"," +
    "  \"id\": 123," +
    "  \"method\": \"onReady\"," +
    "  \"discard\": true," +
    "  \"params\": {" +
    "    \"isReady\": true" +
    "  }" +
    "}";

    const string buttonMessageTemplate =
        "{" +
        "  \"type\": \"method\"," +
        "  \"id\": 123," +
        "  \"method\": \"giveInput\"," +
        "  \"discard\": true," +
        "  \"params\": {" +
        "    \"participantID\": \"efe5e1d6-a870-4f77-b7e4-1cfaf30b097e\"" +
        "  }," +
        "  \"input\": [" +
        "    {" +
        "      \"control\": {" +
        "        \"controlID\": \"{{controlID}}\"," +
        "        \"kind\": \"button\"" +
        "      }," +
        "      \"event\": \"{{event}}\"," +
        "      \"button\": 0," +
        "      \"transaction\": {" +
        "        \"transactionID\": 501203," +
        "        \"cost\": 100" +
        "      }" +
        "    }" +
        "  ]" +
        "}";

    const string joystickMessageTemplate =
    "{" +
    "  \"type\": \"method\"," +
    "  \"id\": 123," +
    "  \"method\": \"giveInput\"," +
    "  \"discard\": true," +
    "  \"params\": {" +
    "    \"participantID\": \"efe5e1d6-a870-4f77-b7e4-1cfaf30b097e\"" +
    "  }," +
    "  \"input\": [" +
    "    {" +
    "      \"control\": {" +
    "        \"controlID\": \"{{controlID}}\"," +
    "        \"kind\": \"joystick\"" +
    "      }," +
    "      \"event\": \"{{event}}\"," +
    "      \"x\": {{x}}," +
    "      \"y\": {{y}}" +
    "    }" +
    "  ]" +
    "}";

    const string participantJoinMessageTemplate =
    "{" +
    "  \"type\": \"method\"," +
    "  \"id\": 123," +
    "  \"method\": \"onParticipantJoin\"," +
    "  \"params\": {" +
    "    \"participants\": [" +
    "            {" +
    "            \"sessionID\": \"efe5e1d6-a870-4f77-b7e4-1cfaf30b097e\"," +
    "            \"etag\": \"54600913\"," +
    "            \"userID\": 146," +
    "            \"username\": \"{{UserName}}\"," +
    "            \"level\": 67," +
    "            \"lastInputAt\": 1484763854277," +
    "            \"connectedAt\": 1484763846242," +
    "            \"disabled\": false," +
    "            \"groupID\": \"default\"" +
    "            }" +
    "        ]" +
    "    }," +
    "  \"discard\": true" +
    "}";

    const string participantLeaveMessageTemplate =
    "{" +
    "  \"type\": \"method\"," +
    "  \"id\": 123," +
    "  \"method\": \"onParticipantLeave\"," +
    "  \"params\": {" +
    "    \"participants\": [" +
    "            {" +
    "            \"sessionID\": \"efe5e1d6-a870-4f77-b7e4-1cfaf30b097e\"," +
    "            \"etag\": \"54600913\"," +
    "            \"userID\": 146," +
    "            \"username\": \"{{UserName}}\"," +
    "            \"level\": 67," +
    "            \"lastInputAt\": 1484763854277," +
    "            \"connectedAt\": 1484763846242," +
    "            \"disabled\": false," +
    "            \"groupID\": \"default\"" +
    "            }" +
    "        ]" +
    "    }," +
    "  \"discard\": true" +
    "}";
}