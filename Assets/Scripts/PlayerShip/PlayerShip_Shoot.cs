using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the ability of the player's ship to shoot.
/// Author: Greg Kilmer
/// </summary>
public class PlayerShip_Shoot : MonoBehaviour {

    public float fireRate; //Number of shots per second
    public float muzzleVelocity; //Speed the bullet leaves the ship
    public Transform gunBarrel; //Location the bullet leaves the ship from

    private float timeLastFired; //Time the last bullet was fired
    private ObjectPooler objectPooler; //Reference to the ObjectPooler singleton

	// Use this for initialization
	void Start () {
        objectPooler = ObjectPooler._sharedInstance;
        timeLastFired = Time.time - 1f/fireRate;
	}

    /// <summary>
    /// Fire a bullet
    /// </summary>
    public void Shoot()
    {
        //Check if the ship can shoot
        if (timeLastFired + 1f/fireRate < Time.time)
        {
            GameObject newBullet = objectPooler.SpawnFromPool("PlayerBullets",gunBarrel.transform.position,Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = transform.up * muzzleVelocity;
            timeLastFired = Time.time;
        }
    }
}
