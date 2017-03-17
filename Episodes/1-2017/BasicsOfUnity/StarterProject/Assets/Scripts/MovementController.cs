using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public GameObject positionIndicator;
    private NavMeshAgent navigationMesh;

	// Use this for initialization
	void Start () {
        navigationMesh = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
            {
                GameObject.Instantiate(positionIndicator, new Vector3(hit.point.x, .1f, hit.point.z), Quaternion.Euler(-90f, 0, 0));
                Move(hit.point);
            }
        }
	}

    private void Move(Vector3 newPosition)
    {
        navigationMesh.SetDestination(newPosition);
    }
}
