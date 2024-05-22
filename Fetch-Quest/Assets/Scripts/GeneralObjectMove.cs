using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObjectMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 10.0f;
    [SerializeField] Vector3 targetPosition;

    private Coroutine moveRoutine;
    private void Awake()
    {
        GameStateManager.gameStateChanged += GameStateManagerGameStateChanged;
        
    }

    private void Start()
    {
        targetPosition = new Vector3(transform.position.x, transform.position.y, -15.5f);
        moveRoutine = StartCoroutine(MoveObject());

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
            if(moveRoutine != null)
            {
                Debug.Log("should stop");
                StopCoroutine(moveRoutine);
            }
            else
            {
                Debug.Log("routine is null");
            }
        }
        else
        {
            // move
            moveRoutine = StartCoroutine(MoveObject());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator MoveObject()
    {
        if(GameStateManager.Instance.currentGameState == GameStateManager.GameState.Playing)
        {
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
            Destroy(this.gameObject);
        }
    }
}
