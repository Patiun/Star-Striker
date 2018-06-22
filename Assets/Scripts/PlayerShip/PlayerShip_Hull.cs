using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip_Hull : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        IObstacle obstacle = collision.gameObject.GetComponent<IObstacle>();
        if (obstacle != null)
        {
            obstacle.CollideWithPlayer();
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("You Lose!");
        gameObject.SetActive(false);
    }
}
