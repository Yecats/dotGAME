#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
using System;

namespace Microsoft.Mixer
{
#if !WINDOWS_UWP
    [System.Serializable]
#endif
    public class InteractiveButtonControl : InteractiveControl
    {
        public string ButtonText
        {
            get;
            private set;
        }

        public uint Cost
        {
            get;
            private set;
        }

        public int RemainingCooldown
        {
            get
            {
                return 0;
            }
        }

        public float Progress
        {
            get;
            private set;
        }

        public bool ButtonDown
        {
            get
            {
                return false;
            }
        }

        public bool ButtonPressed
        {
            get
            {
                return false;
            }
        }

        public bool ButtonUp
        {
            get
            {
                return false;
            }
        }

        public uint CountOfButtonDowns
        {
            get
            {
                return 0;
            }
        }

        public uint CountOfButtonPresses
        {
            get
            {
                return 0;
            }
        }

        public uint CountOfButtonUps
        {
            get
            {
                return 0;
            }
        }

        public void SetProgress(float progress)
        {
        }

        public bool GetButtonDown(uint userID)
        {
            return false;
        }

        public bool GetButtonPressed(uint userID)
        {
            return false;
        }

        public bool GetButtonUp(uint userID)
        {
            return false;
        }

        public uint GetCountOfButtonDowns(uint userID)
        {
            return 0;
        }

        public uint GetCountOfButtonPresses(uint userID)
        {
            return 0;
        }

        public uint GetCountOfButtonUps(uint userID)
        {
            return 0;
        }

        public void TriggerCooldown(int cooldown)
        {
        }

        internal Int64 cooldownExpirationTime;

        public InteractiveButtonControl(string controlID, bool disabled, string helpText, string eTag, string sceneID) : base(controlID, disabled, helpText, eTag, sceneID)
        {
        }
    }
}
#endif