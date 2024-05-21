using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject Lane1, Lane2, Lane3, Lane4;
    [SerializeField] private GameObject SewerHole, Car, TrainGate, GlassPaneBoys, Pedestrian;
    public enum LaneState
    {
        Free,
        Avoidable,
        Jumpable,
        Slideable 
    }
    public LaneState lane1State;
    public LaneState lane2State;
    public LaneState lane3State;
    public LaneState lane4State;

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
            // move 

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
