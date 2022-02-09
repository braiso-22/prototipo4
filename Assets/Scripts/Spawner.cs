using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
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
        Instantiate(enemyPrefab, GenerateSpawnPosition(),
       enemyPrefab.transform.rotation);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
