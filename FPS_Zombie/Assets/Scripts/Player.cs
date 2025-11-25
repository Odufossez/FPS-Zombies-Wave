using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float rotationSpeed = 2f;
    public float speed = 2;

    public float baseSpeed = 2;
    public float sprintSpeed = 10;
    public float jumpForce = 5f;
    public Boolean canJump = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed=sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed=baseSpeed;
        }
        if (Input.GetKey(KeyCode.W))  // quand on reste appuie
        {
            transform.Translate(0, 0, speed * Time.deltaTime); //on déplace a gauche
        }
        if (Input.GetKey(KeyCode.S))  // quand on reste appuie
        {
            transform.Translate(0, 0, -speed * Time.deltaTime); //on déplace a gauche
        }
        if (Input.GetKey(KeyCode.A))  // quand on reste appuie
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0); //on déplace a gauche
        }
        if (Input.GetKey(KeyCode.D))  // quand on reste appuie
        {
            transform.Translate(speed * Time.deltaTime, 0, 0); //on déplace a gauche
        }
        /*
        if (Input.GetKey(KeyCode.Q))  
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0); //on déplace a gauche
        }
        if (Input.GetKey(KeyCode.E))  
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); //on déplace a gauche
        }
        */
        if (Input.GetKeyDown(KeyCode.Space) && canJump) //saut
        {
            GetComponent<Rigidbody>().linearVelocity = Vector3.up*jumpForce;    
            canJump=false;
        }

        

        //rayon
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit, 1f))
        {
            //if(hit.transform.tag == "Ground")
            //{
                canJump = true;
            //}
        }


        //cam
        transform.Rotate(0, rotationSpeed*Input.GetAxis("Mouse X"), 0);
        
    }

/*    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
    */
}
