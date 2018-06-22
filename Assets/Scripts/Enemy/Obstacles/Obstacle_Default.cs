using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Default : MonoBehaviour, IObstacle, IPooledObject {

    public float maxHP;
    public float curHP;
    public float speed;
    public float timeAllowedToExist;
    public float timeExisted = 0f;
    public int scoreValue = 30;

    private Rigidbody rb;

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

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        IProjectile projectile = collision.gameObject.GetComponent<IProjectile>();
        if (projectile != null) {
            curHP -= projectile.GetDamage();
            projectile.Die();
        }
    }

    public void CollideWithPlayer()
    {
        Die();
    }

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

    public void AddScore()
    {
        GameController._sharedInstance.AddScore(scoreValue);
    }
}
