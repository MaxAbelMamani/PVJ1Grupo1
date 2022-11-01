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
    public float Speed = 1.0f;
    public float RotationSpeed = 1.0f;
    public float JumpForce = 1.0f;
    public bool OnGround = true;
    public Vector3 jump;
    private Rigidbody rb = null;
    public TextMeshProUGUI message;
    
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
        jump = new Vector3(0.0f,2.0f,0.0f);


        message.text = "Consejo: pulsa E para agarrar y Q para soltar.";
        
    }
    private void OnCollisionStay(Collision collision)
    {
        OnGround = true;
    }

    private void OnCollisionExit(Collision collision) {
        OnGround = false;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plane" || other.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            transform.position = new Vector3(initialX,initialY,initialZ);
            transform.eulerAngles = new Vector3(initialRotX, initialRotY, initialRotZ);
        }
    }
}
