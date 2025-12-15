using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private float _initialSpeed;
    private readonly float _boostSpeed = 2f;
    private readonly float _boostTime = 5f;
    private float _boostTimer;
    private bool _isBoosting;
    
    
    public void OnCollected()
    {
        Debug.Log("Speed Booster Activated on " + gameObject.name);
        playerMovement = gameObject.GetComponentInParent<PlayerMovement>();
        if (playerMovement == null)
        {
            Debug.Log("PlayerMovement script not found");
        }
        _initialSpeed = playerMovement.moveSpeed;
        Debug.Log("Initial Speed: " + _initialSpeed);
        playerMovement.moveSpeed = _boostSpeed*_initialSpeed;
        Debug.Log("Boost Speed: " + playerMovement.moveSpeed);
        _isBoosting = true;
        _boostTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isBoosting){
            _boostTimer += Time.deltaTime;
        }
        
        if (_isBoosting && _boostTimer >= _boostTime){
            playerMovement.moveSpeed = _initialSpeed;
            _isBoosting = false;
            _boostTimer = 0;
        }
    }
}
