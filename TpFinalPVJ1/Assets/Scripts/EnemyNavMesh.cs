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
            
            if (points.Length == 0)
                return;

            
            navMeshAgent.destination = points[destPoint].position;

            destPoint = (destPoint + 1) % points.Length;
        }

    // Update is called once per frame
    void Update()
    {
        

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
