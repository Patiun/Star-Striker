using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Default : MonoBehaviour, IObstacle {

    public float speed;
    public float timeAllowedToExist;
    public float timeExisted = 0f;

    private Rigidbody rb;
    private Renderer rend;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
        timeExisted += Time.deltaTime;
        if (timeExisted >= timeAllowedToExist)
        {
            gameObject.SetActive(false);
        }
	}

    public void CollideWithPlayer()
    {
        gameObject.SetActive(false);
    }
}
