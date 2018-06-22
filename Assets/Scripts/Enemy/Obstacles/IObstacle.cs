using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for all spawned obstacles
/// Author: Greg Kilmer
/// </summary>
public interface IObstacle{

    void CollideWithPlayer();
    void Die();
    void AddScore();
}
