using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.position.y <= -10f)
        {
            Destroy(other.gameObject);
        }   
    }
}
