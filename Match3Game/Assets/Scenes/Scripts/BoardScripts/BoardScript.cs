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
        ObjectPoolerScript = ObjectPooler.Instance;
    }
    private void FixedUpdate()
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
            Debug.Log("RANDOMISE");
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
    //  void Start()
    //  {
    //      Scene CurrentScene = SceneManager.GetActiveScene();
    //      SceneName = CurrentScene.name;
    //      if (SceneName != "GobuChallenge")
    //      {
    //          SpecialSpawn = GameObject.Find("SpecialNodeSpawn");
    //          AllTiles = new BackgroundTileScript[Width, Height];
    //          AllDots = new GameObject[Width, Height];
    //          SetUpBoard();
    //          Gold = 0;
    //      }
    //  }
    //
    //  private void SetUpBoard()
    //  {
    //      for (int i = 0; i < Width; i++)
    //      {
    //          for (int j = 0; j < Height; j++)
    //          {
    //              // Creates position for dots
    //              Vector2 TempPosition = new Vector2(transform.position.x, transform.position.y);
    //              GameObject BackGroundTile = Instantiate(TilePrefab, TempPosition, Quaternion.identity) as GameObject;
    //              BackGroundTile.transform.parent = this.transform;
    //              BackGroundTile.name = "( " + i + "," + j + ")";
    //              // Creates dots for positions
    //              int DotToUse = Random.Range(0, Dots.Length );
    //              GameObject Dot = Instantiate(Dots[DotToUse], TempPosition, Quaternion.identity);
    //              Dot.transform.parent = this.transform;
    //              test.Add(Dot);
    //           
    //              Dot.name = "( " + i + "," + j + ")";
    //              AllDots[i, j] = Dot;
    //          }
    //      }
    //      Total = transform.childCount;
    //
    //  }
    //  private void Update()
    //  {
    //
    //      if(transform.childCount < Total)
    //     {
    //
    //
    //          // Creates dots for positions
    //          if (!DisableNodeDrop)
    //          {
    //              int DotToUse = Random.Range(0, Dots.Length);
    //              GameObject Dot = Instantiate(Dots[DotToUse], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    //              Dot.transform.parent = this.transform;
    //              SpecialSpawn.GetComponent<AddSpecialNodes>().SpawnNode();
    //          }
    //       }
    //  }

}
