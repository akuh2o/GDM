using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float detectionRange = 10f; // Rango de detección editable en el inspector
    private int currentPoint = 0;
    private NavMeshAgent agent;
    private Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        agent.destination = patrolPoints[currentPoint].position;
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
    }

    void Update()
    {
        if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            agent.destination = player.position;
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GoToNextPoint();
            }
        }
    }
}
