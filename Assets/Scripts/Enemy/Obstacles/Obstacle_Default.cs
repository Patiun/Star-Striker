using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the behavior of the default asteroid obstacle
/// Author: Greg Kilmer
/// </summary>
public class Obstacle_Default : MonoBehaviour, IObstacle, IPooledObject {

    public float maxHP; //Max HP of the obstacle
    public float curHP; //Current HP of the obstacle
    public float speed; //Speed the obstacle starts with
    public float timeAllowedToExist; //Time the obstacle is allowed to exist in the scene before going inactive
    public float timeExisted = 0f; //Time the obstacle has existed in the scene
    public int scoreValue; //Score the obstacle is worth
    public GameObject model; //Asteroid model for the object
    
    private Rigidbody rb; //Reference to the object's RigidBody

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
        curHP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
        timeExisted += Time.deltaTime;
        if (timeExisted >= timeAllowedToExist)
        {
            gameObject.SetActive(false);
        }
        if (curHP <= 0)
        {
            AddScore();
            Die();
        }
	}

    /// <summary>
    /// Handle what happens when the obstacle dies
    /// </summary>
    public void Die()
    {
        ObjectPooler._sharedInstance.SpawnFromPool("Explosion", transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        //If hit by a projectile
        IProjectile projectile = collision.gameObject.GetComponent<IProjectile>();
        if (projectile != null) {
            curHP -= projectile.GetDamage();
            projectile.Die();
        }
    }

    /// <summary>
    /// Handles what happens when the obstacle collides with the player
    /// </summary>
    public void CollideWithPlayer()
    {
        Die();
    }

    /// <summary>
    /// Handles what the obstacle does when it is spawned
    /// </summary>
    public void OnObjectSpawn()
    {
        model.transform.rotation = Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
        timeExisted = 0f;
        curHP = maxHP;
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        rb.velocity = transform.up * speed;
    }

    /// <summary>
    /// Adds the score of the obstacle to the players's score
    /// </summary>
    public void AddScore()
    {
        GameController._sharedInstance.AddScore(scoreValue);
    }
}
