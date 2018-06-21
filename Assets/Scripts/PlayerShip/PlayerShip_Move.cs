using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip_Move : MonoBehaviour {

    public float maxTiltAmount;
    public float maxBoostStrength;
    public float autoDampenRate;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
    public void Boost(float amnt)
    {
        if (amnt == 0)
        {
            rb.velocity = rb.velocity * autoDampenRate * Time.fixedDeltaTime;
        } else
        {
            rb.AddForce(transform.right * amnt * maxBoostStrength);
        }
        Tilt(amnt);
    }

    private void Tilt(float amnt)
    {
        transform.rotation = Quaternion.Euler(0f, -maxTiltAmount * amnt, 0f);
    }
}
