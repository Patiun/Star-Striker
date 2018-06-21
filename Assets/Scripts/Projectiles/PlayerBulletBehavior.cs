using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour, IPooledObject {

    public float timeAllowedToExist;
    public float timeExisted = 0f;
	
	// Update is called once per frame
	void Update () {
        timeExisted += Time.deltaTime;
        if (timeExisted >= timeAllowedToExist)
        {
            gameObject.SetActive(false);
        }
	}

    public void OnObjectSpawn()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        timeExisted = 0f;
    }
}
