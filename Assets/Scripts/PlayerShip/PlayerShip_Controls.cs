using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles control input for the player's ship
/// Author: Greg Kilmer
/// </summary>
public class PlayerShip_Controls : MonoBehaviour {

    private PlayerShip_Move engines; //reference to the ability of the player to move
    private PlayerShip_Shoot guns; //reference to the ability of the player to shoot

	// Use this for initialization
	void Start () {
        engines = GetComponent<PlayerShip_Move>();
        guns = GetComponent<PlayerShip_Shoot>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Fixed update is called at fixed times (used for input over the general update)
    void FixedUpdate()
    {
        engines.Boost(Input.GetAxis("Horizontal")); //Move in the direction of the horixontal axis
        if (Input.GetAxis("MainFire") != 0) //If MainFire is pressed, shoot
        {
            guns.Shoot();
        }
    }
}
