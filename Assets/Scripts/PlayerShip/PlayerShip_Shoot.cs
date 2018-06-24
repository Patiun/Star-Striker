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
    public int fireType = 1;
    public int ultimateFireType = 5;
    //public Transform gunBarrel; //Location the bullet leaves the ship from
    public Transform[] gunBarrels;

    private float timeLastFired; //Time the last bullet was fired
    private ObjectPooler objectPooler; //Reference to the ObjectPooler singleton
    private GameController game;

	// Use this for initialization
	void Start () {
        objectPooler = ObjectPooler._sharedInstance;
        game = GameController._sharedInstance;
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
            switch(fireType)
            {
                case 1:
                    FireBullet(0);
                    break;
                case 2:
                    FireBullet(1);
                    FireBullet(3);
                    break;
                case 3:
                    FireBullet(0);
                    FireBullet(2);
                    FireBullet(4);
                    break;
                case 4:
                    FireBullet(1);
                    FireBullet(2);
                    FireBullet(3);
                    FireBullet(4);
                    break;
                case 5:
                    FireBullet(0);
                    FireBullet(1);
                    FireBullet(2);
                    FireBullet(3);
                    FireBullet(4);
                    break;
            }

            timeLastFired = Time.time;
        }
    }

    public void FireBullet(int barrelIndex)
    {
        GameObject newBullet = objectPooler.SpawnFromPool("PlayerBullets", gunBarrels[barrelIndex].transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = transform.up * muzzleVelocity;
    }

    public void UpgradeFireType()
    {
        fireType++;
        if (fireType > ultimateFireType)
        {
            fireType = ultimateFireType;
        }
    }
}
