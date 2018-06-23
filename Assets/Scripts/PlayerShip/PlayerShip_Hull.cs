using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles collisions with the player's ship
/// Author: Greg Kilmer
/// </summary>
public class PlayerShip_Hull : MonoBehaviour {

    public GameObject shield;
    private GameController game; //Reference the GameController singleton

    public void Start()
    {
        game = GameController._sharedInstance; //Gather singleton once
    }

    public void OnCollisionEnter(Collision collision)
    {
        //If the player ship collides with an obstacle
        IObstacle obstacle = collision.gameObject.GetComponent<IObstacle>();
        if (obstacle != null)
        {
            obstacle.CollideWithPlayer();
            Die();
            return;
        }
        //If the player ship collides with a collectable
        ICollectable collectable = collision.gameObject.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.PickUp();
            return;
        }
    }

    /// <summary>
    /// Handles what happens when the player ship dies
    /// </summary>
    public void Die()
    {
        game.PlayerDeath(); 
        if (game.gameOver) {
            Debug.Log("You Lose!");
            gameObject.SetActive(false);
        }
    }

    public void ActivateShield()
    {
        shield.SetActive(true);
    }

    public void DeactivateShield()
    {
        shield.SetActive(false);
    }
}
