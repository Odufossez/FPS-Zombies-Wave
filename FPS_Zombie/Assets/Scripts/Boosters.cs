using UnityEngine;

//lié au booster
public class Boosters : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BoosterCollection bc = other.GetComponent<BoosterCollection>();

        if (bc != null)
        {
            bc.onBoosterCollected(gameObject.tag); //passe le tag du booster au script de la collection
            Destroy(gameObject);
        }
    }
}
