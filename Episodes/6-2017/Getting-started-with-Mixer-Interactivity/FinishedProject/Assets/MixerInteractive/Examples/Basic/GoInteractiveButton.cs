using UnityEngine;

namespace MixerInteractiveExamples
{
    public class GoInteractiveButton : MonoBehaviour
    {

        public void GoInteractive()
        {
            // The GoInteractive function tells the Mixer SDK to connect to the Mixer service
            // so that you can start recieving interactive events.
            MixerInteractive.GoInteractive();
        }
    }
}
