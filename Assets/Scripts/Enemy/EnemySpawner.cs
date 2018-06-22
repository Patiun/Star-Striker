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
    public float timeBetweenWaves;
    public float waveDuration;

    private float timeLastSpawned;
    private float waveDurationElapsed;
    private float timeSinceLastWave;
    private ObjectPooler objectPooler;
    private GameController game;

    // Use this for initialization
    void Start () {
        objectPooler = ObjectPooler._sharedInstance;
        game = GameController._sharedInstance;
	}

    // Update is called once per frame
    void Update()
    {
        if (canSpawn) {
            if (timeLastSpawned + 1f / spawnRate <= Time.time)
            {
                Spawn();
            }
            if (waveDurationElapsed >= waveDuration)
            {
                canSpawn = false;
                waveDurationElapsed = 0f;
                game.WaveOver();
            } else
            {
                waveDurationElapsed += Time.deltaTime;
            }
        } else
        {
            if (timeSinceLastWave >= timeBetweenWaves)
            {
                timeSinceLastWave = 0f;
                canSpawn = true;
                game.WaveStart();
            } else
            {
                timeSinceLastWave += Time.deltaTime;
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
