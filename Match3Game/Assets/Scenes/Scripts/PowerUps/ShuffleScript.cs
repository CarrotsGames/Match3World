using UnityEngine;
using System.Collections;

public class ShuffleScript : MonoBehaviour
{
    public GameObject ShuffleGameObj;
    public float ShuffleSpeed;
    GameObject Go;
    bool Shuffle;
    bool CanShuffle;
    // Use this for initialization
    void Start()
    {
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
        if (CanShuffle)
        {
            ShuffleGameObj.transform.localScale = new Vector3(10, 10, 10);
            Vector3 test = new Vector3(4.5f, -24, -15);

            Go = Instantiate(ShuffleGameObj, test, Quaternion.identity);
            Shuffle = true;
            CanShuffle = false;
        }
    }
}
