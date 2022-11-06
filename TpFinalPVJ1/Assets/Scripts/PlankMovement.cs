using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankMovement : MonoBehaviour
{
    [SerializeField]
    private float plankType;
    private float speedYUp = 0.14f;
    private float speedZUp = -1.5f;
    private float speedYDown = -0.20f;
    private float speedZDown = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (plankType)
        { 
            case 1:
            {
                transform.Translate(0, speedYUp * Time.deltaTime, speedZUp * Time.deltaTime);
                break;
            }
            case 2:
            {
                transform.Translate(0, speedYDown * Time.deltaTime, speedZDown * Time.deltaTime);
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {
            Destroy(gameObject);
        }       
    }
}
