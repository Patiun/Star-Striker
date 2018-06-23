using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Controller for the game. Uses a singleton model.
/// Author: Greg Kilmer
/// </summary>
public class GameController : MonoBehaviour {

    #region Singleton
    public static GameController _sharedInstance;
    void Awake()
    {
        _sharedInstance = this;
    }
    #endregion

    public int currentWave; //Current Wave number
    public int maxLives; //Maximum lives the player can have
    public int curLives; //Amount of lives the player currently has
    public int score; //Score the player currently has
    public bool gameOver; //Whether or not the game is over
    //UI Elements
    public List<Image> lives; //Images representing player lives
    public Text scoreText; //Text to show the score
    public Text waveText; //Text to show the wave

    private void Update()
    {
        if (Input.GetAxis("Escape") != 0)
        {
            //Add are you sure
            SceneManager.LoadScene(0);
        }   
    }

    private void Start()
    {
        curLives = maxLives;
    }

    /// <summary>
    /// Handles what happens when a wave ends
    /// </summary>
    public void WaveOver()
    {
        waveText.text = "Next Wave Incoming";
    }

    /// <summary>
    /// Handles what happens when a wave starts
    /// </summary>
    public void WaveStart()
    {
        currentWave++;
        waveText.text = "Wave " + currentWave;
    }

    /// <summary>
    /// Handles what happens when the player ship dies
    /// </summary>
    public void PlayerDeath()
    {
        curLives--;
        lives[curLives].enabled = false;
        if (curLives <= 0)
        {
            GameOver();
        }
    }

    /// <summary>
    /// Handles what happens when the game ends
    /// </summary>
    public void GameOver()
    {
        gameOver = true;
        waveText.text = "Game Over";
    }

    /// <summary>
    /// Adds amount to the player's score
    /// </summary>
    /// <param name="amount">amount to add</param>
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// Adds amount to the curLives
    /// </summary>
    /// <param name="amount"></param>
    public void AddLife(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            curLives++;
            if (curLives > maxLives)
            {
                curLives = maxLives;
            }
            lives[curLives-1].enabled = true;
        }
    }
}
