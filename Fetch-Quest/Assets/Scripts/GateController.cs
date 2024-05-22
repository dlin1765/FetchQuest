using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Gate;

    private void Awake()
    {
        GameStateManager.gameStateChanged += GameStateManagerGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.gameStateChanged -= GameStateManagerGameStateChanged;
    }

    private void GameStateManagerGameStateChanged(GameStateManager.GameState state)
    {
        if (state == GameStateManager.GameState.Intro)
        {
            //dont move
            Debug.Log("Intro happening");
        }
        else if (state == GameStateManager.GameState.Playing)
        {
            Gate.GetComponent<Animator>().SetTrigger("StartGame");

        }
    }
    void Start()
    {
        if(GameStateManager.Instance.currentGameState == GameStateManager.GameState.Playing)
        {
            Gate.GetComponent<Animator>().SetTrigger("StartGame");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
