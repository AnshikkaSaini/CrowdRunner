using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    private bool isTarget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  SetTarget()
    {
        isTarget = true;
    }

    public bool IsTarget()
    {
        return isTarget;
    }
}
