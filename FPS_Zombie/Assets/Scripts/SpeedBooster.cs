using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    private Player ply;
    private float initialSpeed;
    private float boostSpeed = 2;
    private float boostTime = 5;
    private float boostTimer;
    private bool isBoosting=false;
    
    
    public void StartSpeeding()
    {
        initialSpeed = ply.speed;
        ply.speed = boostSpeed*initialSpeed;
        isBoosting = true;
        boostTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBoosting){
            boostTimer += Time.deltaTime;
        }
        
        if (isBoosting && boostTimer >= boostTime){
        ply.speed = initialSpeed;
        isBoosting = false;
        }
    }
}
