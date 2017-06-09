using UnityEngine;

namespace MixerInteractiveExamples
{
    public class Move : MonoBehaviour
    {

        public float speed;

        // Use this for initialization
        void Start()
        {
            // Call GoInteractive to connect to the Mixer service so you can start
            // recieving input.
            MixerInteractive.GoInteractive();
        }

        // Update is called once per frame
        void Update()
        {
            // Respond to joystick input from the viewer by calling GetJoystickX and GetJoystickY
            // and moving the player.
            if (MixerInteractive.GetJoystickX("move") < 0)
            {
                transform.position += new Vector3(-1 * speed, 0, 0);
            }
            else if (MixerInteractive.GetJoystickX("move") > 0)
            {
                transform.position += new Vector3(speed, 0, 0);
            }
            if (MixerInteractive.GetJoystickY("move") < 0)
            {
                transform.position += new Vector3(0, -1 * speed, 0);
            }
            else if (MixerInteractive.GetJoystickY("move") > 0)
            {
                transform.position += new Vector3(0, speed, 0);
            }
        }
    }
}
