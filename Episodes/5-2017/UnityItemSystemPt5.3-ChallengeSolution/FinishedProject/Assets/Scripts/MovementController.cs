using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using Assets.Scripts.NPC;

public class MovementController : MonoBehaviour
{
    public GameObject PositionIndicator;
    public bool IsMoving;
    public bool IsMovementLocked = false;

    private Transform _npcToView;
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    private int _layerMask = 1 << 9 | 1 << 8;
    [SerializeField]
    private bool _needsRotation;

    // Use this for initialization
    void Start()
    {
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsMovementLocked && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, _layerMask))
            {
                
                //If we've clicked specifically on the ground layer
                if (hit.transform.gameObject.layer == 8)
                {
                    Instantiate(PositionIndicator, new Vector3(hit.point.x, 0.1f, hit.point.z), Quaternion.Euler(-90f, 0, 0));
                    Move(hit.point);
                    _needsRotation = false;

                    if (_npcToView != null && _npcToView.transform.tag.Equals("Merchant"))
                    {
                        _npcToView.transform.GetComponent<MerchantInteraction>().StopStoreUICoroutine();
                    }
                }
                //we've clicked on an NPC
                else
                {
                    _npcToView = hit.transform;

                    Move(hit.transform.position + (transform.forward * -6));
                    _needsRotation = true;

                    //Check to see if a merchant was hit and confirm that it was the box collider 
                    // (i.e. the player clicked on the merchant and not in the travel sphere)
                    if (hit.transform.tag.Equals("Merchant") && hit.collider == hit.transform.GetComponent<BoxCollider>())
                    {
                        hit.transform.GetComponent<MerchantInteraction>().StartStoreUICoroutine(this);
                    }
                }
            }
        }

        //NOTE: This was changed from the video as I realized the NavMesh agent was fighting the rotation. 
        //      The distance check that I was doing was incorrect and needed to take into consideration the Navigation system.
        //      I was also missing telling the navigation system to stop / resume.
        if (IsMoving && GetIsNavigationDonePathing())
        {
            _navMeshAgent.Stop();
            IsMoving = false;
        }

        if (_needsRotation && !IsMoving)
        {
            RotateTowards(2f);
        }
    }

    /// Checks to see if the game object has reached it's destination.
    public bool GetIsNavigationDonePathing()
    {
        //Debug.Log("Pathing Check: [Position]" + (Vector3.Distance(_navMeshAgent.destination, transform.position) + "Stopping Distance" + _navMeshAgent.stoppingDistance));
        return Vector3.Distance(_navMeshAgent.destination, transform.position) <= _navMeshAgent.stoppingDistance;
    }

    /// <summary>
    /// Move the player by providing a new destination to the Navigation system and resuming it.
    /// </summary>
    /// <param name="newPosition"></param>
    private void Move(Vector3 newPosition)
    {
        IsMoving = true;
        _navMeshAgent.SetDestination(newPosition);
        _navMeshAgent.Resume();
    }

    /// <summary>
    /// Rotate towards a specific object, in this case the NPC Transform. 
    /// </summary>
    /// <param name="speed">Speed in which to rotate</param>
    private void RotateTowards(float speed)
    {
        Vector3 direction = (_npcToView.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);

        if (Quaternion.Angle(transform.rotation, lookRotation) < 1)
        {
            _needsRotation = false;
        }
    }
}
