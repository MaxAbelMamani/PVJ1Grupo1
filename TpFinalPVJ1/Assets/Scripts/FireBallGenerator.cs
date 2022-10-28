using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject fireBall, fireEnemy;
    [SerializeField]
    private float initTime;
    [SerializeField]
    private float repeatTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFireBall", initTime, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = fireEnemy.transform.position;
    }

    private void SpawnFireBall()
    {
        Instantiate(fireBall, transform.position, transform.rotation);

    }
}
