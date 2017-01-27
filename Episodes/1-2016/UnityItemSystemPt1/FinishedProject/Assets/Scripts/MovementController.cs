using UnityEngine;
using System.Collections;
using Assets.Scripts.NPC;

public class MovementController : MonoBehaviour
{
    public GameObject PositionIndicator;
    private UnityEngine.AI.NavMeshAgent navigationMesh;
    int layerMask = 1 << 9 | 1 << 8;

    bool isMovingAndNeedsRotation;
    Transform npcToView;

    // Use this for initialization
    void Start()
    {
        navigationMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, layerMask))
            {
                Debug.Log(hit.transform.gameObject.layer);
                
                //If we've clicked specifically on the ground layer
                if (hit.transform.gameObject.layer == 8)
                {
                    GameObject.Instantiate(PositionIndicator, new Vector3(hit.point.x, 0.1f, hit.point.z), Quaternion.Euler(-90f, 0, 0));
                    Move(hit.point);
                }
                //we've clicked on an NPC
                else
                {
                    npcToView = hit.transform;

                    Move(hit.transform.position + (transform.forward * -6));
                    isMovingAndNeedsRotation = true;

                    Debug.Log("Clicked on the merchant.");

                }
            }
        }

        //NOTE: This was changed from the video as I realized the NavMesh agent was fighting the rotation. 
        //      The distance check that I was doing was incorrect and needed to take into consideration the Navigation system.
        //      I was also missing telling the navigation system to stop / resume.
        if (isMovingAndNeedsRotation && Vector3.Distance(navigationMesh.destination, transform.position) <= navigationMesh.stoppingDistance)
        {
            if (!navigationMesh.hasPath)
            {
                navigationMesh.Stop();
                RotateTowards(2f);
            }
        }

    }

    /// <summary>
    /// Move the player by providing a new destination to the Navigation system and resuming it.
    /// </summary>
    /// <param name="newPosition"></param>
    private void Move(Vector3 newPosition)
    {
        navigationMesh.SetDestination(newPosition);
        navigationMesh.Resume();
    }

    /// <summary>
    /// Rotate towards a specific object, in this case the NPC Transform. 
    /// </summary>
    /// <param name="speed">Speed in which to rotate</param>
    private void RotateTowards(float speed)
    {
        Vector3 direction = (npcToView.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);

        if (Quaternion.Angle(transform.rotation, lookRotation) < 1)
        {
            Debug.Log("rotation set to false");
            isMovingAndNeedsRotation = false;
        }

    }
}
