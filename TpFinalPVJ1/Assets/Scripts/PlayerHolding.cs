using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolding : MonoBehaviour
{
    public GameObject hand;
    private GameObject pickedObject =  null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedObject!=null)
        {
            if (Input.GetKey("q"))
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject=null;
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = hand.transform.position;
                other.transform.eulerAngles = hand.transform.eulerAngles;
                other.gameObject.transform.SetParent(hand.gameObject.transform);
                pickedObject = other.gameObject;
            }
        }
    }
}
