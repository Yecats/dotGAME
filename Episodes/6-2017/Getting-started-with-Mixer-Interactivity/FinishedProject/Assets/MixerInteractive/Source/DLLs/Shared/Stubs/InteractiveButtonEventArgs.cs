#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
using System.Collections.Generic;

namespace Microsoft.Mixer
{
    public class InteractiveButtonEventArgs : InteractiveEventArgs
    {
        public string ControlID
        {
            get;
            private set;
        }

        public InteractiveParticipant Participant
        {
            get;
            private set;
        }

        public bool IsPressed
        {
            get;
            private set;
        }

        internal InteractiveButtonEventArgs(InteractiveEventType type, string id, InteractiveParticipant participant, bool isPressed) : base(type)
        {
        }
    }
}
#endif