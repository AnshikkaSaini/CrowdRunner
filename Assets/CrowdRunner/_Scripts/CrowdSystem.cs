using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    //Elements
    [SerializeField] private Transform runnersParent;
    
    
    //Settings
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    private void Awake()
    {
        
        PlaceRunners();
    }

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaceRunners()
    {
     
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Vector3 childLocalPosition = GetRunnerLocalPosition(i);
            runnersParent.GetChild(i).localPosition = childLocalPosition;
        } 
    }

    private Vector3 GetRunnerLocalPosition(int index)
    {
      
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        Debug.Log( x);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);
        return new Vector3(x, 0, z);
    }


}
