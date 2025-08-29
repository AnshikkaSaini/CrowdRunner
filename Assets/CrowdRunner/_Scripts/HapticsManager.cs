using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticsManager : MonoBehaviour
{

    void Start()
    {
        PlayerDetection.onDoorHit += Haptic;
        Enemy.onRunnerDie += Haptic;
        GameManager.onGameStateChanged += GameStateChanged; 
    }

    private void OnDestroy()
    {
        PlayerDetection.onDoorHit -= Haptic;
        Enemy.onRunnerDie -= Haptic;
        GameManager.onGameStateChanged -= GameStateChanged;
    }
    
    private void Haptic()
    {
        Taptic.Light();
    }

    private void GameStateChanged(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.LevelComplete)
        {
           Haptic();
        }
        else if (gameState == GameManager.GameState.GameOver)
        {
           Haptic();
        }
    }
}
