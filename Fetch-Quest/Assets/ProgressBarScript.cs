using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour
{
    [SerializeField] private Scrollbar Bar;
    public float progressSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartProgress()
    {
        StartCoroutine(IncreaseProgress());
    }

    private IEnumerator IncreaseProgress()
    {
        float sizeNum = 0f;
        
        while (GameStateManager.Instance.currentGameState == GameStateManager.GameState.Playing)
        {
            sizeNum += progressSpeed * Time.deltaTime;
            Bar.size = sizeNum;
            yield return null;
            if(Bar.size == 1)
            {
                GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.Win);
            }
        }
    }
}
