using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    #region Singleton
    public static GameController _sharedInstance;
    void Awake()
    {
        _sharedInstance = this;
    }
    #endregion

    public int currentWave;
    public int maxLives;
    public int curLives;
    public int score;
    public bool gameOver;
    public List<Image> lives;
    public Text scoreText;
    public Text waveText;

    private void Update()
    {
        if (Input.GetAxis("Escape") != 0)
        {
            Application.Quit();
        }   
    }

    private void Start()
    {
        curLives = maxLives;
    }

    public void WaveOver()
    {
        waveText.text = "Next Wave Incoming";
    }

    public void WaveStart()
    {
        currentWave++;
        waveText.text = "Wave " + currentWave;
    }

    public void PlayerDeath()
    {
        curLives--;
        lives[curLives].enabled = false;
        if (curLives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        waveText.text = "Game Over";
        Debug.Log("Game Over!");
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
