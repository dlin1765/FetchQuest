using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMover : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lastBuilding;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lastBuilding.transform.position.z <= 2.6)
        {
            Destroy(this.gameObject);
        }

    }

    // when the gamestate is playing, move towards the camera, after the last building passes by the camera kill yourself
    // create an empty game object on the end of the prefab and check the position of it
}
