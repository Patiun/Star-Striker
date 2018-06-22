using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip_Move : MonoBehaviour {

    public float maxTiltAmount;
    public float maxVelocity;
    public float autoDampenRate;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
    public void Boost(float amnt)
    {
        rb.velocity = transform.right * amnt * maxVelocity;
        Tilt(amnt);
    }

    private void Tilt(float amnt)
    {
        transform.rotation = Quaternion.Euler(0f, -maxTiltAmount * amnt, 0f);
    }
}
