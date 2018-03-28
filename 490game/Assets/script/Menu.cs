using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public Text score = null;
    public Text text;
   
    public Text text1;

    public GameObject restartButton;
    // Update is called once per frame

    private void Start()
    {
        score.text = "0";
    }

    void Update () {

        score.text = enemyScript.kills.ToString();

        if (Player.playerIsDead||Player.MP <0)
        {
            Player.playerIsDead = true;
            enemyScript.speed = 0f;
            moveLeft.speed = 0f;
            Pause();
        }

        popUpText();
        
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
        enemyScript.kills = 0;
        Player.playerIsDead = false;
        enemyScript.speed = 2f;
        moveLeft.speed = 2f;
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
    public void popUpText()
    {
        if (enemyScript.kills > 0)
        {

            if (enemyScript.kills % 2 == 0)
            {
                text.text = "+1 ENERGY";
                text1.text = "";
            }
            else
            {
                text1.text = "+1 ENERGY";
                text.text = "";
            }
        }
        
    }
}
