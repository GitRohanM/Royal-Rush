using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float timeAmount = 5f;
    [SerializeField] float obstacleDecreaseTimeAmount = 0.2f;

    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.UpdateTime(timeAmount);
            obstacleSpawner.DecreaseObstacleSpawnTime(obstacleDecreaseTimeAmount);
        }
    }


}
