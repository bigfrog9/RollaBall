using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TwoMenuClick : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
