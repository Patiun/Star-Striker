using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip_Controls : MonoBehaviour {

    private PlayerShip_Move engines;
    private PlayerShip_Shoot guns;

	// Use this for initialization
	void Start () {
        engines = GetComponent<PlayerShip_Move>();
        guns = GetComponent<PlayerShip_Shoot>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        engines.Boost(Input.GetAxis("Horizontal"));
        if (Input.GetAxis("MainFire") != 0)
        {
            guns.Shoot();
        }
    }
}
