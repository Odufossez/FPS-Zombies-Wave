using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Gun gun;
    public Image mask;
    public float current;
    public float max;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        max = gun._reloadCooldown;
        current = gun._reloadTimer;
        GetCurrentFill();
    }
    
    public void GetCurrentFill()
    {
        float fillAmount = current / max;
        mask.fillAmount = fillAmount;
    }
}
