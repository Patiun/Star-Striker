using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the behavior for the coin collectable
/// Author: Greg Kilmer
/// </summary>
public class Coin : Collectable_Abstract, ICollectable
{

    public int scoreValue; //Score Value the coin is worth
    public float rotationSpeed; //Speed the coin rotates;

    // Use this for initialization
    void Start () {
        base.Init();
	}
	
	// Update is called once per frame
	new void Update () {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        base.Update();
    }

    /// <summary>
    /// Handles what happens when the coin is picked up
    /// </summary>
    public new void PickUp()
    {
        game.AddScore(scoreValue);
        base.PickUp();
    }
}
