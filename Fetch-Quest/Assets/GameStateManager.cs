using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameStateManager Instance;
    public GameState currentGameState;

    public static event Action<GameState> gameStateChanged;

    public enum GameState
    {
        Intro,
        Playing,
        Failure,
        Win
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeGameState(GameState.Intro);
    }

    public void ChangeGameState(GameState targetGameState)
    {
        currentGameState = targetGameState;
        switch (targetGameState)
        {
            case GameState.Intro:
                break;
            case GameState.Playing:
                break;
            case GameState.Failure:
                break;
            case GameState.Win:
                break;
        }
        gameStateChanged?.Invoke(targetGameState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
