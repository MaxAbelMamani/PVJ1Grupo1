using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatBehaviour : MonoBehaviour
{
    [SerializeField]
    private float chestCont = 0;
    private AudioSource audioSource;
    public AudioClip chestClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(chestClip);
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
