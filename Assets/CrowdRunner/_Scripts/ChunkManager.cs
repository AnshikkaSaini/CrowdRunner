using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    //Elements
    [SerializeField] private Chunk[] chunkPrefabs;
   

    [SerializeField]private Chunk[] levelChunks;
    
    void Start()
    {
        CreateOrderedLevel();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateOrderedLevel()
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < levelChunks.Length; i++)
        {
            Chunk ChunkToCreate = levelChunks[i];
            if (i > 0)
            {
                chunkPosition.z += ChunkToCreate.GetLength() / 2;
            }
            
            Chunk chunkInstance =  Instantiate (ChunkToCreate, 
                chunkPosition, Quaternion.identity, transform);
            
            chunkPosition.z += chunkInstance.GetLength()/2;
        }
    }

    private void CreateRandomLevel()
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < 5; i++)
        {
            Chunk ChunkToCreate = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];
            if (i > 0)
            {
                chunkPosition.z += ChunkToCreate.GetLength() / 2;
            }
            
            Chunk chunkInstance =  Instantiate (ChunkToCreate, 
                chunkPosition, Quaternion.identity, transform);
            
            chunkPosition.z += chunkInstance.GetLength()/2;
        }
        
    }

}
