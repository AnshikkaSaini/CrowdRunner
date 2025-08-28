using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject  levelCompletePanel;
    
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI levelText;
    void Start()
    {
        progressBar.value = 0;
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
  
        
        levelText.text = "Level " +(ChunkManager.instance.GetLevel()+1);
        Debug.Log("Current Level: " + ChunkManager.instance.GetLevel() );
    }
    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallBack;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgressBar();
    }
    private void GameStateChangedCallBack(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.GameOver)
        {
          ShowGameOver();
        }
        else if (gameState == GameManager.GameState.LevelComplete)
        {
            ShowLevelComplete();
        }
        
    }

    public void retryButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowGameOver()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void PlayButtonPressed()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Game);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void UpdateProgressBar()
    {
        if (!GameManager.instance.isGameState())
        {
            return;
        }
        float progress = PlayerController
                        .instance.transform.position.z / ChunkManager.
                        instance.GetFinishLineZ();

        progressBar.value = progress;

    }

    private void ShowLevelComplete()
    {
        gamePanel.SetActive(false);
        levelCompletePanel.SetActive(true);
    }
}
