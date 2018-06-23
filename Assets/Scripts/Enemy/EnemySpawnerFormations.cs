using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns enemy units in predetermined formations
/// Author: Greg Kilmer
/// </summary>
public class EnemySpawnerFormations : MonoBehaviour {

    [System.Serializable]
    public class FormationData
    {
        public Formation formation;
        public float chance;
    }

    public List<FormationData> formations;
    public float unitGap;
    public float rowGap;
    public float boundSize;

    public bool waveActive;
    public float spawnRate;
    public float spawnRateGrowth;
    public float waveDuration;
    public float timeBetweenWaves;
    public float timeToEndWave; //Time after the spawner says it finished spawing to actually end the wave

    private float nextSpawnTime;
    private float waveEndTime;
    private float nextWaveStart;

    private ObjectPooler objectPooler;
    private GameController game;

	// Use this for initialization
	void Start () {
        objectPooler = ObjectPooler._sharedInstance;
        game = GameController._sharedInstance;
        nextWaveStart = Time.time + timeBetweenWaves;
	}

    // Update is called once per frame
    void Update()
    {
        if (!game.gameOver) {
            if (waveActive)
            {
                if (Time.time >= nextSpawnTime)
                {
                    Spawn();
                }
                if (Time.time >= waveEndTime)
                {
                    EndWave();
                }
            }
            else
            {
                if (Time.time >= nextWaveStart)
                {
                    StartWave();
                }
            }
        }
	}

    private void StartWave()
    {
        nextSpawnTime = Time.time;
        waveEndTime = Time.time + waveDuration;
        waveActive = true;
        spawnRate *= 1f + spawnRateGrowth * game.currentWave;
        game.WaveStart();
    }

    private void EndWave()
    {
        waveActive = false;
        nextWaveStart = Time.time + timeBetweenWaves + timeToEndWave;
        StartCoroutine(DelayEndWave());
    }

    private IEnumerator DelayEndWave()
    {
        yield return new WaitForSeconds(timeToEndWave);
        game.WaveOver();
    }

    private void Spawn()
    {
        FormationData chosenFormation = formations[Random.Range(0, formations.Count)];
        if (Random.Range(0,100f) <= chosenFormation.chance)
        {
            Formation chosen = chosenFormation.formation;
            chosen.Build();
            int size = chosen.row0.Count;
            float offset = size / 2f * unitGap;
            float xo = Random.Range(-boundSize+offset, boundSize-offset);
            for (int i = 0; i < Formation.maxRows; i++)
            {
                List<string> row = chosen.allRows[i];
                for (int j = 0; j < row.Count; j++)
                {
                    string target = row[j];
                    if (target != "0" && target != "") {
                        float x = xo + j * unitGap - offset;
                        Vector3 pos = transform.position;
                        pos.x += x;
                        pos.y += i * rowGap;
                        objectPooler.SpawnFromPool(target, pos, transform.rotation);
                    }
                }
            }
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }
}
