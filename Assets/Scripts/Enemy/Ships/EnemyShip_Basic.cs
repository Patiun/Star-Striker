using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Behaviors for the basic enemy ship
/// Author: Greg Kilmer
/// </summary>
public class EnemyShip_Basic : MonoBehaviour,IObstacle,IPooledObject
{
    public float maxHP; //Max HP of the ship
    public float curHP; //Cur HP of the ship
    public float speed; //Cur spped of the sup
    public float timeAllowedToExist; //Time the ship is allowed to exist in the scene before going inactive
    public float timeExisted = 0f; //Time the ship has existed in the scene
    public int scoreValue; //Score the ship is worth

    private Rigidbody rb; //Reference to the RigidBody
    private GameController game; //Reference to the GameController singleton

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        game = GameController._sharedInstance;
        rb.velocity = transform.up * speed;
        curHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        timeExisted += Time.deltaTime;
        if (timeExisted >= timeAllowedToExist)
        {
            gameObject.SetActive(false);
        }
        if (curHP <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Drops a coin when shot down
    /// </summary>
    public void Drop()
    {
        ObjectPooler._sharedInstance.SpawnFromPool("Coins", transform.position, Quaternion.identity);
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
            AddScore();
            curHP -= projectile.GetDamage();
            projectile.Die();
        }
    }

    /// <summary>
    /// Handles what happens when the ship dies
    /// </summary>
    public void Die()
    {
        ObjectPooler._sharedInstance.SpawnFromPool("Explosion", transform.position, transform.rotation);
        Drop();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Handles what happens when the ship is spawned by the ObjectPooler
    /// </summary>
    public void OnObjectSpawn()
    {
        timeExisted = 0f;
        curHP = maxHP;
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        rb.velocity = transform.up * speed;
    }

    /// <summary>
    /// Adds the score of the ship to the player's score
    /// </summary>
    public void AddScore()
    {
        game.AddScore(scoreValue);
    }
}
