using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private float score = 0;
    private int nivel = 1;
    private int nivelMax = 10;
    private int proxNivel = 10;
    private int inicia = 0;
    public Text scoreText;
    public deathMenu deathMenu;
    private bool morto = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	 void Update () {


        if (morto)
            return;

        if (score >= proxNivel)
            LevelUp();

        if (inicia > 120)
            setScore(Time.deltaTime); //função criada para definir o score. Contém o contador original de tempo, mais a pontuação obtida com as gemas (ver script PlayerMotor).
        else
            inicia++;

        scoreText.text = ((int)score).ToString();
        
    }

     void LevelUp()
    {

        if (nivel == nivelMax)
            return;

        proxNivel *= 2;
        nivel++;

       GetComponent<PlayerMotor>().setSpeed(nivel);

    }
    public void onDeath()
    {
        morto = true;

        if(PlayerPrefs.GetFloat("Highscore")<score)
        PlayerPrefs.SetFloat("Highscore",score);

        deathMenu.toggleEndMenu(score);
    }

    public void setScore(float add)
    {

        score += add; 
    }
}
