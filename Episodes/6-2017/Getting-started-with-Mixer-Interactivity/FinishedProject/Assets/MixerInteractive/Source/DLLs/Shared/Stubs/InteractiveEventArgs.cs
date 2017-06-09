#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
using System;

namespace Microsoft.Mixer
{
    public class InteractiveEventArgs : EventArgs
    {
        public InteractiveEventArgs()
        {
        }

        public DateTime Time
        {
            get;
            private set;
        }

        public int ErrorCode
        {
            get;
            private set;
        }

        public string ErrorMessage
        {
            get;
            private set;
        }

        public InteractiveEventType EventType
        {
            get;
            private set;
        }

        internal InteractiveEventArgs(InteractiveEventType type)
        {
        }

        internal InteractiveEventArgs(InteractiveEventType type, int errorCode, string errorMessage)
        {
        }
    }
}
#endif