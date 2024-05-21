using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManholeJumpscare : MonoBehaviour
{
    [SerializeField] private GameObject RobotModel;
    [SerializeField] private float rotationDuration = 2.0f; // Duration for the rotation
    [SerializeField] private float riseHeight = 2.0f; // Height the robot should rise
    [SerializeField] private float riseDuration = 2.0f; // Duration for the robot rise

    private Transform originalParent;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 undergroundPosition;
    private Rigidbody robotRigidbody;

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
        if (state == GameStateManager.GameState.Intro)
        {
            //dont move
            Debug.Log("Intro happening");
        }
        else if (state == GameStateManager.GameState.Playing)
        {
            StartCoroutine(StartJumpScare());
            
        }
    }


    void Start()
    {
        originalParent = RobotModel.transform.parent;
        originalPosition = RobotModel.transform.position;
        originalRotation = RobotModel.transform.rotation;
        undergroundPosition = originalPosition - new Vector3(0, riseHeight, 0); 
        robotRigidbody = RobotModel.GetComponent<Rigidbody>();
        if (robotRigidbody != null)
        {
            robotRigidbody.isKinematic = true; 
        }
        RobotModel.SetActive(false);
       
    }

    private IEnumerator StartJumpScare()
    {
        yield return new WaitForSeconds(3);
        RobotModel.SetActive(true);
        StartCoroutine(RiseRobotSmoothly(riseHeight, riseDuration)); 
        yield return RotateManholeSmoothly(90, rotationDuration); 
    }

    private IEnumerator RotateManholeSmoothly(float angle, float duration)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(angle, 0, 0);

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation; 
    }

    private IEnumerator RiseRobotSmoothly(float height, float duration)
    {
        RobotModel.transform.SetParent(null); 

        Vector3 startPosition = undergroundPosition;
        Vector3 endPosition = originalPosition;
        Quaternion startRotation = RobotModel.transform.rotation;
        Quaternion endRotation = originalRotation;

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            RobotModel.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            RobotModel.transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        RobotModel.transform.position = endPosition; 
        RobotModel.transform.rotation = endRotation; 

       
        RobotModel.transform.SetParent(originalParent);

      
        if (robotRigidbody != null)
        {
            robotRigidbody.isKinematic = false;
        }
    }
}
