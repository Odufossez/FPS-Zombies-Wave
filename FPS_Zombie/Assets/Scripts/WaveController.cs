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
    public Zombie_script _zombie;
    public TMP_Text waveText;
    public TMP_Text bullets;
    public TMP_Text lifeText;

    [Header("Prefab du zombie à instancier")]
    public GameObject zombiePrefab;
    public PlayerController playerController;
    public Gun gun;
    
    public ShopManager shopManager;
    private bool _isShopOpen = false;

    private float _spawnTimer;

    void Start()
    {
        _zombieSpeed = 2f;
        _waveNumber = 1;
        _spawnCooldown = 2.5f;
        _zombieNumber = 5;
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
                Vector3 spawnPosition = new Vector3(0, 5, 0);
                GameObject zombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
                NavMeshAgent agent = zombie.GetComponent<NavMeshAgent>();
                agent.speed = _zombieSpeed;
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
        _zombieSpeed = _zombieSpeed*1.25f;
        
        if (_zombie != null) 
        {
            _zombie.damage = _zombie.damage * 2;
            _zombie.life = _zombie.life * 2;
        }
    }
}
