using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip_Shoot : MonoBehaviour {

    public float fireRate;
    public float muzzleVelocity;
    public Transform gunBarrel;

    private float timeLastFired;
    private ObjectPooler objectPooler;

	// Use this for initialization
	void Start () {
        objectPooler = ObjectPooler._sharedInstance;
        timeLastFired = Time.time - fireRate;
	}

    public void Shoot()
    {
        if (timeLastFired + fireRate < Time.time)
        {
            GameObject newBullet = objectPooler.SpawnFromPool("PlayerBullets",gunBarrel.transform.position,Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = transform.up * muzzleVelocity;
            timeLastFired = Time.time;
        }
    }
}
