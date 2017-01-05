using UnityEngine;
using System.Collections;

public class TestCases : MonoBehaviour
{

    void Awake()
    {
        Debug.Log("Awake Ran");
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("Start Ran");

    }

    void OnEnable()
    {
        Debug.Log("Enable Ran");

    }

    void OnDisable()
    {
        Debug.Log("Disable Ran");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update Ran");
    }
}
