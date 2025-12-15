using System;
using UnityEngine;

public class BoosterCollection : MonoBehaviour
{
    public SpeedBooster speedBooster;
	public NukeBooster nukeBooster;

    private void Start()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter : " + other.transform.tag);
        Destroy(other.gameObject);
        switch (other.transform.tag)
        {
            case "SpeedBooster":
                speedBooster.StartSpeeding();
                break;
            case "Nuke Booster":
                Debug.Log("Booster Nuke collected");
               	nukeBooster.OnCollected();
                break;
            default:
                Debug.Log("No booster");
                break;
        }
    }
}
