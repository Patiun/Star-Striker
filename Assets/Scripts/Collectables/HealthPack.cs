using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HealthPack behavior
/// Author: Greg Kilmer
/// </summary>
public class HealthPack : Collectable_Abstract, ICollectable {

    public int healthAmount = 1; //Amount of health gained for picking this item up, default to 1

	// Use this for initialization
	void Start () {
        base.Init();
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    /// <summary>
    /// Handles what happens when the healthpack is picked up
    /// </summary>
    new public void PickUp()
    {
        game.AddLife(healthAmount);
        base.PickUp();
    }
}
