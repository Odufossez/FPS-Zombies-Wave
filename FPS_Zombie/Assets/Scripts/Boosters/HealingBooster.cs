using UnityEngine;

public class HealingBooster : MonoBehaviour
{
    public float healing;
    [SerializeField] private PlayerController playerController;

    public void OnCollected()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.Log("PlayerController not found");
            return;
        }
        
        playerController.life += healing;
        
        if (playerController.life > PlayerController.maxlife)
        {
            playerController.life = PlayerController.maxlife;
        }
        //Debug.Log("Healing Booster Activated on " + gameObject.name);
    }
}
