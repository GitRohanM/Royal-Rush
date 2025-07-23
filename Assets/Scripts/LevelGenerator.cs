using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmt = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;

    GameObject[] chunks = new GameObject[12];

    void Start()
    {
        SpwanChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    void SpwanChunks()
    {
        for (int i = 0; i < startingChunksAmt; i++)
        {
            Vector3 spwanPosition = transform.position + new Vector3(0f, 0f, i * chunkLength);
            GameObject newChunk = Instantiate(chunkPrefab, spwanPosition, Quaternion.identity, chunkParent);
            chunks[i] = newChunk;
        }
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Length; i++)
        {
            chunks[i].transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));  
        }
    }
}
