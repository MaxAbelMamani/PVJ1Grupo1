using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehaviour : MonoBehaviour
{
    [SerializeField]
    private float chestCont = 0;
    public GameObject finalMesagge;
    public bool yes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (chestCont == 3)
        {
            yes = true;
            finalMesagge.gameObject.SetActive(yes);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            chestCont += 1;
            finalMesagge.gameObject.SetActive(yes);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            chestCont -= 1;
            finalMesagge.gameObject.SetActive(yes);
        }
    }
}
