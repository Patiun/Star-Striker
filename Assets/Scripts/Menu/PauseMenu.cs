using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public bool isPaused;

    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            gameObject.SetActive(true);
            isPaused = true;
        }
    }

    public void Resume()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            isPaused = false;
        }
    }

    public void ReturnToMainMenu()
    {
        //ADD Are you sure?
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
