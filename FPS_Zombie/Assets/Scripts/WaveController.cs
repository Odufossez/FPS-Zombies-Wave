using TMPro;
using UnityEngine;
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
    public TMP_Text waveText;

    [Header("Prefab du zombie à instancier")]
    public GameObject zombiePrefab;

    private float _spawnTimer;

    void Start()
    {
        _waveNumber = 1;
        _spawnCooldown = 2.5f;
        _zombieNumber = 5;
        _zombieSpawnedThisRound = 0;
        _spawnTimer = 0f;
    }

    void Update()
    {
        // Debug.Log(_nbZombieInScene);
        waveText.text = "Manche : " + _waveNumber;
        _nbZombieInScene = GetZombieCountInScene();
        if (_zombieSpawnedThisRound < _zombieNumber)
        {
            if (_spawnTimer <= 0f)
            {
                Vector3 spawnPosition = new Vector3(0, 5, 0);
                Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
                _zombieSpawnedThisRound++;
                _spawnTimer = _spawnCooldown;
            }
        } else if(_nbZombieInScene==0) {  // on passe à la vague suivante
            _waveNumber+=1;
            if(_spawnCooldown>1f){
                _spawnCooldown=_spawnCooldown*0.8f;
            }
            _zombieSpawnedThisRound=0;
            _zombieNumber=_zombieNumber*2;
        }
        _spawnTimer -= Time.deltaTime;
    }

    int GetZombieCountInScene()
    {
        return GameObject.FindGameObjectsWithTag("Zombie").Length;
    }
}
