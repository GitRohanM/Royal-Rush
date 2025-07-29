using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameoverText;

    [SerializeField] float startTime = 5f;
    float timeLeft;

    bool gameOver = false;

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        DecreaseTime();
    }

    void DecreaseTime()
    {
        if (gameOver) return;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        gameoverText.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
