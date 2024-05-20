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
                StartCoroutine(StartCutscene());
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

    private IEnumerator StartCutscene()
    {
        Debug.Log("3");
        yield return new WaitForSeconds(1f);
        Debug.Log("2");
        yield return new WaitForSeconds(1f);
        Debug.Log("1");
        yield return new WaitForSeconds(1f);
        Debug.Log("go");
        ChangeGameState(GameState.Playing);
    }
}
