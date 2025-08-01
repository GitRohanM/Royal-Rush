using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float minSpawnInterval = .5f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 4f;
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    public void DecreaseObstacleSpawnTime(float amount)
    {
        spawnInterval -= amount;

        if(spawnInterval < minSpawnInterval)
        {
            spawnInterval = minSpawnInterval;
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3 (Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(prefab, spawnPosition, Random.rotation, obstacleParent);
        }
    }

    
}
