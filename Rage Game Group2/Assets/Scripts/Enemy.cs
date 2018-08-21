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
    public Animator animator;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wpSolver = GetComponent<WaypointSolver>();
        player = FindObjectOfType<Player>();
        animator.SetFloat("Walk", 1);
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
               // animator.SetFloat("Walk", 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Walk", agent.velocity.magnitude);
        if (state == EnemyState.Chase)
        {
            agent.SetDestination(player.transform.position);
           // animator.SetFloat("Walk" , 1);
        }
    }
}