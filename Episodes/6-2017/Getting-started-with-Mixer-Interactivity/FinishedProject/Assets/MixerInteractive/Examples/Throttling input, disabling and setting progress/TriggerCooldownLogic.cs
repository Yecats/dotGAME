using UnityEngine;

namespace MixerInteractiveExamples
{
    public class TriggerCooldownLogic : MonoBehaviour
    {
        public void TriggerCooldown()
        {
            // Trigger a cooldown for 30 seconds. This will prevent viewers from
            // pressing the button again for 30 seconds.
            // Note: The cooldown time is in milliseconds.
            MixerInteractive.TriggerCooldown("giveHealth", 30000);
        }
    }
}
