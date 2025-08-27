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
    
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI levelText;
    void Start()
    {
        progressBar.value = 0;
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
  
        
        levelText.text = "Level " +(ChunkManager.instance.GetLevel() + 1);
        Debug.Log("Current Level: " + ChunkManager.instance.GetLevel() );
        
        GameManager.onGameStateChanged += GameStateChangedCallBack;
        
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
    private void GameStateChangedCallBack(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.GameOver)
        {
          ShowGameOver();
        }
        
    }
}
