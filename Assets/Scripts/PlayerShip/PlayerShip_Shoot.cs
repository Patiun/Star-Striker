using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip_Shoot : MonoBehaviour {

    public float fireRate;
    public float muzzleVelocity;
    public Transform gunBarrel;
    public GameObject TEMP_bulletPrefab;

    private float timeLastFired;

	// Use this for initialization
	void Start () {
        timeLastFired = Time.time - fireRate;
	}

    public void Shoot()
    {
        if (timeLastFired + fireRate < Time.time)
        {
            GameObject newBullet = Instantiate(TEMP_bulletPrefab);
            newBullet.transform.position = gunBarrel.position;
            newBullet.GetComponent<Rigidbody>().velocity = transform.up * muzzleVelocity;
            timeLastFired = Time.time;
        }
    }
}
