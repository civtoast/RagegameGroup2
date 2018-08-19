using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Patrol,
    Chase
}

public class Enemy : MonoBehaviour
{
    private EnemyState state = EnemyState.Patrol;
    private NavMeshAgent agent;
    private WaypointSolver wpSolver;
    private Player player;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wpSolver = GetComponent<WaypointSolver>();
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wpSolver.StopPatrolling();
            state = EnemyState.Chase;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (state == EnemyState.Chase)
            {
                state = EnemyState.Patrol;
                wpSolver.StartPatrolling();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.Chase)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}