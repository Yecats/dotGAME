#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
using System;
using System.Collections.Generic;

namespace Microsoft.Mixer
{
#if !WINDOWS_UWP
    [System.Serializable]
#endif
    public class InteractiveParticipant
    {
        public uint Level
        {
            get;
            private set;
        }

        public uint UserID
        {
            get;
            private set;
        }

        public string UserName
        {
            get;
            private set;
        }

        public DateTime ConnectedAt
        {
            get;
            private set;
        }

        public InteractiveGroup Group
        {
            get
            {
                return new InteractiveGroup("default");
            }
            set
            {
            }
        }

        public DateTime LastInputAt
        {
            get;
            internal set;
        }

        public bool InputDisabled
        {
            get;
            private set;
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

        public InteractiveParticipantState State
        {
            get;
            internal set;
        }
    }
}
#endif