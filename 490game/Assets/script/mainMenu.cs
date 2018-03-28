using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		
	}

    public void quit()
    {
        Application.Quit();
    }

    public void play()
    {
        enemyScript.kills = 0;
        Player.playerIsDead = false;
        Player.MP = 5;
        Time.timeScale = 1f;
        enemyScript.speed = 2f;
        moveLeft.speed = 2f;
        SceneManager.LoadScene("version1.0");
    }
}
