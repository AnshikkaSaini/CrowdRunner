using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private GameState gameState;

    public static Action <GameState> onGameStateChanged;

    public enum GameState
    {
        Menu,
        Game,
        LevelComplete,
        GameOver
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

   
    void Update()
    {
        
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);
    }

    public bool isGameState()
    {
        return gameState == GameState.Game;
    }
}
