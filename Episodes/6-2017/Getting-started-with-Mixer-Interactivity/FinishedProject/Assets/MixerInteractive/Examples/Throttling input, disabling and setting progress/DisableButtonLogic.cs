using Microsoft.Mixer;
using UnityEngine;

namespace MixerInteractiveExamples
{
    public class DisableButtonLogic : MonoBehaviour
    {

        public void Start()
        {
            MixerInteractive.GoInteractive();
        }

        public void ToggleDisabled()
        {
            // Get a reference to the button.
            var button = InteractivityManager.SingletonInstance.GetButton("giveHealth");

            // You can check the current Enabled / Disabled state of a button through the Disabled property.
            if (button.Disabled)
            {
                // Call the SetDisabled method with 'false' to enable a button that has been disabled.
                button.SetDisabled(false);
            }
            else
            {
                // Call the SetDisabled method with 'true' to disable a button.
                button.SetDisabled(true);
            }
        }
    }
}
