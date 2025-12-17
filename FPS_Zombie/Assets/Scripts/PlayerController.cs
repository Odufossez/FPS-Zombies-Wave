using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    //private float rotationSpeed = 2.0f;
    private Rigidbody _rigidbody;
    public int zombiesKilled;
    public GameObject gameOverPanel;
    
    public GameOverScript gameOverScript;

    public float life;
    public const float MaxLife = 50;

    private PlayerInputController _playerInputController;

    private void Awake()
    {
        gameOverScript = gameObject.GetComponentInParent<GameOverScript>();
        _playerInputController = GetComponent<PlayerInputController>();
        _rigidbody = GetComponent<Rigidbody>();
        zombiesKilled = 0;
        life = MaxLife;
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

    public void TakeHit(float damage)
    {
        life = life - damage;
        if (life <= 0)
        {
            IsDead();
        }
    }

    public void IsDead()
    {
        //Debug.Log("You are dead !");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverScript.Setup(zombiesKilled);
    }
}
