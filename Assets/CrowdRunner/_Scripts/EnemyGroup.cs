using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField]private int amount;
    //Settings
    
    [SerializeField] private float radius;
    [SerializeField] private float angle;
    
    void Start()
    {
        GenerateEnemyGroup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateEnemyGroup()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 enemyLocalPosition = GetRunnerLocalPosition(i);
            Vector3 enemyWorldPosition = transform.TransformPoint(enemyLocalPosition);
            Instantiate(enemyPrefab, enemyWorldPosition, Quaternion.identity,transform);
        }
    }
    
    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);
        return new Vector3(x, 0, z);
    }
}
