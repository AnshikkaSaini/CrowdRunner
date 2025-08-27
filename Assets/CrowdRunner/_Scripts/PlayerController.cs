using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] private CrowdSystem crowdsystem;
    [SerializeField] private PlayerAnimator playerAnimator;
    
    [Header("Settings")] 
    [SerializeField] private float moveSpeed;

    private bool canMove;

    [SerializeField] private float roadWidth;
    
    [Header("Control")] 
    [SerializeField] private float slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    private void Awake()
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
        GameManager.onGameStateChanged += GameStateChangedCallBack;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallBack;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            MoveForward();
            ManageControl();
        
        }

    }

    private void StartMoving()
    {
        canMove = true;
        playerAnimator.Run();
    }

    private void StopMoving()
    {
        canMove = false;
        playerAnimator.Idle();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * (moveSpeed * Time.deltaTime);
        
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            // Difference in X from initial click
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
            xScreenDifference /= Screen.width;   // normalize
            xScreenDifference *= slideSpeed;     // scale by sensitivity

            // Apply drag offset relative to the starting position
            float targetX = clickedPlayerPosition.x + xScreenDifference;

            // Clamp inside road
            float minX = -roadWidth / 2 + crowdsystem.GetCrowdRadius();
            float maxX = roadWidth / 2 - crowdsystem.GetCrowdRadius();
            targetX = Mathf.Clamp(targetX, minX, maxX);

            // Update player X position
            Vector3 position = transform.position;
            position.x = targetX;
            transform.position = position;
        }
    }

    private void GameStateChangedCallBack(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Game)
        {
            StartMoving();
        }
        else if (gameState == GameManager.GameState.GameOver)
        {
            StopMoving();
        }

    }


}
    

