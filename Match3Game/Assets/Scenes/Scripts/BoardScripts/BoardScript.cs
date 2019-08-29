using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    int Rand;
    string Colour;
    public int Limit;
    public bool DisableNodeDrop;
    public int Width;
    public int Height;
    public int Gold;
    public GameObject TilePrefab;
    public GameObject[] Dots;
    public GameObject[,] AllDots;
    public GameObject Spawner;
    private List<GameObject> test = new List<GameObject>();
    string SceneName;
    public float DelaySpawn;
    int Total;
    private GameObject SpecialSpawn;
    // List of all nodes in their order
    //  List<GameObject> ReachableNodes = new List<GameObject>();
    private BackgroundTileScript[,] AllTiles;
    // Start is called before the first frame update
    ObjectPooler ObjectPoolerScript;
    string[] Colours = {"Red" ,"Blue","Green","Pink" };
    private void Start()
    {
        // if no delay time is set automatically set it to 1 
        if(DelaySpawn == 0)
        {
            DelaySpawn = 1;
        }
    
        ObjectPoolerScript = ObjectPooler.Instance;

   
        
    }
    private void FixedUpdate()
    {
        if (DelaySpawn < 0)
        {
            ChildCount();
        }
        else 
        {
            DelaySpawn -= Time.deltaTime;
        }
    }
    void InitialSpawn()
    {
        for (int i = 0; i < Limit; i++)
        {
            Randomise();
            Spawn();
        }
    }
    public void ChildCount()
    {

        if (transform.childCount < Limit)
        {
            Randomise();
            // Rand = Random.Range(0, 3);
            Spawn();

        }
    }
    void Randomise()
    {
        Rand = Random.Range(0, 4);
        // if the colour is the same as previous spawned colour re randomise
        if (Colour == Colours[Rand])
        {
             Randomise();
        }
        else
        {
            Colour = Colours[Rand];
        }
    }
    void Spawn()
    {
        ObjectPooler.Instance.SpawnFromPool(Colours[Rand], transform.position, Quaternion.identity);
    }
  
}
