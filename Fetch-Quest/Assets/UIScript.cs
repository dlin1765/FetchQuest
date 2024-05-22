using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayAgain()
    {
        SceneManager.LoadScene("Danny Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
