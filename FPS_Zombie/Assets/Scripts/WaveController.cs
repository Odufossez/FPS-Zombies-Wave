using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    public int _waveNumber;
    private int _zombieNumber;
    private int _zombieSpawnedThisRound;
    private float _zombieSpeed;
    private float _zombieLife;
    private float _spawnCooldown;
    private int _nbZombieInScene;
    
    private float _zombieSpeedMultiplier; // Devient un multiplicateur de vitesse de vague
    private float _zombieLifeMultiplier; // Multiplicateur pour la vie
    private float _zombieDamageMultiplier; // Multiplicateur pour les dégâts
    //public Zombie_script _zombie;
    public TMP_Text waveText;
    public TMP_Text bullets;
    public TMP_Text lifeText;

    [Header("Prefab du zombie à instancier")]
    public GameObject zombiePrefab;
	public GameObject zombieRusher;
    public PlayerController playerController;
    public Gun gun;
	public GameObject[] zombies;
    
    
    public ShopManager shopManager;
    private bool _isShopOpen = false;

    private float _spawnTimer;

    void Start()
    {
        _zombieSpeedMultiplier = 1.0f; // Initialise le multiplicateur à 1 (pas de modification de vitesse au début)
        _zombieLifeMultiplier = 1.0f;
        _zombieDamageMultiplier = 1.0f;
        _waveNumber = 1;
        _spawnCooldown = 1.5f;
        _zombieNumber = 7;
        _zombieSpawnedThisRound = 0;
        _spawnTimer = 0f;
        _isShopOpen = false;
        // _zombie = GameObject.FindFirstObjectByType<Zombie_basique>();
    }

    void Update()
    {
        if (_isShopOpen) return;
        // Debug.Log(_nbZombieInScene);
        waveText.text = "Manche : " + _waveNumber;
        bullets.text = gun._bulletLeft + "/" + gun._magazineSize;
        lifeText.text = playerController.life + "/" + PlayerController.MaxLife;
        _nbZombieInScene = GetZombieCountInScene();
        if (_zombieSpawnedThisRound < _zombieNumber)
        {
            if (_spawnTimer <= 0f)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-47, 47), 1, Random.Range(-47, 47));
                GameObject zombie;
                if(_waveNumber>=2){
			        zombie = Instantiate(zombies[Random.Range(0, zombies.Length)], spawnPosition, Quaternion.identity);
				}
                else
                {
                    zombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
                }
                NavMeshAgent agent = zombie.GetComponent<NavMeshAgent>();
                Zombie_script zombieComponent = zombie.GetComponent<Zombie_script>();
                
                if (zombieComponent != null)
                {
                    // Applique le multiplicateur de vague à la vitesse de base du zombie
                    agent.speed = zombieComponent.baseMovementSpeed * _zombieSpeedMultiplier;
                    // Applique les multiplicateurs de vague à la vie et aux dégâts
                    zombieComponent.currentLife = zombieComponent.baseLife * _zombieLifeMultiplier;
                    zombieComponent.currentDamage = zombieComponent.baseDamage * _zombieDamageMultiplier;
                }
                else
                {
                    Debug.LogWarning("Zombie spawned without Zombie_script component. Speed set to default * wave multiplier.");
                    agent.speed = 2.5f * _zombieSpeedMultiplier; // Fallback pour les zombies sans Zombie_script
                }
                _zombieSpawnedThisRound++;
                _spawnTimer = _spawnCooldown;
            }
        } else if(_nbZombieInScene==0) {  // on passe à la vague suivante
            OpenShopPhase();
        }
        _spawnTimer -= Time.deltaTime;
    }

    int GetZombieCountInScene()
    {
        return GameObject.FindGameObjectsWithTag("Zombie").Length;
    }
    
    void OpenShopPhase()
    {
        _isShopOpen = true;
        shopManager.OpenShop();
    }
    
    public void StartNextWave()
    {
        _isShopOpen = false;
        
        // La logique de difficulté qui était dans Update est déplacée ici
        _waveNumber+=1;
        
        if(_spawnCooldown>0.1f){
            _spawnCooldown=_spawnCooldown*0.75f;
        }
        _zombieSpawnedThisRound=0;
        _zombieNumber=_zombieNumber*2;
        _zombieSpeedMultiplier *= 1.25f; // Le multiplicateur de vitesse augmente avec la vague
        _zombieLifeMultiplier *= 1.5f; // La vie pourrait augmenter plus vite, par exemple
        _zombieDamageMultiplier *= 1.2f; // Les dégâts aussi !
        /*
        if (_zombie != null) 
        {
            _zombie.damage = _zombie.damage * 2;
            _zombie.life = _zombie.life * 2;
        }*/
    }
}
