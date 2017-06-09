#if !UNITY_EDITOR_WIN && !UNITY_STANDALONE_WIN && !UNITY_WSA_10_0 && !UNITY_XBOXONE
namespace Microsoft.Mixer
{
    public class ParticipantLeaveEventArgs : InteractiveEventArgs
    {
        public InteractiveParticipant Participant
        {
            get;
            private set;
        }

        internal ParticipantLeaveEventArgs(InteractiveParticipant participant)
        {
        }
    }
}
#endif