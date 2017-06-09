using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MixerInteractive.GoInteractive();
	}
	
	// Update is called once per frame
	void Update () {
        if (MixerInteractive.GetJoystickX("move") > 0)
        {
            transform.position += new Vector3(0.2f, 0, 0);
        }
        else if (MixerInteractive.GetJoystickX("move") < 0)
        {
            transform.position -= new Vector3(0.2f, 0, 0);

        }
        if (MixerInteractive.GetButton("grow"))
        {
            transform.localScale *= 1.2f;
        }
    }
}
