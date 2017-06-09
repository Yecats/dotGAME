using Microsoft.Mixer;
using UnityEngine;
using UnityEngine.UI;

namespace MixerInteractiveExamples
{
    public class ConnectionStatus : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            // Register for OnInteractivityStateChanged to get notified when the
            // InteractivityState property changes.
            MixerInteractive.OnInteractivityStateChanged += OnInteractivityStateChanged;
        }

        private void OnInteractivityStateChanged(object sender, InteractivityStateChangedEventArgs e)
        {
            // When the InteractivityState property is InteractivityEnabled
            // that means your game is fully connected to the Mixer service and able to 
            // recieve interactive input from the audience.
            if (MixerInteractive.InteractivityState == InteractivityState.InteractivityEnabled)
            {
                var connectionStatus = GetComponent<Text>();
                connectionStatus.text = "Success: Connected!";
            }
        }
    }
}
