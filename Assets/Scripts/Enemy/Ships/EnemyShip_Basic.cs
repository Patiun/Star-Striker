using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip_Basic : MonoBehaviour,IObstacle,IPooledObject
{
    public float maxHP;
    public float curHP;
    public float speed;
    public float timeAllowedToExist;
    public float timeExisted = 0f;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
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

    public void CollideWithPlayer()
    {
        Die();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CollideWithPlayer();
        }
        else
        {
            IProjectile projectile = collision.gameObject.GetComponent<IProjectile>();
            curHP -= projectile.GetDamage();
            projectile.Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void OnObjectSpawn()
    {
        timeExisted = 0f;
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        rb.velocity = transform.up * speed;
    }
}
