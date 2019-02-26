using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CompanionScript : MonoBehaviour
{
    public List<GameObject> EatingPeices;
    // Use this for initialization
    public GameObject EatingPeiceSpawner;
      // Once the peices are eaten the campanion checks if he can grow
    bool CheckIfCanGrow;
    // starts the growing mechanic
    bool GrowTime;
    // max it can go to is 10
    public float[] GrowingSizes;



    DotManagerScript dotManagerScript;
    GameObject DotManagerObj;
    // Update is called once per frame
    int posX;
    int posY;
    int GrowSize;
    private void Start()
    {
        GrowSize = 0;
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
      
        GrowTime = false;
        CheckIfCanGrow = false;
    }
    private void Update()
    {
       
        // Max growing sizes are 10
        if (CheckIfCanGrow)
        {
            if (dotManagerScript.TotalScore >= GrowingSizes[0] && GrowSize == 0)
            {
                GrowTime = true;

                GrowSize += 1;
            }
            if (dotManagerScript.TotalScore >= GrowingSizes[1] && GrowSize == 1)
            {
                GrowTime = true;

                GrowSize += 1;
            }
            if (dotManagerScript.TotalScore >= GrowingSizes[2] && GrowSize == 2)
            {
                GrowTime = true;
                GrowSize += 1;
            }
            if (dotManagerScript.TotalScore >= GrowingSizes[3] && GrowSize == 3)
            {
                GrowTime = true;
                GrowSize += 1;
            }
            if (dotManagerScript.TotalScore >= GrowingSizes[4] && GrowSize == 4)
            {
                GrowTime = true;
                GrowSize += 1;
            }
            if (dotManagerScript.TotalScore >= GrowingSizes[5] && GrowSize == 5)
            {
                GrowTime = true;
                GrowSize += 1;
            }
            if (dotManagerScript.TotalScore >= GrowingSizes[6] && GrowSize == 6)
            {
                GrowTime = true;
                GrowSize += 1;
            }
            if (dotManagerScript.TotalScore >= GrowingSizes[7] && GrowSize == 7)
            {
                GrowTime = true;
                GrowSize += 1;
            }
            if (dotManagerScript.TotalScore >= GrowingSizes[8] && GrowSize == 8)
            {
                GrowTime = true;
                GrowSize += 1;
            }
            if (dotManagerScript.TotalScore >= GrowingSizes[9] && GrowSize == 9)
            {
                GrowTime = true;
                GrowSize += 1;
            }
            Debug.Log("Checked");
            CheckIfCanGrow = false;
        }

        switch (GrowSize)
        {
            case 1:
                if (GrowTime)
                {
                    transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                    if (transform.localScale.y > 1.5f)
                    {
                        GrowTime = false;
                    }
                }
                break;
            case 2:
                if (GrowTime)
                {
                    transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                    if ( transform.localScale.y > 2)
                    {
                        GrowTime = false;
                    }
                }
                break;
            case 3:
                if (GrowTime)
                {
                    transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                    if ( transform.localScale.y > 2.5f)
                    {
                        GrowTime = false;
                    }
                }
                break;
            case 4:
                if (GrowTime)
                {
                    transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                    if (transform.localScale.y > 3)
                    {
                        GrowTime = false;
                    }
                }
                break;
            case 5:
                if (GrowTime)
                {
                    transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                    if (transform.localScale.y > 3.5f)
                    {
                        GrowTime = false;
                    }
                }
                break;
            case 6:
                if (GrowTime)
                {
                    transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                    if (transform.localScale.y > 4)
                    {
                        GrowTime = false;
                    }
                }
                break;
            case 7:
                if (GrowTime)
                {
                    transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                    if (transform.localScale.y > 4.5f)
                    {
                        GrowTime = false;
                    }
                }
                break;
            case 8:
                if (GrowTime)
                {
                    transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                    if (transform.localScale.y > 5)
                    {
                        GrowTime = false;
                    }
                }
                break;
            case 9:
                if (GrowTime)
                {
                    transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                    if (transform.localScale.y > 5.5f)
                    {
                        GrowTime = false;
                    }
                }
                break;
            case 10:
                if (GrowTime)
                {
                    transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                    if (transform.localScale.y > 6)
                    {
                        GrowTime = false;
                    }
                }
                break;
        }

    }
    public void FeedMonster()
    {

        // gets random x and y so objects dont spawn in eachother
        posX = Random.Range(0, 2);
        posY = Random.Range(0, 10);
            
            // transforms the peices to the eatingspawner position
            for (int i = 0; i < EatingPeices.Capacity; i++)
            {

                EatingPeices[i].transform.position = EatingPeiceSpawner.transform.position + new Vector3(posX, posY, 0);
                 
           }
     }
// when the pieces collide with the companion it will destory them
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Red" || collision.gameObject.tag == "Blue" || collision.gameObject.tag == "Green" || collision.gameObject.tag == "Yellow")
        {
            CheckIfCanGrow = true;
            Destroy(collision.gameObject);
        }
    }
}
