#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
using System.Collections.Generic;

namespace Microsoft.Mixer
{
    public class InteractivityStateChangedEventArgs : InteractiveEventArgs
    {
        public InteractivityState State
        {
            get;
            private set;
        }

        internal InteractivityStateChangedEventArgs(InteractiveEventType type, InteractivityState state) : base(type)
        {
        }
    }
}
#endif