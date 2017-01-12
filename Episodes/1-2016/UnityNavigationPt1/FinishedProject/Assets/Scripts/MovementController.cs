using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent navigationMesh;

    // Use this for initialization
    void Start()
    {
        navigationMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
            {
                Move(hit.point);
            }
        }

    }

    private void Move(Vector3 newPosition)
    {
        navigationMesh.SetDestination(newPosition);
    }
}
