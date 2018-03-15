using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject restartButton;
    // Update is called once per frame
    void Update () {

        if (Player.playerIsDead||Player.MP <0)
        {
            Player.playerIsDead = true;
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

    public void reStart()
    {
        Player.playerIsDead = false;
        Player.MP = 5;
        Time.timeScale = 1f;
        SceneManager.LoadScene("version1.0");
        restartButton.SetActive(false);
    }

    public void Pause()
    {
        if (Player.playerIsDead||Player.MP<0)
        {
            pauseMenuUI.SetActive(true);
            resumeButton.SetActive(false);
            restartButton.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 1f;
            isPaused = true;
        }
        else
        {
            
            pauseMenuUI.SetActive(true);
            restartButton.SetActive(false);
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
