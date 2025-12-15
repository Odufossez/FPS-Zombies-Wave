using System;
using UnityEngine;

public class BoosterCollection : MonoBehaviour
{
    public NukeBooster nukeBooster;
    public SpeedBooster speedBooster;

    public void Start()
    {
        nukeBooster = GetComponent<NukeBooster>();
        speedBooster = GetComponent<SpeedBooster>();
    }


    public void OnBoosterCollected(String tagBooster)
    {
        switch (tagBooster)
        {
            case "Speed Booster":
            {
                if(speedBooster != null){
                    speedBooster.OnCollected();
                }
                else
                {
                    Debug.Log("Speed Booster is null");
                }

                break;
            }
            case "Nuke Booster":
            {
                if (nukeBooster != null)
                {
                    nukeBooster.OnCollected();  
                } else
                {
                    Debug.Log("Nuke Booster is null");
                }
                              
                break;
            }               
                
            default:
                Debug.Log("No booster");
                break;
        }
    }
}
