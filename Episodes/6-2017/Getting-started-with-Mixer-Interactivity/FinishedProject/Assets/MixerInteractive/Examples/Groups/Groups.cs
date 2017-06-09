using Microsoft.Mixer;
using UnityEngine;
using UnityEngine.UI;

namespace MixerInteractiveExamples
{
    public class Groups : MonoBehaviour
    {

        public Text group1Text;
        public Text group2Text;
        public Text group3Text;

        // Use this for initialization
        void Start()
        {
            // You can listen for the OnParticipantStateChanged event which will tell you when a participant
            // has joined or left. Participants are people viewing the broadcast.
            MixerInteractive.OnParticipantStateChanged += OnParticipantStateChanged;
            MixerInteractive.GoInteractive();
        }

        private void OnParticipantStateChanged(object sender, InteractiveParticipantStateChangedEventArgs e)
        {
            // Every time a new participant joins randomly assign them to a new group. Groups can
            // be used to show different sets of controls to your audience.
            InteractiveParticipant participant = e.Participant;
            if (participant.State == InteractiveParticipantState.Joined &&
                MixerInteractive.Groups.Count >= 2)
            {
                InteractiveGroup group1 = MixerInteractive.Groups[0];
                InteractiveGroup group2 = MixerInteractive.Groups[1];
                InteractiveGroup group3 = MixerInteractive.Groups[2];

                int group = Mathf.CeilToInt(Random.value * 3);
                if (group == 1)
                {
                    participant.Group = group1;
                    group1Text.text += "\n" + participant.UserName;
                }
                else if (group == 2)
                {
                    participant.Group = group2;
                    group2Text.text += "\n" + participant.UserName;
                }
                else if (group == 3)
                {
                    participant.Group = group3;
                    group3Text.text += "\n" + participant.UserName;
                }
            }
        }
    }
}
