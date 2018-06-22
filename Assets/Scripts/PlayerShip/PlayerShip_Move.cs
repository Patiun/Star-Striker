using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the movement for the Player's Ship
/// Author: Greg Kilmer
/// </summary>
public class PlayerShip_Move : MonoBehaviour {

    public float maxTiltAmount; //Maximum amount the ship is allowed to rotate around the Y axis
    public float maxVelocity; //Maximum speed the ship is allowed to have

    private Rigidbody rb; //Reference to the RigidBody of the ship

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
    /// <summary>
    /// Set the ships velocity equal to the amnt * maxVelocity.
    /// Uses transform.right and the fact that amnt exists in [-1,1] to control side to side motion.
    /// </summary>
    /// <param name="amnt">float form -1 to 1</param>
    public void Boost(float amnt)
    {
        rb.velocity = transform.right * amnt * maxVelocity;
        Tilt(amnt);
    }

    /// <summary>
    /// Represents the ships tilt when moving based on amnt
    /// </summary>
    /// <param name="amnt">float form -1 to 1</param>
    private void Tilt(float amnt)
    {
        transform.rotation = Quaternion.Euler(0f, -maxTiltAmount * amnt, 0f);
    }
}
