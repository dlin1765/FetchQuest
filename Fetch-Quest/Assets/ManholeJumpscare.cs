using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManholeJumpscare : MonoBehaviour
{
    [SerializeField] private GameObject RobotModel;
    private Transform originalParent;
    private Vector3 originalPosition;
    private Rigidbody robotRigidbody;

  
    void Start()
    {
        originalParent = RobotModel.transform.parent; 
        originalPosition = RobotModel.transform.localPosition; 
        robotRigidbody = RobotModel.GetComponent<Rigidbody>();
        if (robotRigidbody != null)
        {
            robotRigidbody.isKinematic = true;
        }
        RobotModel.SetActive(false);
        StartCoroutine(StartJumpScare());
    }

    private IEnumerator StartJumpScare()
    {
        yield return new WaitForSeconds(3);
        RobotModel.SetActive(true);
        RotateManhole();
    }

    private void RotateManhole()
    {
        if (robotRigidbody != null)
        {
            robotRigidbody.isKinematic = true; 
        }

        Vector3 worldPosition = RobotModel.transform.position; 

        RobotModel.transform.SetParent(null);
        transform.Rotate(new Vector3(90, 0, 0)); 

        RobotModel.transform.position = worldPosition; 
        RobotModel.transform.SetParent(originalParent); 

        if (robotRigidbody != null)
        {
            robotRigidbody.isKinematic = false; 
        }
    }
}
