using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [System.Serializable]
    public class SpawnItem {
        public GameObject prefab;
        public string poolTag;
        public float chance;
    }

    public bool canSpawn;
    public List<SpawnItem> spawnItems;
    public float boundSize; //Maybe tie into the world bound size?
    public float spawnRate;
    public float TEMP_startDelay;

    private float timeLastSpawned;
    private ObjectPooler objectPooler;

    // Use this for initialization
    void Start () {
        objectPooler = ObjectPooler._sharedInstance;
            //TEMP
        timeLastSpawned = Time.time + TEMP_startDelay;
	}

    // Update is called once per frame
    void Update()
    {
        if (canSpawn) {
            if (timeLastSpawned + 1f / spawnRate <= Time.time)
            {
                Spawn();
            }
        }
	}

    private void Spawn()
    {
        int ind = Random.Range(0, spawnItems.Count);
        float chance = Random.Range(0f, 100f);
        if (chance <= spawnItems[ind].chance)
        {
            float x = Random.Range(-boundSize, boundSize);
            Vector3 pos = transform.position;
            pos.x += x;
            objectPooler.SpawnFromPool(spawnItems[ind].poolTag, pos,transform.rotation);
            timeLastSpawned = Time.time;
        }
    }
}
