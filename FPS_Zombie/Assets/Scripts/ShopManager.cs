using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header("Références")]
    public GameObject shopCanvas; // panneau UI complet
    public WaveController waveController;
    public Gun gun;
    public DamageGun dmgGun;
    public PlayerController playerController;
    public PaP pap;

    [Header("Configuration UI - Bouton 3 (Dégâts)")]
    public TMP_Text damagePriceText;
    public TMP_Text damageLevelText;
    public int damageBasePrice = 100;
    private int _damageLevel = 1;

    [Header("Configuration UI - Bouton 2 (Reload Speed)")]
    public TMP_Text reloadSpeedPriceText;
    public TMP_Text reloadSpeedLevelText;
    public int reloadSpeedBasePrice = 150;
    private int _reloadSpeedLevel = 1;

    [Header("Configuration UI - Bouton 1 (Munitions)")]
    public TMP_Text ammoPriceText;
    public TMP_Text ammoLevelText;
    public int ammoBasePrice = 80;
    private int _ammoLevel = 1;

    public TMP_Text moneyText;
    public MonoBehaviour cameraController;

    public GameObject hudCanvas;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopCanvas.SetActive(false);
        if(hudCanvas != null) hudCanvas.SetActive(true);
        UpdateUI();
    }
    
    public void OpenShop()
    {
        shopCanvas.SetActive(true);
        if(hudCanvas != null) hudCanvas.SetActive(false);
        Time.timeScale = 0f; 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        if (cameraController != null)
        {
            cameraController.enabled = false;
        }
        UpdateUI();
    }

    public void CloseAndStartWave()
    {
        shopCanvas.SetActive(false);
        
        // On relance le temps
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        if (cameraController != null)
        {
            cameraController.enabled = true;
        }

        // On dit au WaveController de lancer la suite
        waveController.StartNextWave();
    }
    
    //ACHATS
    public void BuyDamageUpgrade()
    {
        int price = CalculatePrice(damageBasePrice, _damageLevel);
        if (pap._moneyAmount >= price)
        {
            pap._moneyAmount -= price;
            _damageLevel++;
            
            // Appliquer l'amélioration (Exemple)
            dmgGun.Damage += 5; 
            Debug.Log("Dégâts améliorés !");

            UpdateUI();
        }
    }
    
    public void BuyReloadSpeedUpgrade()
    {
        int price = CalculatePrice(reloadSpeedBasePrice, _reloadSpeedLevel);
        if (pap._moneyAmount >= price)
        {
            pap._moneyAmount -= price;
            _reloadSpeedLevel++;

            // Appliquer l'amélioration
            // PlayerController.MaxLife += 20;
            // playerController.Heal(20); // Soigne le joueur en même temps
            gun._reloadCooldown -= 0.05f;
            
            Debug.Log("Reload speed améliorée !");

            UpdateUI();
        }
    }
    
    public void BuyAmmoUpgrade()
    {
        int price = CalculatePrice(ammoBasePrice, _ammoLevel);
        if (pap._moneyAmount >= price)
        {
            pap._moneyAmount -= price;
            _ammoLevel++;

            // Appliquer l'amélioration
            gun._magazineSize += 5;
            Debug.Log("Chargeur agrandi !");

            UpdateUI();
        }
    }
    
    void UpdateUI()
    {
        if(moneyText != null) moneyText.text = "Argent : " + pap._moneyAmount + "$";

        UpdateButtonUI(damagePriceText, damageLevelText, damageBasePrice, _damageLevel);
        UpdateButtonUI(reloadSpeedLevelText, reloadSpeedLevelText, reloadSpeedBasePrice, _reloadSpeedLevel);
        UpdateButtonUI(ammoPriceText, ammoLevelText, ammoBasePrice, _ammoLevel);
    }
    
    void UpdateButtonUI(TMP_Text priceText, TMP_Text levelText, int basePrice, int level)
    {
        int currentPrice = CalculatePrice(basePrice, level);
        priceText.text = "Prix : " + currentPrice + "$";
        levelText.text = "Niv. " + level;
    }
    
    int CalculatePrice(int basePrice, int level)
    {
        return Mathf.RoundToInt(basePrice * Mathf.Pow(1.2f, level - 1));
    }
}
