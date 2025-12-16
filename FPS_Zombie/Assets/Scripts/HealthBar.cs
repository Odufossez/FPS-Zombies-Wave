using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class HealthBar : MonoBehaviour
{
    public float max;
    public float current;
    public Image mask;
    
    public PlayerController playerController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        max = PlayerController.MaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        current = playerController.life;
        GetCurrentFill();
    }

    public void GetCurrentFill()
    {
        float fillAmount = current / max;
        mask.fillAmount = fillAmount;
    }
}
