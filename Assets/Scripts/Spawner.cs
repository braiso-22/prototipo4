using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabList;
    private float spawnRange = 9;
    public int enemyCount;
    private int waveNumber = 1;
    public GameObject powerupPrefab;
    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-spawnRange,
       spawnRange);
        float spawnZ = Random.Range(-spawnRange,
       spawnRange);
        return new Vector3(spawnX, 0, spawnZ);
    }
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int aleatorio = Random.Range(0, enemyPrefabList.Length);
            Instantiate(enemyPrefabList[aleatorio], GenerateSpawnPosition(),
                   enemyPrefabList[aleatorio].transform.rotation);
        }
    }


    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount <= 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
}
