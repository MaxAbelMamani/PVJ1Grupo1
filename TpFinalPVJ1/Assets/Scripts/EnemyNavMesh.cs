using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    
    public NavMeshAgent navMeshAgent;
    public Transform[] points;
    private int destPoint = 0;
    bool moveNext = false;
    public float timeToNext = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;
        GotoNextPoint();
    }


        void GotoNextPoint() {
            StartCoroutine(TimeMove());
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            navMeshAgent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }

    // Update is called once per frame
    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.

        if(moveNext)
        {
            if (navMeshAgent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }

    IEnumerator TimeMove()
    {
        moveNext = false;
        yield return new WaitForSeconds(timeToNext*Time.deltaTime);
        moveNext = true;
    }
}
