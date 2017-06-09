#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
using System;

namespace Microsoft.Mixer
{
    public enum InteractiveParticipantState
    {
        Joined,

        InputDisabled,

        Left
    }
}
#endif