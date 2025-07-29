using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] Transform chunkParent;
    [SerializeField] ScoreManager scoreManager;

    [Header("Level Settings")]
    [Tooltip("The amount of chunks we start with")]
    [SerializeField] int startingChunksAmt = 12;
    [Tooltip("Do not change chunk length unless you know what you are doing")]
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 20f;
    [SerializeField] float minGravityZ = -22f;
    [SerializeField] float maxGravityZ = -2f;

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
        float newMoveSpeed = moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed, maxMoveSpeed);

        if (newMoveSpeed != moveSpeed)
        {
            moveSpeed = newMoveSpeed;

            float newGravityZ = Physics.gravity.z - speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ, minGravityZ, maxGravityZ);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);

            cameraController.changeCameraFOV(speedAmount);
        }
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
        GameObject newChunkGO = Instantiate(chunkPrefab, spwanPosition, Quaternion.identity, chunkParent);

        chunks.Add(newChunkGO);
        Chunk newChunk = newChunkGO.GetComponent<Chunk>();
        newChunk.Init(this, scoreManager);
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
