using UnityEngine;
public class CoinSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 10f;
    public float spawnInterval = 1f;

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + Random.Range(1f, 3.5f);
        }
    }

    void Spawn()
    {
        Vector3 spawnPos = new Vector3(0, Random.Range(-spawnRange, spawnRange), spawnRange);
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
