using UnityEngine.Events;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float FireCooldown;
    public bool Automatic;
    private float CurrentCooldown;
    // public int magazine_capacity;
    // public int magazine_;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentCooldown = FireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Automatic)
        {
            if (Input.GetMouseButton(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }
        CurrentCooldown -= Time.deltaTime;
    }
}
