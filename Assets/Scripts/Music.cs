using UnityEngine;

public class Music : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] GameObject gameOverText;

    void Update()
    {
        StopMusic();
    }

    void StopMusic()
    {
        if (gameOverText.activeInHierarchy)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource.isPlaying)
            {
                audioSource.volume = .1f;
            }
        }
    }
}
