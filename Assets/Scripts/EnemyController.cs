using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    private NavMeshAgent navmeshagent;
    private Animator anim;
    public Transform[] patrolPoints;
    private int currentControlPointIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        MoveToNextPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (navmeshagent.enabled)
        {
            bool patrol = false;

            patrol = patrolPoints.Length > 0;

            if (patrol)
            {
                if (!navmeshagent.pathPending && navmeshagent.remainingDistance < 0.01f)
                {
                    MoveToNextPatrolPoint();
                }
            }

            anim.SetBool("Running", patrol);
        }
    }

    void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            navmeshagent.destination = patrolPoints[currentControlPointIndex].position;

            currentControlPointIndex++;
            currentControlPointIndex %= patrolPoints.Length;
        }
    }

}
