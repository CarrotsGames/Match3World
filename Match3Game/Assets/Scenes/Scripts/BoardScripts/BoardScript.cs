using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{

    public int Width;
    public int Height;
    public GameObject TilePrefab;
    public GameObject[] Dots;
    public GameObject[,] AllDots;
    public GameObject Spawner;
    int SpawnQueue = 0;
    bool SpawnBool;
    bool HasChildren;
    int Total;
 
    // List of all nodes in their order
    //  List<GameObject> ReachableNodes = new List<GameObject>();
    private BackgroundTileScript[,] AllTiles;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBool = false;
           AllTiles = new BackgroundTileScript[Width, Height];
        AllDots = new GameObject[Width, Height];
        SetUpBoard();
        HasChildren = true;

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
                int DotToUse = Random.Range(0, Dots.Length);
                GameObject Dot = Instantiate(Dots[DotToUse], TempPosition, Quaternion.identity);
              //  ReachableNodes.Add(Dot);
                Dot.transform.parent = this.transform;
                Dot.name = "( " + i + "," + j + ")";
                AllDots[i, j] = Dot;
            }
        }
        Total = transform.childCount ;
        // for (int i = 0 + 1; i < Dots.Length; i++)
        // {
        //     Vector3 end = Dots[i].transform.position;
        //     if (Physics.Linecast(Dots[i].transform.position, Dots[i + 1].transform.position, layerMask))
        //         continue;
        //     if (Physics.Linecast(Dots[i + 1].transform.position, Dots[i].transform.position, layerMask))
        //         continue;
        //     // Link node i and n
        // }
    }
    private void Update()
    {
 
         if(transform.childCount < Total)
       {
            
            // Creates dots for positions
           int DotToUse = Random.Range(0, Dots.Length);
           GameObject Dot = Instantiate(Dots[DotToUse], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Dot.transform.parent = this.transform;

        }
    }
  
}
