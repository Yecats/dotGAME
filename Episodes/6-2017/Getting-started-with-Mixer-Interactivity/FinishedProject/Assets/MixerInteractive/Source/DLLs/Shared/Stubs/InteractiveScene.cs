#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
using System.Collections.Generic;

namespace Microsoft.Mixer
{
#if !WINDOWS_UWP
    [System.Serializable]
#endif
    public class InteractiveScene
    {
        public string SceneID
        {
            get;
            internal set;
        }

        public IList<InteractiveButtonControl> Buttons
        {
            get
            {
                return new List<InteractiveButtonControl>();
            }
        }

        public IList<InteractiveJoystickControl> Joysticks
        {
            get
            {
                return new List<InteractiveJoystickControl>();
            }
        }

        public IList<InteractiveGroup> Groups
        {
            get
            {
                return new List<InteractiveGroup>();
            }
        }

        public InteractiveButtonControl GetButton(string controlID)
        {
            return InteractivityManager.SingletonInstance.GetButton(controlID);
        }

        public InteractiveJoystickControl GetJoystick(string controlID)
        {
            return InteractivityManager.SingletonInstance.GetJoystick(controlID);
        }

        internal string etag;

        internal InteractiveScene(string sceneID = "", string newEtag = "")
        {
            SceneID = sceneID;
            etag = newEtag;
        }
    }
}
#endif