using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject countdownText, gameOverCanvas, progressCanvas, youWinCanvas; 

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
            //3 2 1 canvas
            progressCanvas.SetActive(true);
            countdownText.SetActive(true);
            StartCoroutine(StartCountDown());
            Debug.Log("Intro happening");
        }
        else if(state == GameStateManager.GameState.Playing)
        {
            progressCanvas.GetComponent<ProgressBarScript>().StartProgress();
        }
        else if (state == GameStateManager.GameState.Failure)
        {
            gameOverCanvas.SetActive(true);
        }
        else if(state == GameStateManager.GameState.Win)
        {
            youWinCanvas.SetActive(true);
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartCountDown()
    {
        yield return new WaitForSeconds(1f);
        countdownText.GetComponent<TextMeshProUGUI>().text = "2";
        yield return new WaitForSeconds(1f);
        countdownText.GetComponent<TextMeshProUGUI>().text = "1";
        yield return new WaitForSeconds(1f);
        countdownText.GetComponent<TextMeshProUGUI>().text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownText.SetActive(false);
    }

    
}
