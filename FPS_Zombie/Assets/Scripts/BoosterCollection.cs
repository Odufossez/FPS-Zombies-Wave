using System;
using UnityEngine;

public class BoosterCollection : MonoBehaviour
{
    public SpeedBooster speedBooster;
	public NukeBooster nukeBooster;

    public void onBoosterCollected(String tagBooster)
    {
        Debug.Log("Booster collected : " + tagBooster);
        
        switch (tagBooster)
        {
            case "SpeedBooster":
                Debug.Log("Booster speed collected");
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
