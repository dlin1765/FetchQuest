using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuildingManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Building1Spawn, Building2Spawn, RoadSpawn;
    [SerializeField] private GameObject BuildingGroup;
    public GameObject BuildingObject1;
    public GameObject BuildingObject2;
    public GameObject BuildingObject3;
    public GameObject RoadObject;

    private bool isPlaying = false;
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
        if(state == GameStateManager.GameState.Intro)
        {
            //dont move
            Debug.Log("Intro happening");
        }
        else if(state == GameStateManager.GameState.Playing)
        {
            // move 
            isPlaying = true;
            StartCoroutine(SpawnRoads());
            StartCoroutine(SpawnBuildings());
            
        }
    }

    void Start()
    {
        Vector3 target1 = new Vector3(-83.79897f, 7.545255f, -12.98461f);
        Vector3 target2 = new Vector3(85.12291f, 7.545255f, 72.1f);
        Quaternion building2 = new Quaternion(0f, -180f, 0f, 0f);
        Instantiate(BuildingGroup, target1, Quaternion.identity);
        Instantiate(BuildingGroup, target2, building2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnRoads()
    {
        //10/12.25
        while (isPlaying)
        {
            yield return new WaitForSeconds(12.15f / 10f);
            Instantiate(RoadObject, RoadSpawn.transform.position, Quaternion.identity);
        }
    }

    private IEnumerator SpawnBuildings()
    {
        while (isPlaying)
        {
            Quaternion building2 = new Quaternion(0f, -180f, 0f, 0f);
            Instantiate(BuildingGroup, Building1Spawn.transform.position, Quaternion.identity);
            Instantiate(BuildingGroup, Building2Spawn.transform.position, building2);
            yield return new WaitForSeconds(60.5f / 10f);
        }
    }
}
