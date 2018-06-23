using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Behaviors for the basic enemy ship
/// Author: Greg Kilmer
/// </summary>
public class EnemyShip_Basic : Abstract_EnemyShip,IObstacle,IPooledObject
{
    public bool canSpawnMine;
    public float mineRate;
    public float distanceBehind;

    private float timeForNextMine;

    // Use this for initialization
    void Start()
    {
        base.Init();
        timeForNextMine = Time.time;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (canSpawnMine) {
            if (Time.time >= timeForNextMine)
            {
                LayMine();
            }
        }
    }

    public void LayMine()
    {
        Vector3 pos = transform.position;
        pos.y += distanceBehind;
        ObjectPooler._sharedInstance.SpawnFromPool("Mine_Basic", pos,Quaternion.identity);
        timeForNextMine = Time.time + 1f / mineRate;
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
        timeForNextMine = Time.time;
    }

    /// <summary>
    /// Adds the score of the ship to the player's score
    /// </summary>
    public void AddScore()
    {
        base.game.AddScore(scoreValue);
    }
}
