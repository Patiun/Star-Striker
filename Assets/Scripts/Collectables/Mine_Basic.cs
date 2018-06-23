using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_Basic : MonoBehaviour, IPooledObject, ICollectable
{

    public float speed; //Speed the healthpack floats down the screen
    public float timeAllowedToExist; //Time the healthpack is allowed to exist in the scene

    private float timeExisted = 0f; //The time the healthpack has existed in the scene
    private GameController game; //Reference to the GameController singleton
    private Rigidbody rb; //Refrence to the RigidBody

    // Use this for initialization
    void Start()
    {
        game = GameController._sharedInstance;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timeExisted += Time.deltaTime;
        if (timeExisted >= timeAllowedToExist)
        {
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Handles what happens when the coin is picked up
    /// </summary>
    public void PickUp()
    {
        game.PlayerDeath();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Handles what happens when the coin is spawned by the ObjectPooler
    /// </summary>
    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * -speed;
        timeExisted = 0f;
    }
}
