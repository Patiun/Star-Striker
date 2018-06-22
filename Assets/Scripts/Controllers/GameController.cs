using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool gameOver;

    private void Start()
    {
        curLives = maxLives;
    }

    public void WaveOver()
    {

    }

    public void WaveStart()
    {
        currentWave++;
    }

    public void PlayerDeath()
    {
        curLives--;
        if (curLives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }
}
