using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticsManager : MonoBehaviour
{
    private bool haptics = true;
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
        if(haptics)
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

    public void DisableHaptic()
    {
        haptics = false;
    }
    public void EnableHaptic()
    {
        haptics = true;
    }

}
