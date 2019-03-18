using UnityEngine;
using System.Collections;

public class SuperBombScript : MonoBehaviour
{

    public GameObject SuperBombPrefab;
    bool CanPlaceBomb;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CanPlaceBomb)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                Vector2 PlaceBomb = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Instantiate(SuperBombPrefab, new Vector2(PlaceBomb.x, PlaceBomb.y), Quaternion.identity);
                CanPlaceBomb = false;
            }
        }

    }

    public void SuperBomb()
    {
        CanPlaceBomb = true;
    }
}
