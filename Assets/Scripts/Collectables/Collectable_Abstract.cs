using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable_Abstract : MonoBehaviour, IPooledObject, ICollectable
{

    public float speed; //Speed the healthpack floats down the screen
    public float timeAllowedToExist; //Time the healthpack is allowed to exist in the scene

    private float timeExisted = 0f; //The time the healthpack has existed in the scene
    protected GameController game; //Reference to the GameController singleton
    protected Rigidbody rb; //Refrence to the RigidBody

    // Use this for initialization
    void Start ()
    {
        Init();
    }
	
	// Update is called once per frame
	protected void Update () {
        timeExisted += Time.deltaTime;
        if (timeExisted >= timeAllowedToExist)
        {
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Initalizes the collectable
    /// </summary>
    protected void Init()
    {
        if (game == null)
        {
            game = GameController._sharedInstance;
        }
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        rb.velocity = transform.up * -speed;
        timeExisted = 0f;
    }

    /// <summary>
    /// Handles what happens when the collectible is picked up
    /// </summary>
    public void PickUp()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Handles what happens when the collectable is spawned by the object pooler
    /// </summary>
    public void OnObjectSpawn()
    {
        Init();
    }
}
