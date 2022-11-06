using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatBehaviour : MonoBehaviour
{
    [SerializeField]
    private float chestCont = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (chestCont == 3)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            chestCont += 1;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            chestCont -= 1;
        }
    }
}
