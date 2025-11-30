using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    private float rotationSpeed = 2.0f;

    private PlayerInputController _playerInputController;

    private void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        Vector3 positionChange = new Vector3(_playerInputController.MovementInputVector.x , 0 , _playerInputController.MovementInputVector.y) * Time.deltaTime * _speed;
        //Vector3 positionChange = new Vector3(_playerInputController.MovementInputVector.x , 0 , _playerInputController.MovementInputVector.y) * Time.deltaTime;
        transform.Translate (positionChange);
        transform.Rotate(0, rotationSpeed*Input.GetAxis("Mouse X"), 0);
    }
}