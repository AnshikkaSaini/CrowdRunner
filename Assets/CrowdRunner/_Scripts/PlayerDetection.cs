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
            Debug.Log(typeof(GameManager.GameState));
             DetectColliders();
        }

    }

    private void DetectColliders()
    { 
     
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position,crowdSystem.GetCrowdRadius()+ 5);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
           
            if (detectedColliders[i].TryGetComponent(out Doors doors))
            {
                int bonusAmount = doors.GetBonusAmount(transform.position.x);
                BonusType bonusType =    doors.GetBonusType(transform.position.x);

                doors.Disable();
                onDoorHit?.Invoke();
                crowdSystem.ApplyBonus(bonusType, bonusAmount);
            }
            else if (detectedColliders[i].tag == "FinishLine")
            {
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+ 1);
                GameManager.instance.SetGameState(GameManager.GameState.LevelComplete);
                    
                //SceneManager.LoadScene(0);
            }
            
            else if(detectedColliders[i].tag == "Coins")
            {
                
                Destroy(detectedColliders[i].gameObject);

                DataManager.instance.AddCoins(1);
            }

        }
    }
}
