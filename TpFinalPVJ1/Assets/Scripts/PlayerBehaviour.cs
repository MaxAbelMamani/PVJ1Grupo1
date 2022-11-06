using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    public float initialX, initialY, initialZ;
    public float initialRotX, initialRotY, initialRotZ;
    public float Speed = 1.1f;
    public float RotationSpeed = 1.0f;
    public float JumpForce = 1.2f;
    public bool OnGround = true;
    public Vector3 jump;
    private Rigidbody rb = null;
    public TextMeshProUGUI message;
    public Transform groundPoint;
    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        initialX = transform.position.x;
        initialY = transform.position.y;
        initialZ = transform.position.z;
        initialRotX = transform.eulerAngles.x;
        initialRotY = transform.eulerAngles.y;
        initialRotZ = transform.eulerAngles.z;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = this.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f,150.0f,0.0f);


        
    }
   
    // Update is called once per frame
    void Update()
    {
        //Movimiento 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * Speed);
        //Rotacion
        float rotationY = Input.GetAxis("Mouse X");

        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed, 0));

        //Salto
        if (Input.GetKeyDown(KeyCode.Space) == true && OnGround == true)
        {
            rb.AddForce(jump * JumpForce, ForceMode.Impulse);
            OnGround = false;
        }

        time += Time.deltaTime;
        message.text = "Tiempo:" + time.ToString("F2");
    }

    private void FixedUpdate()
    {
        //Debug.DrawRay(groundPoint.position, groundPoint.TransformDirection(Vector3.down) * 0.5f, Color.green);
        if (Physics.Raycast(groundPoint.position, groundPoint.TransformDirection(Vector3.down), 0.5f))
        {
            OnGround = true;
        }
        else
        {
            OnGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plane" || other.tag == "Enemy")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("time",time);
    }
}
