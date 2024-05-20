using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuildingManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Building1Spawn, Building2Spawn;
    public GameObject BuildingObject;
    public GameObject RoadObject;

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
        if(state != GameStateManager.GameState.Playing)
        {
            //dont move
        }
        else
        {
            // move 
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
