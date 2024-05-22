using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLane : MonoBehaviour
{
    // Start is called before the first frame update

    public ObstacleManager.LaneState currentLaneState;

    void Start()
    {
        currentLaneState = ObstacleManager.LaneState.Free;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacle(GameObject obby, int obstacleInt)
    {
        //Instantiate(obby)
    }

}
