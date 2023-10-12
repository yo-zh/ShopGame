// TODO: Пофиксить факт, что покупатель не пропадает на выходе

using UnityEngine;
using UnityEngine.AI;

public class CustomerNavigation : MonoBehaviour
{
    GameObject cashRegister;
    GameObject exitPoint;

    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer;
    // Patrol vars
    Vector3 destPoint;
    Vector3 goal;
    bool walkPointSet;

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        cashRegister = GameObject.Find("CustomerPlatform");
        exitPoint = GameObject.Find("ExitPoint");
        goal = cashRegister.transform.position;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkPointSet) SearchForDest();
        if (walkPointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(goal, destPoint) < 1.5 && gameObject.GetComponent<CustomerOrder>() == null)
        {
            walkPointSet = false;
            goal = exitPoint.transform.position;
        }
    }

    void SearchForDest()
    {
        if (gameObject.GetComponent<CustomerOrder>() == null)
            destPoint = exitPoint.transform.position;
        else
            destPoint = new Vector3(goal.x, transform.position.y, goal.z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkPointSet = true;
        }
    }
}
