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

    private BackgroundTileScript[,] AllTiles;
    // Start is called before the first frame update
    void Start()
    {
        AllTiles = new BackgroundTileScript[Width, Height];
        AllDots = new GameObject[Width, Height];
        SetUpBoard();
    }

    private void SetUpBoard()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                // Creates position for dots
                Vector2 TempPosition = new Vector2(i, j);
                GameObject BackGroundTile = Instantiate(TilePrefab, TempPosition, Quaternion.identity) as GameObject;
                BackGroundTile.transform.parent = this.transform;
                BackGroundTile.name = "( " + i + "," + j + ")";
                // Creates dots for positions
                int DotToUse = Random.Range(0, Dots.Length);
                GameObject Dot = Instantiate(Dots[DotToUse], TempPosition, Quaternion.identity);
                Dot.transform.parent = this.transform;
                Dot.name = "( " + i + "," + j + ")";
                AllDots[i, j] = Dot;
            }
        }
    }

}
