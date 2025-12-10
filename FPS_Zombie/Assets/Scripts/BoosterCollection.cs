using System;
using UnityEngine;

public class BoosterCollection : MonoBehaviour
{
    public SpeedBooster speedBooster;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter : " + other.transform.tag);
        Destroy(other.gameObject);
        switch (other.transform.tag)
        {
            case "SpeedBooster":
                speedBooster.StartSpeeding();
                break;
            case "ShieldBooster":
                Debug.Log("Shield Booster");
                break;
            default:
                Debug.Log("No booster");
                break;
        }
    }
}
