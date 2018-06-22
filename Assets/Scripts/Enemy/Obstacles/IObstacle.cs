using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacle{

    void CollideWithPlayer();
    void Die();
    void AddScore();
}
