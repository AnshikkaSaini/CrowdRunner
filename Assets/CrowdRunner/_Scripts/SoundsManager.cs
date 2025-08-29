using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    /*---Sounds---*/
    [SerializeField] private AudioSource doorHitSound;
    [SerializeField] private AudioSource runnerDieSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameOverSound;
  
    void Start()
    {
        PlayerDetection.onDoorHit += PlayDoorHitSound;
        GameManager.onGameStateChanged += GameStateChanged;
        Enemy.onRunnerDie += PlayRunnerDieSound;

    }

    private void OnDestroy()
    {
            PlayerDetection.onDoorHit -= PlayDoorHitSound;
            GameManager.onGameStateChanged -= GameStateChanged;
            Enemy.onRunnerDie -= PlayRunnerDieSound;
    }
    
    private void PlayDoorHitSound()
    {
        doorHitSound.Play();
    }

    private void GameStateChanged(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.LevelComplete)
        {
            levelCompleteSound.Play();
        }
        else if (gameState == GameManager.GameState.GameOver)
        {
            gameOverSound.Play();
        }
    }

    private void PlayRunnerDieSound()
    {
        runnerDieSound.Play();
    }


}
