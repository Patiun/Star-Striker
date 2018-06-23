using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Basic : Collectable_Abstract, ICollectable {

    public int shieldStrength;

	// Use this for initialization
	void Start () {
        base.Init();
	}
	
	// Update is called once per frame
	new void Update () {
        base.Init();
	}

    public new void PickUp()
    {
        game.ActivateShield(shieldStrength);
        base.PickUp();
    }
}
