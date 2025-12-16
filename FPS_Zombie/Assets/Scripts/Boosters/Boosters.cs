using System.Numerics;
using UnityEngine;


//lié au booster
public class Boosters : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BoosterCollection bc = other.GetComponent<BoosterCollection>();

        if (bc != null)
        {
            string boosterTag = gameObject.tag;
            Destroy(gameObject);
            bc.OnBoosterCollected(boosterTag); //passe le tag du booster au script de la collection
        } 
    }
}
