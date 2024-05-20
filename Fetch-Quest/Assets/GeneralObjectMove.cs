using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObjectMove : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (state != GameStateManager.GameState.Playing)
        {
            //dont move
        }
        else
        {
            // move 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
