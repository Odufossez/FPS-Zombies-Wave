using System.Collections.Generic;
using UnityEngine;

public class NukeBooster : MonoBehaviour
{

    private GameObject zombie;
    public void OnCollected()
    {
        zombie = GameObject.FindGameObjectWithTag("Zombie");
        while (zombie != null)
        {
            Destroy(zombie);
            zombie = GameObject.FindGameObjectWithTag("Zombie");
        }
    }
}
