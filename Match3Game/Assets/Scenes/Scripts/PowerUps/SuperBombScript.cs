using UnityEngine;
using System.Collections;

public class SuperBombScript : MonoBehaviour
{

    public GameObject SuperBombPrefab;
    private bool CanPlaceBomb;

    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
    // Use this for initialization
    void Start()
    {
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
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
        if (PowerUpManagerScript.HasBombs)
        {
            PowerUpManagerScript.NumOfBombs -= 1;
            CanPlaceBomb = true;
        }
    }
}
