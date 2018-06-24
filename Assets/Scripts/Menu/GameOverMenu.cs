using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public TMP_Text highscoreText;
    public TMP_Text newHighscoreText;
    public TMP_Text oldHighscoreText;

    private int currentHighscore;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver(int score)
    {
        currentHighscore = PlayerPrefs.GetInt("Highscore");
        if (currentHighscore == 0)
        {
            oldHighscoreText.enabled = false;
        }
        gameObject.SetActive(true);
        if (score > currentHighscore)
        {
            newHighscoreText.text = "NEW HIGH SCORE";
            oldHighscoreText.text = currentHighscore.ToString();
            highscoreText.text = score.ToString();
            PlayerPrefs.SetInt("Highscore", score);
        } else
        {
            newHighscoreText.text = "BEST SCORE";
            oldHighscoreText.enabled = false;
            highscoreText.text = currentHighscore.ToString();
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
