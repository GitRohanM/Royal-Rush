using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float timeAmount = 5f;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.UpdateTime(timeAmount);
        }
    }


}
