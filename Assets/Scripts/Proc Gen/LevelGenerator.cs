using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmt = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;


    // GameObject[] chunks = new GameObject[12];
    List<GameObject> chunks = new List<GameObject>();

    void Start()
    {

        SpwanStartingChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        moveSpeed += speedAmount;

        if (moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        }

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAmount);
        
        cameraController.changeCameraFOV(speedAmount);
    }

    void SpwanStartingChunks()
    {
        for (int i = 0; i < startingChunksAmt; i++)
        {
            SpwanChunk();
        }
    }

    private void SpwanChunk()
    {
        float spwanPositionZ = CalculateSpawnPositionZ();

        Vector3 spwanPosition = new Vector3(transform.position.x, transform.position.y, spwanPositionZ);
        GameObject newChunk = Instantiate(chunkPrefab, spwanPosition, Quaternion.identity, chunkParent);

        chunks.Add(newChunk);
    }

    float CalculateSpawnPositionZ()
    {
        float spwanPositionZ;
        if (chunks.Count == 0)
        {
            spwanPositionZ = transform.position.z;
        }
        else
        {
            spwanPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spwanPositionZ;
    }
    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunks[i].transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpwanChunk();
            }
        }
    }
}
