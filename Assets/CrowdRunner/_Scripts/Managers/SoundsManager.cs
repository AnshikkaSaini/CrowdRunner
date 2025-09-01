using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    /*---Sounds---*/
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource doorHitSound;
    [SerializeField] private AudioSource runnerDieSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameOverSound;
    [SerializeField] private AudioSource coinCollectedSound;
  
    void Start()
    {
        PlayerDetection.onDoorHit += PlayDoorHitSound;
        PlayerDetection.onCoinCollected += PlayCoinCollectedSound;
        GameManager.onGameStateChanged += GameStateChanged;
        Enemy.onRunnerDie += PlayRunnerDieSound;

    }

    private void OnDestroy()
    {
            PlayerDetection.onDoorHit -= PlayDoorHitSound;
            PlayerDetection.onCoinCollected -= PlayCoinCollectedSound;
            GameManager.onGameStateChanged -= GameStateChanged;
            Enemy.onRunnerDie -= PlayRunnerDieSound;
    }
    
    private void PlayDoorHitSound()
    {
        doorHitSound.Play();
    }

    private void PlayCoinCollectedSound()
    {
        
        coinCollectedSound.Play();
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

    public void DisableSounds()
    {
        buttonSound.volume = 0;
        doorHitSound.volume = 0;   
        runnerDieSound.volume = 0;    
        levelCompleteSound.volume = 0;
        gameOverSound.volume = 0;
        coinCollectedSound.volume = 0;
    }
    public void EnableSounds()
    {
        buttonSound.volume = 1;
        doorHitSound.volume = 1;   
        runnerDieSound.volume = 1;    
        levelCompleteSound.volume = 1;
        gameOverSound.volume = 1;  
        coinCollectedSound.volume = 1;
    }


}
