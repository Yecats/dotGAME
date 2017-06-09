using Microsoft.Mixer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MixerInteractiveExamples
{
    public class SetProgressLogic : MonoBehaviour
    {
        public void SetProgress()
        {
            // Get a reference to the button.
            var button = InteractivityManager.SingletonInstance.GetButton("giveHealth");

            // Calling SetProgress, will show a progress indicator on the button. The method takes a value
            // between 0 and 1, where 0 is 0% and 1 is 100%.
            button.SetProgress(0.5f);
        }
    }
}
