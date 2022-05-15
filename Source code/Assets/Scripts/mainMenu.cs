using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {


    public Text highscoreText;
	// Use this for initialization
	void Start () {
        highscoreText.text = "Highscore: " + (int)PlayerPrefs.GetFloat("Highscore");
		
	}
	

    public void toGame()
    {

        SceneManager.LoadScene("GameScene");
    }

    public void sair()
    {

        Application.Quit();
    }
}
