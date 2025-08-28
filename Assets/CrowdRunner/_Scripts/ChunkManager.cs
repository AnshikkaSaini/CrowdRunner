using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager instance;
    //Elements
    [SerializeField] private LevelSO[] levels;
     private GameObject finishLine;

    void Awake()
    {
        if (instance != null)
        {
           Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {   
       // CreateOrderedLevel();
       GenerateLevel();
        finishLine = GameObject.FindWithTag("FinishLine");

    }

    private void GenerateLevel()
    {
        int currentLevel = GetLevel();
        currentLevel = currentLevel % levels.Length;
        LevelSO level = levels[currentLevel];
        CreateLevel(level.chunks);
    }

    private void CreateLevel(Chunk[] levelChunks)
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
    
    public float GetFinishLineZ()
    {
        return finishLine.transform.position.z;
    }
    
    public int GetLevel()
    {
        return PlayerPrefs.GetInt("Level",0);
    }
}
