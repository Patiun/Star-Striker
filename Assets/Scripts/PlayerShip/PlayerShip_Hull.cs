using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip_Hull : MonoBehaviour {

    private GameController game;

    public void Start()
    {
        game = GameController._sharedInstance;
    }

    public void OnCollisionEnter(Collision collision)
    {
        IObstacle obstacle = collision.gameObject.GetComponent<IObstacle>();
        if (obstacle != null)
        {
            obstacle.CollideWithPlayer();
            game.PlayerDeath();
            Die();
        }
    }

    public void Die()
    {
        if (game.gameOver) {
            Debug.Log("You Lose!");
            gameObject.SetActive(false);
        }
    }
}
