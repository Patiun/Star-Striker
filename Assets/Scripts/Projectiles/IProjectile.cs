using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface to determine projectiles
/// Author: Greg Kilmer
/// </summary>
public interface IProjectile {

    int GetDamage();
    void Die();
}
