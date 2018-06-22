using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_EnemyShip : MonoBehaviour {

    public float maxHP; //Max HP of the ship
    public float curHP; //Cur HP of the ship
    public float speed; //Cur spped of the sup
    public float timeAllowedToExist; //Time the ship is allowed to exist in the scene before going inactive
    public float timeExisted = 0f; //Time the ship has existed in the scene
    public int scoreValue; //Score the ship is worth

    protected Rigidbody rb; //Reference to the RigidBody
    protected GameController game; //Reference to the GameController singleton

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        game = GameController._sharedInstance;
        rb.velocity = transform.up * speed;
        curHP = maxHP;
    }
	
	// Update is called once per frame
	public void Update () {
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
    /// Handles what happens when the ship dies
    /// </summary>
    public void Die()
    {
        ObjectPooler._sharedInstance.SpawnFromPool("Explosion", transform.position, transform.rotation);
        Drop();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// By default: Drops a coin when shot down
    /// </summary>
    public void Drop()
    {
        ObjectPooler._sharedInstance.SpawnFromPool("Coins", transform.position, Quaternion.identity);
    }
}
