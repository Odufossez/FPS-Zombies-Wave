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

        if (nukeBooster == null)
        {
            Debug.Log("Nuke Booster component not found on " + gameObject.name);
        }
    }


    public void OnBoosterCollected(String tagBooster)
    {
        Debug.Log(" ONBOOSTERCOLLECTED - Booster collected : " + tagBooster);
        
        switch (tagBooster)
        {
            case "SpeedBooster":
                                
                break;
            case "Nuke Booster":                
                if (nukeBooster != null)
                {
                    nukeBooster.OnCollected();  
                } else
                {
                    Debug.Log("Nuke Booster is null");
                }
                              
                break;
            default:
                Debug.Log("No booster");
                break;
        }
    }
}
