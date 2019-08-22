using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
    }
    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    private GameObject BoardGameObj;

    // Start is called before the first frame update
    void Start()
    {
        BoardGameObj = GameObject.FindGameObjectWithTag("BoardSpawn");
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        Refill();


    }
 
    void Refill()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool PoolObjects in Pools)
        {
            Queue<GameObject> ObjectPool = new Queue<GameObject>();

            for (int i = 0; i < PoolObjects.Size; i++)
            {
                GameObject Object = Instantiate(PoolObjects.Prefab);
                Object.transform.parent = this.transform;
                Object.SetActive(false);
                ObjectPool.Enqueue(Object);
            }

            PoolDictionary.Add(PoolObjects.Tag, ObjectPool);
        }

    }
    public GameObject SpawnFromPool (string Tag, Vector3 Position, Quaternion Rotation)
    {

        if(!PoolDictionary.ContainsKey(Tag))
        {
            Debug.LogError("DOESENTEXIST");
            return null;
        }
        if(PoolDictionary[Tag].Count < 1)
        {
            Refill();
        }
        GameObject SpawnObject = PoolDictionary[Tag].Dequeue();

        SpawnObject.SetActive(true);
        SpawnObject.transform.position = Position;
        SpawnObject.transform.rotation = Rotation;
        SpawnObject.transform.parent = BoardGameObj.transform;

        PoolDictionary[tag].Enqueue(SpawnObject);
        return SpawnObject;
    }
}
