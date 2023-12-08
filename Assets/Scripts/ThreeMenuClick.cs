using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThreeMenuClick : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(6);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
