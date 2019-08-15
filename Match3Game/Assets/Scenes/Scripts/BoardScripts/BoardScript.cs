using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{

    public int Width;
    public int Height;
    public int Gold;
    public GameObject TilePrefab;
    public GameObject[] Dots;
    public GameObject[,] AllDots;
    public GameObject Spawner;
    private List<GameObject> test = new List<GameObject>();
     
    int Total;
    private GameObject SpecialSpawn;
    // List of all nodes in their order
    //  List<GameObject> ReachableNodes = new List<GameObject>();
    private BackgroundTileScript[,] AllTiles;
    // Start is called before the first frame update
    void Start()
    {
        SpecialSpawn = GameObject.Find("SpecialNodeSpawn");
           AllTiles = new BackgroundTileScript[Width, Height];
        AllDots = new GameObject[Width, Height];
        SetUpBoard();
        Gold = 0;
    }

    private void SetUpBoard()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                // Creates position for dots
                Vector2 TempPosition = new Vector2(transform.position.x, transform.position.y);
                GameObject BackGroundTile = Instantiate(TilePrefab, TempPosition, Quaternion.identity) as GameObject;
                BackGroundTile.transform.parent = this.transform;
                BackGroundTile.name = "( " + i + "," + j + ")";
                // Creates dots for positions
                int DotToUse = Random.Range(0, Dots.Length );
                GameObject Dot = Instantiate(Dots[DotToUse], TempPosition, Quaternion.identity);
                Dot.transform.parent = this.transform;
                test.Add(Dot);
             
                Dot.name = "( " + i + "," + j + ")";
                AllDots[i, j] = Dot;
            }
        }
        Total = transform.childCount;
 
    }
    private void Update()
    {
 
        if(transform.childCount < Total)
       {
 
           // Creates dots for positions
           int DotToUse = Random.Range(0, Dots.Length );
           GameObject Dot = Instantiate(Dots[DotToUse], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
           Dot.transform.parent = this.transform;
            SpecialSpawn.GetComponent<AddSpecialNodes>().SpawnNode();
         }
    }
  
}
