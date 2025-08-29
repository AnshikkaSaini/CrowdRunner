using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private CrowdSystem crowdSystem;
    /*---Events---*/
    public static Action onDoorHit;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (GameManager.instance.IsGameState())
        {
             DetectDoors();
        }

    }

    private void DetectDoors()
    {
        Collider[] dectectedColliders = Physics.OverlapSphere(transform.position, 1);

        for (int i = 0; i < dectectedColliders.Length; i++)
        {
            if (dectectedColliders[i].TryGetComponent(out Doors doors))
            {
                int bonusAmount = doors.GetBonusAmount(transform.position.x);
                BonusType bonusType =    doors.GetBonusType(transform.position.x);

                doors.Disable();
                onDoorHit?.Invoke();
                crowdSystem.ApplyBonus(bonusType, bonusAmount);
            }
            
            else if (dectectedColliders[i].tag == "FinishLine")
            {
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+ 1);
                GameManager.instance.SetGameState(GameManager.GameState.LevelComplete);
                    
                //SceneManager.LoadScene(0);
            }
        }
    }
}
