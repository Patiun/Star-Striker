using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HealthPack behavior
/// Author: Greg Kilmer
/// </summary>
public class HealthPack : MonoBehaviour, IPooledObject, ICollectable {

    public int healthAmount = 1; //Amount of health gained for picking this item up, default to 1
    public float speed; //Speed the healthpack floats down the screen
    public float timeAllowedToExist; //Time the healthpack is allowed to exist in the scene

    private float timeExisted = 0f; //The time the healthpack has existed in the scene
    private GameController game; //Reference to the GameController singleton
    private Rigidbody rb; //Refrence to the RigidBody

	// Use this for initialization
	void Start () {
        game = GameController._sharedInstance;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        timeExisted += Time.deltaTime;
        if (timeExisted >= timeAllowedToExist)
        {
            gameObject.SetActive(false);
        }
	}

    /// <summary>
    /// Handles what happens when the healthpack is picked up
    /// </summary>
    public void PickUp()
    {
        game.AddLife(healthAmount);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Handles what happens when the healthpack is spawned
    /// </summary>
    public void OnObjectSpawn()
    {
        timeExisted = 0f;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * -speed;
    }
}
