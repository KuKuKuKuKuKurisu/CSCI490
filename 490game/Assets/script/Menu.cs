using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject resumeButton;
	// Update is called once per frame
	void Update () {

        if (Player.playerIsDead||Player.MP <0)
        {
            Pause();
        }
        
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        if (Player.playerIsDead||Player.MP<0)
        {
            resumeButton.SetActive(false);
            pauseMenuUI.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 1f;
            isPaused = true;
        }
        else
        {
            pauseMenuUI.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0f;
            isPaused = true;
        }
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
