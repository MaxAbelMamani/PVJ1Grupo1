using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    public float initialX, initialY, initialZ;
    public float rotationX, rotationY, rotationZ;
    // Start is called before the first frame update
    void Start()
    {
        initialX = transform.position.x;
        initialY = transform.position.y;
        initialZ = transform.position.z;
        rotationX = transform.eulerAngles.x;
        rotationY = transform.eulerAngles.y;
        rotationZ = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane" || other.tag == "Enemy")
        {
            transform.position = new Vector3(initialX, initialY, initialZ);
            transform.eulerAngles = new Vector3(rotationX, rotationY, rotationZ);
        }
    }
}
