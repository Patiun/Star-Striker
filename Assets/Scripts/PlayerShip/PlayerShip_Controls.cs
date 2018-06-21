using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip_Controls : MonoBehaviour {

    private PlayerShip_Move move;

	// Use this for initialization
	void Start () {
        move = GetComponent<PlayerShip_Move>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        move.Boost(Input.GetAxis("Horizontal"));
    }
}
