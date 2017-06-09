using Microsoft;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MixerInteractive))]
[CanEditMultipleObjects]
public class InteractivityManagerEditor : Editor
{
    private SerializedProperty runInBackground;
    private SerializedProperty defaultSceneID;

    // Unity doesn't serialize dictionaries very well, so instead we use 2 lists.
    public SerializedProperty groupIDs;
    public SerializedProperty sceneIDs;

    //private int numberOfGroups;
    private List<string> groupIDStrings;
    private List<string> sceneIDStrings;

    private const string GROUP_ID_KEY = "mixer-interactive-group-id-";

    void OnEnable()
    {
        if (groupIDStrings == null)
        {
            groupIDStrings = new List<string>();
        }
        if (sceneIDStrings == null)
        {
            sceneIDStrings = new List<string>();
        }

        runInBackground = serializedObject.FindProperty("runInBackground");
        defaultSceneID = serializedObject.FindProperty("defaultSceneID");

        groupIDs = serializedObject.FindProperty("groupIDs");
        sceneIDs = serializedObject.FindProperty("sceneIDs");

        groupIDStrings.Clear();
        for (int i = 0; i < groupIDs.arraySize; i++)
        {
            groupIDStrings.Add(groupIDs.GetArrayElementAtIndex(i).stringValue);
        }
        sceneIDStrings.Clear();
        for (int i = 0; i < sceneIDs.arraySize; i++)
        {
            sceneIDStrings.Add(sceneIDs.GetArrayElementAtIndex(i).stringValue);
        }
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SectionSeperator();

        EditorGUILayout.LabelField("Run in background", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Allow this game to run in the background even if the window does not have focus.");
        EditorGUILayout.PropertyField(runInBackground);
        EditorGUILayout.HelpBox("Unity will pause the game by default if the window does not have focus. This means if you are using the Mixer website, Unity will be paused. To allow your game to run while you use the Mixer website for testing, check the Run In Background checkbox.", MessageType.Info);

        SectionSeperator();

        EditorGUILayout.LabelField("Scenes", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Specify the scene you want your audience to see.");
        if (defaultSceneID.stringValue == string.Empty)
        {
            defaultSceneID.stringValue = DEFAULT_SCENE;
        }
        EditorGUILayout.PropertyField(defaultSceneID);
        EditorGUILayout.HelpBox("If you have more than one Mixer scene, you can specify which scene the InteractivityManager will show. All projects have a default scene, called \"default\".", MessageType.Info);

        SectionSeperator();

        EditorGUILayout.LabelField("Groups", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Create new groups and specify which scene to show the group. Groups allow you to show different controls to different segments of the audience.", EditorStyles.wordWrappedLabel);

        // HACKHACK - render 1st group control
        // Always render at least one group
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Group ID");
        EditorGUILayout.LabelField("Scene ID");
        EditorGUILayout.EndHorizontal();

        if (groupIDStrings.Count == 0)
        {
            EditorGUILayout.BeginHorizontal();
            string newGroupIDValue = string.Empty;
            newGroupIDValue = EditorGUILayout.TextField(newGroupIDValue);

            string newSceneIDValue = string.Empty;
            newSceneIDValue = EditorGUILayout.TextField(defaultSceneID.stringValue);
            if (newSceneIDValue == string.Empty)
            {
                newSceneIDValue = defaultSceneID.stringValue;
            }
            if (newGroupIDValue != string.Empty &&
                newSceneIDValue != string.Empty)
            {
                groupIDStrings.Add(newGroupIDValue);
                sceneIDStrings.Add(newSceneIDValue);
            }
            if (GUILayout.Button("Remove", GUILayout.Width(64)) &&
                newGroupIDValue != string.Empty &&
                newSceneIDValue != string.Empty)
            {
                groupIDStrings.Remove(newGroupIDValue);
                sceneIDStrings.Remove(newSceneIDValue);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();

            string newGroupIDValue2 = string.Empty;
            newGroupIDValue2 = EditorGUILayout.TextField(newGroupIDValue2);

            string newSceneIDValue2 = string.Empty;
            newSceneIDValue2 = EditorGUILayout.TextField(defaultSceneID.stringValue);
            if (newGroupIDValue2 != string.Empty &&
                newSceneIDValue2 != string.Empty)
            {
                groupIDStrings.Add(newGroupIDValue2);
                sceneIDStrings.Add(newSceneIDValue2);
            }
            if (GUILayout.Button("Remove", GUILayout.Width(64)) &&
                newGroupIDValue2 != string.Empty &&
                newSceneIDValue2 != string.Empty)
            {
                groupIDStrings.Remove(newGroupIDValue2);
                sceneIDStrings.Remove(newSceneIDValue2);
            }
            EditorGUILayout.EndHorizontal();
        }
        else if (groupIDStrings.Count == 1)
        {
            EditorGUILayout.BeginHorizontal();
            string groupID1 = groupIDStrings[0];
            string sceneID1 = sceneIDStrings[0];
            string newGroupIDValue = string.Empty;
            newGroupIDValue = EditorGUILayout.TextField(groupID1);

            string newSceneIDValue = string.Empty;
            newSceneIDValue = EditorGUILayout.TextField(sceneID1);
            if (newSceneIDValue == string.Empty)
            {
                newSceneIDValue = defaultSceneID.stringValue;
            }
            if (newGroupIDValue != string.Empty &&
                newSceneIDValue != string.Empty)
            {
                groupIDStrings[0] = newGroupIDValue;
                sceneIDStrings[0] = newSceneIDValue;
            }
            if (GUILayout.Button("Remove", GUILayout.Width(64)) &&
                sceneIDStrings[0] != string.Empty &&
                sceneIDStrings[0] != string.Empty)
            {
                groupIDStrings.Remove(groupIDStrings[0]);
                sceneIDStrings.Remove(sceneIDStrings[0]);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            string newGroupIDValue2 = string.Empty;
            newGroupIDValue2 = EditorGUILayout.TextField(newGroupIDValue2);

            string newSceneIDValue2 = string.Empty;
            newSceneIDValue2 = EditorGUILayout.TextField(defaultSceneID.stringValue);
            if (newSceneIDValue2 == string.Empty)
            {
                newSceneIDValue2 = defaultSceneID.stringValue;
            }

            if (newGroupIDValue2 != string.Empty &&
                newSceneIDValue2 != string.Empty)
            {
                groupIDStrings.Add(newGroupIDValue2);
                sceneIDStrings.Add(newSceneIDValue2);
            }
            if (GUILayout.Button("Remove", GUILayout.Width(64)) &&
                newGroupIDValue2 != string.Empty &&
                newSceneIDValue2 != string.Empty)
            {
                groupIDStrings.Remove(newGroupIDValue2);
                sceneIDStrings.Remove(newSceneIDValue2);
            }
            EditorGUILayout.EndHorizontal();
        }
        else
        {
            for (int i = 0; i < groupIDStrings.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                string groupID = groupIDStrings[i];
                string sceneID = sceneIDStrings[i];
                string newGroupIDValue = string.Empty;
                newGroupIDValue = EditorGUILayout.TextField(groupID);

                string newSceneIDValue = string.Empty;
                newSceneIDValue = EditorGUILayout.TextField(sceneID);
                if (newSceneIDValue == string.Empty)
                {
                    newSceneIDValue = defaultSceneID.stringValue;
                }
                if (newGroupIDValue != string.Empty &&
                    newSceneIDValue != string.Empty)
                {
                    groupIDStrings[i] = newGroupIDValue;
                    sceneIDStrings[i] = newSceneIDValue;
                }
                if (GUILayout.Button("Remove", GUILayout.Width(64)) &&
                    newGroupIDValue != string.Empty &&
                    newSceneIDValue != string.Empty)
                {
                    groupIDStrings.Remove(groupIDStrings[i]);
                    sceneIDStrings.Remove(sceneIDStrings[i]);
                }
                EditorGUILayout.EndHorizontal();
            }
        }

        if (GUILayout.Button("Add", GUILayout.Width(64)))
        {
            groupIDStrings.Add(string.Empty);
            sceneIDStrings.Add(defaultSceneID.stringValue);
        }

        SectionSeperator();

        groupIDs.ClearArray();
        for (int i = 0; i < groupIDStrings.Count; i++)
        {
            groupIDs.InsertArrayElementAtIndex(i);
            groupIDs.GetArrayElementAtIndex(i).stringValue = groupIDStrings[i];
        }
        sceneIDs.ClearArray();
        for (int i = 0; i < sceneIDStrings.Count; i++)
        {
            sceneIDs.InsertArrayElementAtIndex(i);
            sceneIDs.GetArrayElementAtIndex(i).stringValue = sceneIDStrings[i];
        }
        serializedObject.ApplyModifiedProperties();
    }

    private void SectionSeperator()
    {
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
    }

    private const string DEFAULT_SCENE = "default";
}
