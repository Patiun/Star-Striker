using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour, IPooledObject, IProjectile {

    public int damage = 1;
    public float timeAllowedToExist;
    public float timeExisted = 0f;
	
	// Update is called once per frame
	void Update () {
        timeExisted += Time.deltaTime;
        if (timeExisted >= timeAllowedToExist)
        {
            gameObject.SetActive(false);
        }
	}

    public void OnObjectSpawn()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        timeExisted = 0f;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void Die()
    {
        ObjectPooler._sharedInstance.SpawnFromPool("PlayerBulletDeath", transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
