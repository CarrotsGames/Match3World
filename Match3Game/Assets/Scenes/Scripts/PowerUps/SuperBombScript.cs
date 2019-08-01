using UnityEngine;
using System.Collections;

public class SuperBombScript : MonoBehaviour
{

    public GameObject SuperBombPrefab;
    public GameObject BombPlayArea;
    private bool CanPlaceBomb;
    // Used in tutorial
    [HideInInspector]
    public bool BombHasBeenUsed;
    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
    private GameObject PowerUpGameObj;
    int TimesUsed;
    // Use this for initialization
    void Start()
    {
        TimesUsed = PlayerPrefs.GetInt("SUPERBOMB");

        PowerUpGameObj = GameObject.Find("PowerUps");

        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        BombPlayArea.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {   
        if (CanPlaceBomb)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                //Places bomb on Areas
                if (hit.transform.gameObject.layer == 14 || hit.transform.gameObject.layer == 10 || hit.transform.gameObject.layer == 15)
                {
                    BombPlayArea.SetActive(false);

                    Vector2 PlaceBomb = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                    Instantiate(SuperBombPrefab, new Vector2(PlaceBomb.x, PlaceBomb.y), Quaternion.identity);
                    CanPlaceBomb = false;
                    BombHasBeenUsed = true;

                }
                else if (hit.transform == null)
                {
                    Debug.Log("PLACE BOMB IN AREA");
                }

            }
        }       
    }

    public void SuperBomb()
    {
        if (!CanPlaceBomb)
        {
            PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonDisable();

            if (PowerUpManagerScript.HasBombs)
            {
                // Counts how many times player uses this powerup
                TimesUsed++;
                PlayerPrefs.SetInt("SUPERBOMB", TimesUsed);

                BombPlayArea.SetActive(true);

                PowerUpManagerScript.NumOfBombs -= 1;
                CanPlaceBomb = true;
            }
        }
    }
}
