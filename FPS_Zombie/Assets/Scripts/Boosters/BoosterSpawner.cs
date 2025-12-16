using UnityEngine;

public class BoosterSpawner : MonoBehaviour
{
    private float spawnDelay = 10f;
    public GameObject boosterPrefab;
    public GameObject[] boosters;
    public Vector3 randomSpawn;
    public int randomBooster;

    public void Start()
    {
        InvokeRepeating("Spawning", spawnDelay, spawnDelay);
    }

    private void Spawning()
    {
        randomBooster = Random.Range(0, boosters.Length);
        randomSpawn = new Vector3(Random.Range(-47, 47), 2, Random.Range(-47, 47));
        Instantiate(boosters[randomBooster], randomSpawn, Quaternion.identity);
    }
}
