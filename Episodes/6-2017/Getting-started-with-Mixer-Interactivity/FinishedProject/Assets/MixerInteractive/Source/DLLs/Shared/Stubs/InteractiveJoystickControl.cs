#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
using System.Collections.Generic;

namespace Microsoft.Mixer
{
#if !WINDOWS_UWP
    [System.Serializable]
#endif
    public class InteractiveJoystickControl : InteractiveControl
    {
        public double X
        {
            get
            {
                return 0;
            }
        }

        public double Y
        {
            get
            {
                return 0;
            }
        }

        public double Intensity
        {
            get;
            private set;
        }

        public double GetX(uint userID)
        {
            return 0;
        }

        public double GetY(uint userID)
        {
            return 0;
        }

        public InteractiveJoystickControl(string controlID, bool enabled, string helpText, string eTag, string sceneID) : base(controlID, enabled, helpText, eTag, sceneID)
        {
        }

        internal uint UserID;
    }
}
#endif