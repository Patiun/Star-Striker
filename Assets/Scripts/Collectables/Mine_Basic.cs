using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_Basic : Collectable_Abstract, ICollectable
{

    // Use this for initialization
    void Start()
    {
        base.Init();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public new void PickUp()
    {
        game.PlayerDeath();
        base.PickUp();
    }

}
