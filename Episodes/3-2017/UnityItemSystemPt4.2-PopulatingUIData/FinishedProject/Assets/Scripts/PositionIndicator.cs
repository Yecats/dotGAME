using UnityEngine;
using System.Collections;

public class PositionIndicator : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Invoke("DelayDestroy", 3f);
    }

    private void DelayDestroy()
    {
        Destroy(this.gameObject);
    }

}
