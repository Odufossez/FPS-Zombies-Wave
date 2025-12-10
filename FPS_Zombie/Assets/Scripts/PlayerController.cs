using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    private float rotationSpeed = 2.0f;
    private Rigidbody _rigidbody;

    private PlayerInputController _playerInputController;

    private void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 positionChange = new Vector3(_playerInputController.MovementInputVector.x , 0 , _playerInputController.MovementInputVector.y) * Time.deltaTime * _speed;
        // Vector3 positionChange = new Vector3(_playerInputController.MovementInputVector.x , 0 , _playerInputController.MovementInputVector.y) * Time.deltaTime;
        transform.Translate (positionChange);
        // transform.Rotate(0, rotationSpeed*Input.GetAxis("Mouse X"), 0);
        

        // Vector3 velocity = new Vector3(_playerInputController.MovementInputVector.x,0,_playerInputController.MovementInputVector.y)* _speed;

        // velocity.y = _rigidbody.linearVelocity.y;

        // _rigidbody.linearVelocity = velocity;
    }
}