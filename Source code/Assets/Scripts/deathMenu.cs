using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deathMenu : MonoBehaviour {

    public Text deathScoreText;
    public Image bacgroundImg;

    public bool isShown = false;

    private float transition = 0.0f;
    

	// Use this for initialization
	void Start () {

        gameObject.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isShown)
            return;

        transition += Time.deltaTime;
        bacgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
	}

    public void toggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        deathScoreText.text = ((int)score).ToString();
        isShown = true;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");


    }
}
