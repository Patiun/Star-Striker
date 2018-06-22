using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DEPRICATED - Use EnemySpawnFormations
/// Spawns the enemy objects and handles waves
/// Author: Greg Kilmer
/// </summary>
public class EnemySpawner : MonoBehaviour {

    /// <summary>
    /// Custom data structure for handling the objects to be spawned
    /// </summary>
    [System.Serializable]
    public class SpawnItem {
        public string poolTag; //Tag for the pool of objects
        public float chance; //Chance the object is actually spawned
    }

    public bool canSpawn; //Controls if the spawner can spawn items
    public List<SpawnItem> spawnItems; //List of items to be spawned using SpawnItem data type
    public float boundSize; //distance from the spawner in the x axis the spawner can spawn TODO: Maybe tie into the world bound size?
    public float spawnRate; //Number of things the spawner is allowed to spawn per second
    public float spawnRateBuild; //Rate at which the spawn rate increases per wave
    public float timeBetweenWaves; //The time between the waves where the spawner is not allowed to spawn
    public float waveDuration; //The time the wave is allowed to run

    private float timeLastSpawned; //The time the last item was spawned
    private float waveDurationElapsed; //The current duration the wave has been active
    private float timeSinceLastWave; //The time the last wave ended
    private ObjectPooler objectPooler; //Reference to the ObjectPooler singleton
    private GameController game; //Refernce to teh GameController singleton

    // Use this for initialization
    void Start () {
        objectPooler = ObjectPooler._sharedInstance;
        game = GameController._sharedInstance;
	}

    // Update is called once per frame
    void Update()
    {
        if (!game.gameOver)
        {
            if (canSpawn)
            {
                //Spawn Object
                if (timeLastSpawned + 1f / spawnRate <= Time.time)
                {
                    Spawn();
                }
                //Check Wave duraction
                if (waveDurationElapsed >= waveDuration)
                {
                    canSpawn = false;
                    waveDurationElapsed = 0f;
                    spawnRate *= 1 + spawnRateBuild * game.currentWave;
                    game.WaveOver();
                }
                else
                {
                    waveDurationElapsed += Time.deltaTime;
                }
            }
            else
            {
                if (timeSinceLastWave >= timeBetweenWaves)
                {
                    timeSinceLastWave = 0f;
                    canSpawn = true;
                    game.WaveStart();
                }
                else
                {
                    timeSinceLastWave += Time.deltaTime;
                }
            }
        }
	}

    /// <summary>
    /// Try to spawn an object from the set of allowed objects
    /// </summary>
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
