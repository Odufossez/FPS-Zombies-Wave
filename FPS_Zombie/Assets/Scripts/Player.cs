using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    //private float rotationSpeed = 2f;
    public float speed = 2;
    //public float _speed = 2;

    public float baseSpeed = 2;
    public float sprintSpeed = 10;
    public float jumpForce = 5f;
    public Boolean canJump = false;
    private PlayerInputController _playerInput;
    private Rigidbody _rigidbody;




    // TEST
    public float acceleration = 10f;
    public float deceleration = 8f;
    private Vector3 currentVelocity = Vector3.zero;
    private Rigidbody rb;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputController>();
        _rigidbody = GetComponent<Rigidbody>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Cursor.lockState = CursorLockMode.Locked;

        //Vector3 velocity = new Vector3(_playerInput.MovementInputVector.x,0,_playerInput.MovementInputVector.y)* _speed;

        // velocity.y = _rigidbody.linearVelocity.y;

        // _rigidbody.linearVelocity = velocity;

        // float targetSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : baseSpeed;
        // Vector3 inputDir = new Vector3(
        //     Input.GetAxisRaw("Horizontal"),
        //     0,
        //     Input.GetAxisRaw("Vertical")
        // ).normalized;

        // Vector3 targetVelocity = transform.TransformDirection(inputDir) * targetSpeed;



        // currentVelocity = Vector3.MoveTowards(currentVelocity, targetVelocity, 
        //     (targetVelocity.magnitude > currentVelocity.magnitude ? acceleration : deceleration) * Time.deltaTime);

        // rb.linearVelocity = new Vector3(currentVelocity.x, rb.linearVelocity.y, currentVelocity.z);



       /*  if (Input.GetKey(KeyCode.LeftShift))
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
        } */
        
        
        //Vector3 targetVelocity = transform.TransformDirection(inputDir) * targetSpeed;

        // if (Input.GetKey(KeyCode.W))  // avancer en avant
        // {
        //     //GetComponent<Rigidbody>().linearVelocity = Vector3.forward*speed;
        //     transform.Translate(0, 0, speed * Time.deltaTime ); //on déplace a gauche
        // }

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
        // transform.Rotate(0, rotationSpeed*Input.GetAxis("Mouse X"), 0);
        
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
