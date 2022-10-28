using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject plank;
    [SerializeField]
    private float initTime;
    [SerializeField]
    private float repeatTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPlank", initTime, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPlank()
    {
        Instantiate(plank, transform.position, transform.rotation);

    }
}
