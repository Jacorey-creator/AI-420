using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    [SerializeField] float seeDistance = 4.0f;

    [SerializeField] float wanderRange;
    public Transform centrePoint; // Centered on themselves 


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position,transform.position); 
        if ((distance < seeDistance))
        {
            agent.destination = player.position; // Follow the player
        }
        else 
        {
            if (agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, wanderRange, out point)) //pass in our centre point and radius of area
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(point);
                }
            }
        }
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
