using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShuffleScript : MonoBehaviour
{
    public GameObject ShuffleSpawn;
    public GameObject ShuffleGameObj;
    public float ShuffleSpeed;
    public float CircleScale;
    GameObject Go;
    bool Shuffle;
    bool CanShuffle;
    private GameObject PowerUpManGameObj;
    Rigidbody2D rb2d;
    private PowerUpManager PowerUpManagerScript;
    private GameObject PowerUpGameObj;
    private GameObject Board;
    int TimesUsed;
    float Timer;
    private bool Scale;
    private List<Vector3> NodePositions;
    // Use this for initialization
    void Start()
    {
        TimesUsed = PlayerPrefs.GetInt("SHUFFLE");
        NodePositions = new List<Vector3>();
        PowerUpGameObj = GameObject.Find("PowerUps");
        Board = GameObject.FindGameObjectWithTag("BoardSpawn");
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        Shuffle = false;
        CanShuffle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Scale)
        {
            if (Go.transform.localScale.x >= 9)
            {
                
                Go.transform.localScale += new Vector3(-1, -1, -1) * ShuffleSpeed * Time.deltaTime;
            }
            else
            {
                for (int i = 1; i < Board.transform.childCount; i++)
                {
                    NodePositions.Add(Board.transform.GetChild(i).transform.position);
                }
                Scale = false;
                Shuffle = true;
            }
            // ShuffleGameObj.transform.localScale += new Vector3(-1, -1, -1)  * Time.deltaTime;
        }
        if(Shuffle)
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;

                ShuffleNodes();
            }
            else
            {
                Shuffle = false;
                Destroy(Go);
                CanShuffle = true;
                PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonEnable();
                NodePositions.Clear();
            }
        }
    }
    public void ShuffleNodes()
    {
        for (int i = 1; i < Board.transform.childCount; i++)
        {
            int Rand = Random.Range(0, Board.transform.childCount);
            Board.transform.GetChild(i).transform.position = NodePositions[Rand];
        }

    
    }
   public void ShuffleButton()
    {
        PowerUpManagerScript.PowerUpChecker();

        if (PowerUpManagerScript.HasShuffles)
        {
            if (CanShuffle)
            {
                Timer = 1;

                // Counts how many times player uses this powerup
                TimesUsed++;
                PlayerPrefs.SetInt("SHUFFLE", TimesUsed);

                PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonDisable();

                PowerUpManagerScript.NumOfShuffles -= 1;
                PowerUpManagerScript.PowerUpSaves();
                ShuffleGameObj.transform.localScale = new Vector3(CircleScale, CircleScale, CircleScale);
                Vector3 test = new Vector3(4.5f, -24, -15);

                Go = Instantiate(ShuffleGameObj, ShuffleSpawn.transform.position, Quaternion.identity);

                Scale = true;
                CanShuffle = false;
            }
        }
        else
        {
            Debug.Log("PowerUpEmpty");
            PowerUpManagerScript.PowerUpEmpty("Shuffle");
        }
    }


}
