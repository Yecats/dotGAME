using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Security;
using UnityEngine;
using Microsoft.Mixer;
#if WINDOWS_UWP
using System;
using Windows.Security.Credentials;
using Windows.Security.Authentication.Web.Core;
using System.Threading.Tasks;
#endif

public class MixerInteractive : MonoBehaviour
{
    public bool runInBackground = true;
    public string defaultSceneID;

    // Custom Unity Inspectors are not great at displaying complex objects
    // so we'll store these as seperate variables instead of a List.
    public List<string> groupIDs;
    public List<string> sceneIDs;

    // Events
    public delegate void OnErrorEventHandler(object sender, InteractiveEventArgs e);
    public static event OnErrorEventHandler OnError;

    public delegate void OnGoInteractiveHandler(object sender, InteractiveEventArgs e);
    public static event OnGoInteractiveHandler OnGoInteractive;

    public delegate void OnInteractivityStateChangedHandler(object sender, InteractivityStateChangedEventArgs e);
    public static event OnInteractivityStateChangedHandler OnInteractivityStateChanged;

    public delegate void OnParticipantStateChangedHandler(object sender, InteractiveParticipantStateChangedEventArgs e);
    public static event OnParticipantStateChangedHandler OnParticipantStateChanged;

    public delegate void OnInteractiveButtonEventHandler(object sender, InteractiveButtonEventArgs e);
    public static event OnInteractiveButtonEventHandler OnInteractiveButtonEvent;

    public delegate void OnInteractiveJoystickControlEventHandler(object sender, InteractiveJoystickEventArgs e);
    public static event OnInteractiveJoystickControlEventHandler OnInteractiveJoystickControlEvent;

    private static InteractivityManager interactivityManager;
    private static List<InteractiveEventArgs> queuedEvents;
    private static bool previousRunInBackgroundValue;
    private static MixerInteractiveDialog mixerDialog;
    private static bool pendingGoInteractive;
    private static string outstandingSetDefaultSceneRequest;
    private static List<string> outstandingCreateGroupsRequests;
    private static bool outstandingRequestsCompleted;
    private static float lastCheckForOutstandingRequestsTime;
    private static bool processedSerializedProperties;
    private static bool hasFiredGoInteractiveEvent;
    private static bool shouldCheckForOutstandingRequests;

#if !WINDOWS_UWP
    private static BackgroundWorker backgroundWorker;
#endif

    private const string DEFAULT_GROUP_ID = "default";
    private const float CHECK_FOR_OUTSTANDING_REQUESTS_INTERVAL = 1f;

    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (mixerDialog == null)
        {
            mixerDialog = FindObjectOfType<MixerInteractiveDialog>();
        }
        if (queuedEvents == null)
        {
            queuedEvents = new List<InteractiveEventArgs>();
        }
        // Listen for interactive events
        bool interactivityManagerAlreadyInitialized = false;
        if (interactivityManager == null)
        {
            interactivityManager = InteractivityManager.SingletonInstance;

            interactivityManager.OnError -= HandleError;
            interactivityManager.OnInteractivityStateChanged -= HandleInteractivityStateChanged;
            interactivityManager.OnParticipantStateChanged -= HandleParticipantStateChanged;
            interactivityManager.OnInteractiveButtonEvent -= HandleInteractiveButtonEvent;
            interactivityManager.OnInteractiveJoystickControlEvent -= HandleInteractiveJoystickControlEvent;

            interactivityManager.OnError += HandleError;
            interactivityManager.OnInteractivityStateChanged += HandleInteractivityStateChanged;
            interactivityManager.OnParticipantStateChanged += HandleParticipantStateChanged;
            interactivityManager.OnInteractiveButtonEvent += HandleInteractiveButtonEvent;
            interactivityManager.OnInteractiveJoystickControlEvent += HandleInteractiveJoystickControlEvent;
        }
        else
        {
            interactivityManagerAlreadyInitialized = true;
        }
        MixerInteractiveHelper helper = MixerInteractiveHelper.SingletonInstance;
        helper.runInBackgroundIfInteractive = runInBackground;
        helper.defaultSceneID = defaultSceneID;
        for (int i = 0; i < groupIDs.Count; i++)
        {
            string groupID = groupIDs[i];
            if (groupID != string.Empty &&
                !helper.groupSceneMapping.ContainsKey(groupID))
            {
                helper.groupSceneMapping.Add(groupID, sceneIDs[i]);
            }
        }

        if (outstandingCreateGroupsRequests == null)
        {
            outstandingCreateGroupsRequests = new List<string>();
        }
        outstandingSetDefaultSceneRequest = string.Empty;
        processedSerializedProperties = false;
        outstandingRequestsCompleted = false;
        shouldCheckForOutstandingRequests = false;
        lastCheckForOutstandingRequestsTime = -1;
#if !WINDOWS_UWP
        backgroundWorker = new BackgroundWorker();
#endif
        if (interactivityManagerAlreadyInitialized &&
            InteractivityManager.SingletonInstance.InteractivityState == InteractivityState.InteractivityEnabled)
        {
            ProcessSerializedProperties();
        }
    }

    private static void HandleInteractiveJoystickControlEvent(object sender, InteractiveJoystickEventArgs e)
    {
        queuedEvents.Add(e);
    }

    private static void HandleInteractiveButtonEvent(object sender, InteractiveButtonEventArgs e)
    {
        queuedEvents.Add(e);
    }

    private static void HandleParticipantStateChanged(object sender, InteractiveEventArgs e)
    {
        queuedEvents.Add(e);
    }

    private static void HandleInteractivityStateChanged(object sender, InteractivityStateChangedEventArgs e)
    {
        queuedEvents.Add(e);
    }

    private static void HandleError(object sender, InteractiveEventArgs e)
    {
        queuedEvents.Add(e);
    }

    /// <summary>
    /// Can query the state of the InteractivityManager.
    /// </summary>
    public static InteractivityState InteractivityState
    {
        get
        {
            return InteractivityManager.SingletonInstance.InteractivityState;
        }
    }

    /// <summary>
    /// Gets all the groups associated with the current interactivity instance.
    /// Will be empty if initialization is not complete.
    /// </summary>
    public static IList<InteractiveGroup> Groups
    {
        get
        {
            return InteractivityManager.SingletonInstance.Groups;
        }
    }

    /// <summary>
    /// Gets all the scenes associated with the current interactivity instance.
    /// </summary>
    public static IList<InteractiveScene> Scenes
    {
        get
        {
            return InteractivityManager.SingletonInstance.Scenes;
        }
    }

    /// <summary>
    /// Returns all the participants.
    /// </summary>
    public static IList<InteractiveParticipant> Participants
    {
        get
        {
            return InteractivityManager.SingletonInstance.Participants;
        }
    }

    /// <summary>
    /// Retrieve a list of all of the button controls.
    /// </summary>
    public static IList<InteractiveButtonControl> Buttons
    {
        get
        {
            return InteractivityManager.SingletonInstance.Buttons;
        }
    }

    /// <summary>
    /// Retrieve a list of all of the joystick controls.
    /// </summary>
    public static IList<InteractiveJoystickControl> Joysticks
    {
        get
        {
            return InteractivityManager.SingletonInstance.Joysticks;
        }
    }

    /// <summary>
    /// The string the broadcaster needs to enter in the Mixer website to
    /// authorize the interactive session.
    /// </summary>
    public static string ShortCode
    {
        get
        {
            return InteractivityManager.SingletonInstance.ShortCode;
        }
    }

    /// <summary>
    /// Kicks off a background task to set up the connection to the interactivity service.
    /// </summary>
    /// <returns>true if initialization request was accepted, false if not</returns>
    /// <param name="goInteractive"> If true, initializes and enters interactivity. Defaults to true</param>
    /// <remarks></remarks>
    public static void Initialize(bool goInteractive = true)
    {
        InteractivityManager.SingletonInstance.Initialize(goInteractive);
    }

    /// <summary>
    /// Trigger a cooldown, disabling the specified control for a period of time.
    /// </summary>
    /// <param name="controlID">String ID of the control to disable.</param>
    /// <param name="cooldown">Duration (in milliseconds) required between triggers.</param>
    public static void TriggerCooldown(string controlID, int cooldown)
    {
        InteractivityManager.SingletonInstance.TriggerCooldown(controlID, cooldown);
    }

    /// <summary>
    /// Used by the title to inform the interactivity service that it is ready to recieve interactive input.
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    public static void StartInteractive()
    {
        InteractivityManager.SingletonInstance.StartInteractive();
    }

    /// <summary>
    /// Used by the title to inform the interactivity service that it is no longer receiving interactive input.
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    public static void StopInteractive()
    {
        InteractivityManager.SingletonInstance.StopInteractive();
        pendingGoInteractive = false;
        if (MixerInteractiveHelper.SingletonInstance.runInBackgroundIfInteractive)
        {
            Application.runInBackground = previousRunInBackgroundValue;
        }
    }

    /// <summary>
    /// Manages and maintains proper state updates between the title and the interactivity service.
    /// To ensure best performance, DoWork() must be called frequently, such as once per frame.
    /// Title needs to be thread safe when calling DoWork() since this is when states are changed.
    /// </summary>
    public static void DoWork()
    {
        InteractivityManager.SingletonInstance.DoWork();
    }

    /// <summary>
    /// Frees resources used by the InteractivityManager.
    /// </summary>
    public static void Dispose()
    {
        InteractivityManager interactivityManager = InteractivityManager.SingletonInstance;
        if (interactivityManager != null)
        {
            interactivityManager.OnInteractivityStateChanged -= HandleInteractivityStateChangedInternal;

#if !WINDOWS_UWP
            // Run initialization in another thread.
            backgroundWorker.DoWork -= BackgroundWorkerDoWork;
#endif
        }
        if (queuedEvents != null)
        {
            queuedEvents.Clear();
        }
        previousRunInBackgroundValue = true;
        pendingGoInteractive = false;
        outstandingSetDefaultSceneRequest = string.Empty;
        if (outstandingCreateGroupsRequests != null)
        {
            outstandingCreateGroupsRequests.Clear();
        }
        outstandingRequestsCompleted = false;
        lastCheckForOutstandingRequestsTime = -1;
        processedSerializedProperties = false;
        hasFiredGoInteractiveEvent = false;
        interactivityManager.Dispose();
    }

    private void ResetInternalState()
    {
        previousRunInBackgroundValue = true;
        outstandingSetDefaultSceneRequest = string.Empty;
        if (outstandingCreateGroupsRequests != null)
        {
            outstandingCreateGroupsRequests.Clear();
        }
        outstandingRequestsCompleted = false;
        lastCheckForOutstandingRequestsTime = -1;
        processedSerializedProperties = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (processedSerializedProperties &&
            shouldCheckForOutstandingRequests &&
            !outstandingRequestsCompleted &&
            Time.time - lastCheckForOutstandingRequestsTime > CHECK_FOR_OUTSTANDING_REQUESTS_INTERVAL)
        {
            lastCheckForOutstandingRequestsTime = Time.time;
            outstandingRequestsCompleted = CheckForOutStandingRequestsCompleted();
        }

        InteractivityManager.SingletonInstance.DoWork();

        List<InteractiveEventArgs> processedEvents = new List<InteractiveEventArgs>();
        if (queuedEvents != null)
        {
            // Raise events
            foreach (InteractiveEventArgs interactiveEvent in queuedEvents)
            {
                if (interactiveEvent == null)
                {
                    continue;
                }
                switch (interactiveEvent.EventType)
                {
                    case InteractiveEventType.InteractivityStateChanged:
                        InteractivityStateChangedEventArgs interactivityStateChangedArgs = interactiveEvent as InteractivityStateChangedEventArgs;
                        if (interactivityStateChangedArgs.State == InteractivityState.InteractivityEnabled &&
                            (!shouldCheckForOutstandingRequests || outstandingRequestsCompleted) &&
                            !hasFiredGoInteractiveEvent)
                        {
                            if (OnGoInteractive != null)
                            {
                                hasFiredGoInteractiveEvent = true;
                                OnGoInteractive(this, interactivityStateChangedArgs);
                            }
                        }
                        if (OnInteractivityStateChanged != null)
                        {
                            OnInteractivityStateChanged(this, interactivityStateChangedArgs);
                        }
                        processedEvents.Add(interactiveEvent);
                        break;
                    case InteractiveEventType.ParticipantStateChanged:
                        if (outstandingRequestsCompleted)
                        {
                            if (OnParticipantStateChanged != null)
                            {
                                OnParticipantStateChanged(this, interactiveEvent as InteractiveParticipantStateChangedEventArgs);
                            }
                            processedEvents.Add(interactiveEvent);
                        }
                        break;
                    case InteractiveEventType.Button:
                        if (OnInteractiveButtonEvent != null)
                        {
                            OnInteractiveButtonEvent(this, interactiveEvent as InteractiveButtonEventArgs);
                        }
                        processedEvents.Add(interactiveEvent);
                        break;
                    case InteractiveEventType.Joystick:
                        if (OnInteractiveJoystickControlEvent != null)
                        {
                            OnInteractiveJoystickControlEvent(this, interactiveEvent as InteractiveJoystickEventArgs);
                        }
                        processedEvents.Add(interactiveEvent);
                        break;
                    case InteractiveEventType.Error:
                        if (OnError != null)
                        {
                            OnError(this, interactiveEvent as InteractiveEventArgs);
                        }
                        processedEvents.Add(interactiveEvent);
                        break;
                    default:
                        // Throw exception for unexpected event type.
                        break;
                }
            }
            foreach (InteractiveEventArgs eventArgs in processedEvents)
            {
                queuedEvents.Remove(eventArgs);
            }
        }
        if (InteractivityManager.SingletonInstance.InteractivityState == InteractivityState.InteractivityEnabled &&
            shouldCheckForOutstandingRequests &&
            outstandingRequestsCompleted &&
            !hasFiredGoInteractiveEvent)
        {
            if (OnGoInteractive != null)
            {
                hasFiredGoInteractiveEvent = true;
                OnGoInteractive(this, new InteractiveEventArgs());
            }
        }
    }

    /// <summary>
    /// Returns whether the button with the given control ID is currently down.
    /// </summary>
    /// <param name="controlID">String ID of the control.</param>
    public static bool GetButtonDown(string controlID)
    {
        return InteractivityManager.SingletonInstance.GetButton(controlID).ButtonDown;
    }

    /// <summary>
    /// Returns whether the button with the given control ID is currently pressed.
    /// </summary>
    /// <param name="controlID">String ID of the control.</param>
    public static bool GetButton(string controlID)
    {
        return InteractivityManager.SingletonInstance.GetButton(controlID).ButtonPressed;
    }

    /// <summary>
    /// Returns whether the button with the given control ID is currently up.
    /// </summary>
    /// <param name="controlID">String ID of the control.</param>
    public static bool GetButtonUp(string controlID)
    {
        return InteractivityManager.SingletonInstance.GetButton(controlID).ButtonUp;
    }

    /// <summary>
    /// Returns how many buttons with the given control ID are pressed down.
    /// </summary>
    /// <param name="controlID">String ID of the control.</param>
    public static uint GetCountOfButtonDowns(string controlID)
    {
        return InteractivityManager.SingletonInstance.GetButton(controlID).CountOfButtonDowns;
    }

    /// <summary>
    /// Returns how many buttons with the given control ID are pressed.
    /// </summary>
    /// <param name="controlID">String ID of the control.</param>
    public static uint GetCountOfButtons(string controlID)
    {
        return InteractivityManager.SingletonInstance.GetButton(controlID).CountOfButtonPresses;
    }

    /// <summary>
    /// Returns how many buttons with the given control ID are up.
    /// </summary>
    /// <param name="controlID">String ID of the control.</param>
    public static uint GetCountOfButtonUps(string controlID)
    {
        return InteractivityManager.SingletonInstance.GetButton(controlID).CountOfButtonUps;
    }

    /// <summary>
    /// Returns the joystick with the given control ID.
    /// </summary>
    /// <param name="controlID">String ID of the control.</param>
    public static InteractiveJoystickControl GetJoystick(string controlID)
    {
        return InteractivityManager.SingletonInstance.GetJoystick(controlID);
    }

    /// <summary>
    /// Returns the X coordinate of the joystick with the given control ID.
    /// </summary>
    /// <param name="controlID">String ID of the control.</param>
    public static float GetJoystickX(string controlID)
    {
        return (float)InteractivityManager.SingletonInstance.GetJoystick(controlID).X;
    }

    /// <summary>
    /// Returns the Y coordinate of the joystick with the given control ID.
    /// </summary>
    /// <param name="controlID">String ID of the control.</param>
    public static float GetJoystickY(string controlID)
    {
        return (float)InteractivityManager.SingletonInstance.GetJoystick(controlID).Y;
    }

    /// <summary>
    /// Gets a button control object by ID.
    /// </summary>
    /// <param name="controlID">The ID of the control.</param>
    /// <returns></returns>
    public static InteractiveButtonControl Button(string controlID)
    {
        return InteractivityManager.SingletonInstance.GetButton(controlID);
    }

    /// <summary>
    /// Gets the current scene for the default group.
    /// </summary>
    /// <returns></returns>
    public static string GetCurrentScene()
    {
        return InteractivityManager.SingletonInstance.GetCurrentScene();
    }

    /// <summary>
    /// Sets the current scene for the default group.
    /// </summary>
    /// <param name="sceneID">The ID of the scene to change to.</param>
    public static void SetCurrentScene(string sceneID)
    {
        InteractivityManager.SingletonInstance.SetCurrentScene(sceneID);
    }

    /// <summary>
    /// Returns the specified group. Will return null if initialization
    /// is not yet complete or group does not exist.
    /// </summary>
    /// <param name="groupID">The ID of the group.</param>
    /// <returns></returns>
    public static InteractiveGroup GetGroup(string groupID)
    {
        return InteractivityManager.SingletonInstance.GetGroup(groupID);
    }

    /// <summary>
    /// Returns the specified scene. Will return nullptr if initialization
    /// is not yet complete or scene does not exist.
    /// </summary>
    public static InteractiveScene GetScene(string sceneID)
    {
        return InteractivityManager.SingletonInstance.GetScene(sceneID);
    }

    /// <summary>
    /// Connects to the interactivity service and signals the service that the InteractivityManager is ready to recieve messages.
    /// It also, handles signals authentication events if necessary.
    /// </summary>
    public static void GoInteractive()
    {
        if (pendingGoInteractive)
        {
            return;
        }
        pendingGoInteractive = true;
        // We fire the OnGoInteractive event again even if we are already interactive, because
        // it could have been a scene change and the developer has updated group or scene data
        // in the InteractivityManager prefab.
        hasFiredGoInteractiveEvent = false;
        var interactivityManager = InteractivityManager.SingletonInstance;
        interactivityManager.OnInteractivityStateChanged -= HandleInteractivityStateChangedInternal;
        interactivityManager.OnInteractivityStateChanged += HandleInteractivityStateChangedInternal;

#if !WINDOWS_UWP
        // Run initialization in another thread.
        // Workaround - in certain cases Unity does not call the Start function, which means
        // initialization does not happen. We need to check if the background worker hasn't
        // been initialized and if not, initialize it.
        if (backgroundWorker == null)
        {
            backgroundWorker = new BackgroundWorker();
        }
        backgroundWorker.DoWork -= BackgroundWorkerDoWork;
        backgroundWorker.DoWork += BackgroundWorkerDoWork;
        backgroundWorker.RunWorkerAsync();
#else
        InitializeAsync();
#endif

        if (MixerInteractiveHelper.SingletonInstance.runInBackgroundIfInteractive)
        {
            previousRunInBackgroundValue = Application.runInBackground;
            Application.runInBackground = true;
        }
    }

#if WINDOWS_UWP
    private static async void InitializeAsync()
    {
        await Task.Run(() => {
            InteractivityManager.SingletonInstance.Initialize(true);
        });
    }
#endif

    private static void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
    {
        InteractivityManager.SingletonInstance.Initialize();
    }

    private static void HandleInteractivityStateChangedInternal(object sender, InteractivityStateChangedEventArgs e)
    {
        var state = e.State;
        switch (state)
        {
            case InteractivityState.ShortCodeRequired:
                mixerDialog.Show(InteractivityManager.SingletonInstance.ShortCode);
                break;
            case InteractivityState.InteractivityEnabled:
                mixerDialog.Hide();
                ProcessSerializedProperties();
                pendingGoInteractive = false;
                break;
            default:
                break;
        }
    }

    private static void ProcessSerializedProperties()
    {
        MixerInteractiveHelper helper = MixerInteractiveHelper.SingletonInstance;
        InteractivityManager interactivityManager = InteractivityManager.SingletonInstance;
        string defaultSceneID = helper.defaultSceneID;
        if (helper.groupSceneMapping.Count > 0 ||
            defaultSceneID != string.Empty)
        {
            shouldCheckForOutstandingRequests = true;
        }
        if (helper.groupSceneMapping.Count > 0)
        {
            var groupIDs = helper.groupSceneMapping.Keys;
            foreach (var groupID in groupIDs)
            {
                if (groupID == string.Empty)
                {
                    continue;
                }
                // Supress this warning because calling the contructor
                // triggers the creation of a group.
#pragma warning disable 0219
                InteractiveGroup group;
#pragma warning restore 0219
                string sceneID = helper.groupSceneMapping[groupID];
                if (sceneID != string.Empty)
                {
                    group = new InteractiveGroup(groupID, sceneID);
                }
                else
                {
                    group = new InteractiveGroup(groupID);
                }
                outstandingCreateGroupsRequests.Add(groupID);
            }
            if (defaultSceneID != string.Empty)
            {
                interactivityManager.SetCurrentScene(defaultSceneID);
                outstandingSetDefaultSceneRequest = defaultSceneID;
            }
        }
        processedSerializedProperties = true;
    }

    private static bool CheckForOutStandingRequestsCompleted()
    {
        bool outstandingRequestsCompleted = false;
        List<string> groupsToRemove = new List<string>();
        if (outstandingSetDefaultSceneRequest == string.Empty)
        {
            foreach (string groupID in outstandingCreateGroupsRequests)
            {
                foreach (InteractiveGroup group in InteractivityManager.SingletonInstance.Groups)
                {
                    if (group.GroupID == groupID)
                    {
                        groupsToRemove.Add(groupID);
                    }
                }
            }
            foreach (string groupID in groupsToRemove)
            {
                outstandingCreateGroupsRequests.Remove(groupID);
            }
        }
        else
        {
            foreach (InteractiveGroup group in InteractivityManager.SingletonInstance.Groups)
            {
                if (group.GroupID == DEFAULT_GROUP_ID &&
                    group.SceneID == outstandingSetDefaultSceneRequest)
                {
                    outstandingSetDefaultSceneRequest = string.Empty;
                    break;
                }
            }
        }

        if (outstandingCreateGroupsRequests.Count == 0 &&
            outstandingSetDefaultSceneRequest == string.Empty)
        {
            outstandingRequestsCompleted = true;
        }
        return outstandingRequestsCompleted;
    }

#if WINDOWS_UWP
    private static async Task<string> GetXTokenAsync()
    {
        string token = string.Empty;
        // Get an XToken
        // Find the account provider using the signed in user.
        // We always use the 1st signed in user, because we just need a valid token. It doesn't
        // matter who's it is.
        Windows.System.User currentUser;
        WebTokenRequest request;
        var users = await Windows.System.User.FindAllAsync();
        currentUser = users[0];
        WebAccountProvider xboxProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync("https://xsts.auth.xboxlive.com", "", currentUser);

        // Build the web token request using the account provider.
        // Url = URL of the service we are getting a token for - for example https://apis.mycompany.com/something. 
        // As this is a sample just use xboxlive.com
        // Target & Policy should always be set to "xboxlive.signin" and "DELEGATION"
        // For this call to succeed your console needs to be in the XDKS.1 sandbox
        request = new Windows.Security.Authentication.Web.Core.WebTokenRequest(xboxProvider);
        request.Properties.Add("Url", "https://xboxlive.com");
        request.Properties.Add("Target", "xboxlive.signin");
        request.Properties.Add("Policy", "DELEGATION");

        // Request a token - correct pattern is to call getTokenSilentlyAsync and if that 
        // fails with WebTokenRequestStatus.userInteractionRequired then call requestTokenAsync
        // to get the token and prompt the user if required.
        // getTokenSilentlyAsync can be called on a background thread.
        WebTokenRequestResult tokenResult = await WebAuthenticationCoreManager.GetTokenSilentlyAsync(request);
        //If we got back a token call our service with that token 
        if (tokenResult.ResponseStatus == WebTokenRequestStatus.Success)
        {
            token = tokenResult.ResponseData[0].Token;
        }
        else if (tokenResult.ResponseStatus == WebTokenRequestStatus.UserInteractionRequired)
        { // WebTokenRequestStatus.userInteractionRequired = 3
          // If user interaction is required then call requestTokenAsync instead - this will prompt for user permission if required
          // Note: RequestTokenAsync cannot be called on a background thread.
            WebTokenRequestResult tokenResult2 = await WebAuthenticationCoreManager.RequestTokenAsync(request);
            //If we got back a token call our service with that token 
            if (tokenResult2.ResponseStatus == WebTokenRequestStatus.Success)
            {
                token = tokenResult.ResponseData[0].Token;
            }
            else if (tokenResult2.ResponseStatus == WebTokenRequestStatus.UserCancel)
            { 
                // No-op
            }
        }
        return token;
    }
#endif

    void OnDestroy()
    {
        ResetInternalState();
    }
}