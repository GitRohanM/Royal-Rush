using UnityEngine;
using Unity.Cinemachine;
using Unity.VisualScripting;

public class Rock : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] float shakeModifier = 10f;
    [SerializeField] float CollisionCooldown = 1f;

    CinemachineImpulseSource impulseSource;

    float collisionTimer = 1f;

    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    void Update()
    {
        collisionTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (collisionTimer < CollisionCooldown) return;


        FireImpulse();
        CollisionFX(other);
        collisionTimer = 0f;
    }

    void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        impulseSource.GenerateImpulse(shakeIntensity);
    }

    void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;

        collisionParticleSystem.Play();
        audioSource.Play();
    }
}
