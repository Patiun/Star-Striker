using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    #region Singleton
    public static ObjectPooler _sharedInstance;
    private void Awake()
    {
        _sharedInstance = this;
    }
    #endregion

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;


	// Use this for initialization
	void Start () {

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            GameObject nest = new GameObject(pool.tag + " Container");
            nest.transform.parent = transform;
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab,nest.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
	}

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            GameObject objectToSpawn = poolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

           IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
           if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
            }

            poolDictionary[tag].Enqueue(objectToSpawn);
            return objectToSpawn;
        } else
        {
            Debug.LogWarning("Pool with tag "+tag+" does not exist.");
        }
        return null;
    }

}
