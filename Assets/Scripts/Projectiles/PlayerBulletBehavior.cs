using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the behavior of the player's bullets
/// Uses IPooledObject and IProjectile
/// Author: Greg Kilmer
/// </summary>
public class PlayerBulletBehavior : MonoBehaviour, IPooledObject, IProjectile {

    public int damage = 1; //Damage the bullet does: Defaulted to 1
    public float timeAllowedToExist; //Time the bullet is allowed to exist in the scene before being set inactive
    public float timeExisted = 0f; //Tracks the amount of time the bullet has been active in the scene
	
	// Update is called once per frame
	void Update () {
        //Increment timeExisted and if it is greater than it is allowed to exist, set it inactive
        timeExisted += Time.deltaTime;
        if (timeExisted >= timeAllowedToExist)
        {
            gameObject.SetActive(false);
        }
	}

    /// <summary>
    /// What the bullet does when it is spawned by the objectPooler
    /// </summary>
    public void OnObjectSpawn()
    {
        //Reset the bullet
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        timeExisted = 0f;
    }

    /// <summary>
    /// Returns the amount of damage the bullet does
    /// </summary>
    /// <returns>The amount of damage</returns>
    public int GetDamage()
    {
        return damage;
    }

    /// <summary>
    /// Handles what happens when a bullet dies
    /// </summary>
    public void Die()
    {
        //Player particle effect
        ObjectPooler._sharedInstance.SpawnFromPool("PlayerBulletDeath", transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
