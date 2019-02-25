using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CompanionScript : MonoBehaviour
{
    public List<GameObject> EatingPeices;
    // Use this for initialization
    public GameObject EatingPeiceSpawner;
    public bool FeedMonsterbool;
    public bool CoolDownBool;
    float CoolDownTimer;
    DotManagerScript dotManagerScript;
    GameObject DotManagerObj;
    // Update is called once per frame
    int posX;
    int posY;
    private void Start()
    {
     
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        FeedMonsterbool = false;
        CoolDownBool = false;
    }
    private void Update()
    { 

        if(dotManagerScript.TotalScore >= 10)
        {
            Debug.Log("Greater than 10");
        }
        if (dotManagerScript.TotalScore >= 50)
        {
            Debug.Log("Greater than 50");

        }
        if (dotManagerScript.TotalScore >= 100)
        {
            Debug.Log("Greater than 100");

        }
        if (dotManagerScript.TotalScore >= 500)
        {
            Debug.Log("Greater than 500");


        }
    }
    public void FeedMonster()
    {
        posX = Random.Range(0, 2);
        posY = Random.Range(0, 10);

 
            for (int i = 0; i < EatingPeices.Capacity; i++)
            {

                EatingPeices[i].transform.position = EatingPeiceSpawner.transform.position + new Vector3(posX, posY, 0);
                 
           }
     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Red" || collision.gameObject.tag == "Blue" || collision.gameObject.tag == "Green" || collision.gameObject.tag == "Yellow")
        {
 
            Destroy(collision.gameObject);
        }
    }
}
