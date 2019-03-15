using UnityEngine;
using System.Collections;

public class ShuffleScript : MonoBehaviour
{

    public GameObject ShuffleGameObj;
    public float ShuffleSpeed;
    GameObject Go;
    bool Shuffle;
    bool CanShuffle;
    private GameObject PowerUpManGameObj;

    private PowerUpManager PowerUpManagerScript;

    // Use this for initialization
    void Start()
    {
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        Shuffle = false;
        CanShuffle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Shuffle)
        {
          Go.transform.localScale += new Vector3(-1, -1, -1) * ShuffleSpeed * Time.deltaTime;
            // if x is less than 0 stop(NOTE it can be any axis we just need to check if a value is less than 0)
            if (Go.transform.localScale.x <= 0)
            {
                Destroy(Go);
                Shuffle = false;
                CanShuffle = true;
            }

           // ShuffleGameObj.transform.localScale += new Vector3(-1, -1, -1)  * Time.deltaTime;
        }
    }

   public void ShuffleButton()
    {
        if (PowerUpManagerScript.HasShuffles)
        {
            if (CanShuffle)
            {
                PowerUpManagerScript.NumOfShuffles -= 1;

                ShuffleGameObj.transform.localScale = new Vector3(10, 10, 10);
                Vector3 test = new Vector3(4.5f, -24, -15);

                Go = Instantiate(ShuffleGameObj, test, Quaternion.identity);
                Shuffle = true;
                CanShuffle = false;
            }
        }
        else
        {
            Debug.Log("PowerUpEmpty");
            PowerUpManagerScript.PowerUpEmpty();
        }
    }
}
