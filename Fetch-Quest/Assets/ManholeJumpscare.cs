using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManholeJumpscare : MonoBehaviour
{
    [SerializeField] private GameObject RobotModel;
    // Start is called before the first frame update
    void Start()
    {
        RobotModel.SetActive(false);
        StartCoroutine(StartJumpScare());
    }
    
    // Update is called once per frame

    void Update()
    {
        
    }
    private IEnumerator StartJumpScare()
    {
        yield return new WaitForSeconds(3);
        RobotModel.SetActive(true);
    } 

}
