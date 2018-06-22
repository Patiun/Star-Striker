using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Behaviors for the basic enemy ship
/// Author: Greg Kilmer
/// </summary>
public class EnemyShip_Basic : Abstract_EnemyShip,IObstacle,IPooledObject
{
    // Use this for initialization
    void Start()
    {
        base.Init();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    /// <summary>
    /// Handles what the ship does if it collides with a player
    /// </summary>
    public void CollideWithPlayer()
    {
        ObjectPooler._sharedInstance.SpawnFromPool("Explosion", transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        //If hit by a projectile
        IProjectile projectile = collision.gameObject.GetComponent<IProjectile>();
        if (projectile != null)
        {
            curHP -= projectile.GetDamage();
            if (curHP <= 0)
            {
                AddScore();
                Die();
            }
            projectile.Die();
        }
    }

    /// <summary>
    /// Handles what happens when the ship is spawned by the ObjectPooler
    /// </summary>
    public void OnObjectSpawn()
    {
        base.Init();
    }

    /// <summary>
    /// Adds the score of the ship to the player's score
    /// </summary>
    public void AddScore()
    {
        base.game.AddScore(scoreValue);
    }
}
