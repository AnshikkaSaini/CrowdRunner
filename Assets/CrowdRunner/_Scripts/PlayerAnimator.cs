using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Transform runnersparent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Run()
    {
        for (int i = 0; i < runnersparent.childCount; i++)
        {
            Transform runner = runnersparent.GetChild(i);
            Animator runnerAnimator = runner.GetComponent<Animator>();
            
            runnerAnimator.Play("Run");
        }
    }

    public void Idle()
    {
        for (int i = 0; i < runnersparent.childCount; i++)
        {
            Transform runner = runnersparent.GetChild(i);
            Animator runnerAnimator = runner.GetComponent<Animator>();
            
            runnerAnimator.Play("Idle");
        }
        
    }
}
