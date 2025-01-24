using UnityEngine;
using UnityEngine.AI;

public class HumanAI : MonoBehaviour
{
    public GameObject enemy; 
    private NavMeshAgent agent; // NavMeshAgent for pathfinding and movement
    [SerializeField] float runDistance = 4.0f; // Distance within which the AI starts running away

    
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the AI and the enemy
        float distance = Vector3.Distance(transform.position, enemy.transform.position);

        // If the enemy is within the specified run distance
        if (distance < runDistance)
        {
            // Calculate the direction away from the enemy
            Vector3 dirToPlayer = transform.position - enemy.transform.position;

            // Determine a new position to flee to, away from the enemy
            Vector3 newPos = transform.position + dirToPlayer;

            // Set the NavMeshAgent's destination to the new position
            agent.SetDestination(newPos);
        }
    }
}
