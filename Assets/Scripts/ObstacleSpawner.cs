using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnInterval = 2f;
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(obstaclePrefab, transform.position, Random.rotation);
        }
    }

    
}
