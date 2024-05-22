using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject Lane1, Lane2, Lane3, Lane4;
    [SerializeField] private GameObject SewerHole, Car, TrainGate, GlassPaneBoys, Pedestrian;

    private List<GameObject> ObstacleList;
    private List<GameObject> LaneObj;
    private List<LaneState> LaneList;
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
            StartCoroutine(SpawnObstacles());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ObstacleList = new List<GameObject>();
        LaneList = new List<LaneState>();
        LaneObj = new List<GameObject>();
        LaneObj.Add(Lane1);
        LaneObj.Add(Lane2);
        LaneObj.Add(Lane3);
        LaneObj.Add(Lane4);

        LaneList.Add(lane1State);
        LaneList.Add(lane2State);
        LaneList.Add(lane3State);
        LaneList.Add(lane4State);

        ObstacleList.Add(SewerHole);
        ObstacleList.Add(Car);
        ObstacleList.Add(TrainGate);
        ObstacleList.Add(GlassPaneBoys);
        ObstacleList.Add(Pedestrian);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnObstacles()
    {
        float offset = 1.75f;
        while (GameStateManager.Instance.currentGameState == GameStateManager.GameState.Playing) 
        {
            int whichObstacleNum = Random.Range(0, 5);
            int whichLane = Random.Range(0, 4);
            if(LaneList[whichLane] == LaneState.Free)
            {
                switch (whichObstacleNum)
                {
                    case 0:
                        
                        if(Random.Range(0, 100) <= 20)
                        {
                            Debug.Log("sewer supposed to spawn");
                            LaneList[whichLane] = LaneState.Jumpable;
                            StartCoroutine(FreeUpLane(whichLane));
                            Instantiate(SewerHole, LaneObj[whichLane].transform.position, Quaternion.identity);
                        }
                        
                        break;
                    case 1:
                        if (Random.Range(0, 100) <= 10)
                        {
                            Debug.Log("Car supposed to spawn");
                            if (whichLane <= 1)
                            {
                                LaneList[0] = LaneState.Avoidable;
                                LaneList[1] = LaneState.Avoidable;
                                StartCoroutine(FreeUpLane(0));
                                StartCoroutine(FreeUpLane(1));
                                //Instantiate(Car, new Vector3(LaneObj[0].transform.position.x, LaneObj[0].transform.position.y, LaneObj[0].transform.position.z), Quaternion.identity);
                                Instantiate(Car, new Vector3(LaneObj[0].transform.position.x+25.6f, LaneObj[0].transform.position.y, LaneObj[0].transform.position.z), Quaternion.identity, LaneObj[0].transform);
                            }
                            else
                            {
                                LaneList[2] = LaneState.Avoidable;
                                LaneList[3] = LaneState.Avoidable;
                                StartCoroutine(FreeUpLane(2));
                                StartCoroutine(FreeUpLane(3));
                                //Instantiate(Car, new Vector3(LaneObj[2].transform.position.x, LaneObj[2].transform.position.y, LaneObj[2].transform.position.z), Quaternion.identity);
                                Instantiate(Car, new Vector3(LaneObj[2].transform.position.x+14.04f, LaneObj[2].transform.position.y, LaneObj[2].transform.position.z), Quaternion.identity, LaneObj[2].transform);
                            } 
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                yield return null;
            }
            else
            {
                Debug.Log("no free lanes");
            }
            yield return null;
        }
    }
    
    // every frame theres a chance to spawn an obstacle on any of the lanes.
    // every obstacle has a percent chance of succeeding 
    // they can only spawn in lanes that are free 
    // 

    private IEnumerator FreeUpLane(int laneNum)
    {
        yield return new WaitForSeconds(35f / 10f);
        LaneList[laneNum] = LaneState.Free;
    }

}
        
