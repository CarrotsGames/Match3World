using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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

    bool StartCountDown;

    DotManagerScript dotManagerScript;
    GameObject DotManagerObj;
    // Update is called once per frame
    int posX;
    int posY;
    int GrowSize;
    public Text HungerMetre;
    public float Hunger;
    int HungerMultiplier = 1;
    // Must cap at 4
    public int[] multiplier;


    private void Start()
    {
        GrowSize = 0;
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        StartCountDown = false;
          GrowTime = false;
        CheckIfCanGrow = false;
    }

    private void Update()
    {
        HungerMetre.text = "" + Hunger;
        Hunger = Mathf.Clamp(Hunger, 0, 100);

        if (StartCountDown)
        {
            Hunger -= Time.deltaTime;
        }
        // if hunger less than 20
        if (Hunger < 20)
        {
            StartCountDown = true;
            dotManagerScript.Multipier = 1;
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, 1, 1);
            newScale.z = Mathf.Clamp(transform.localScale.y, 1, 1);

            newScale.y = Mathf.Clamp(transform.localScale.y, 0, 0.5f);
            transform.localScale = newScale ;
        }
        if(Hunger > 20 && Hunger < 40)
        {
            dotManagerScript.Multipier = multiplier[0];
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, 1, 1);
            newScale.z = Mathf.Clamp(transform.localScale.y, 1, 1);

            newScale.y = Mathf.Clamp(transform.localScale.y, 1, 1);
            transform.localScale = newScale;
        }
        if (Hunger > 40 && Hunger < 60)
        {
            dotManagerScript.Multipier = multiplier[1];
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, 1, 1);
            newScale.z = Mathf.Clamp(transform.localScale.y, 1, 1);

            newScale.y = Mathf.Clamp(transform.localScale.y, 1, 2);
            transform.localScale = newScale;
        }
        if (Hunger > 60 && Hunger < 80)
        {
            dotManagerScript.Multipier = multiplier[2];
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, 1, 1);
            newScale.z = Mathf.Clamp(transform.localScale.y, 1, 1);

            newScale.y = Mathf.Clamp(transform.localScale.y, 2, 3);
            transform.localScale = newScale;

        }
        if (Hunger > 80 && Hunger < 100)
        {
            dotManagerScript.Multipier = multiplier[3];
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, 1, 1);
            newScale.z = Mathf.Clamp(transform.localScale.y, 1, 1);

            newScale.y = Mathf.Clamp(transform.localScale.y, 4, 5.5f);
            transform.localScale = newScale;

        }
    }
    // private void Update()
    // {
    //     HungerMetre.text = "" + Hunger;
    //
    //     if (StartCountDown)
    //     {
    //         Hunger -= Time.deltaTime;
    //     }
    //     // Max growing sizes are 10
    //     if (CheckIfCanGrow)
    //     {
    //         StartCountDown = true;
    //         // Stages of companion growing
    //         if (dotManagerScript.TotalScore >= GrowingSizes[0] && GrowSize == 0)
    //         {
    //             GrowTime = true;
    //
    //             GrowSize += 1;
    //         }
    //         if (dotManagerScript.TotalScore >= GrowingSizes[1] && GrowSize == 1)
    //         {
    //             GrowTime = true;
    //
    //             GrowSize += 1;
    //         }
    //         // Companion increases multplier by 2
    //         if (dotManagerScript.TotalScore >= GrowingSizes[2] && GrowSize == 2)
    //         {
    //             GrowTime = true;
    //             GrowSize += 1;
    //         }
    //         if (dotManagerScript.TotalScore >= GrowingSizes[3] && GrowSize == 3)
    //         {
    //             GrowTime = true;
    //             GrowSize += 1;
    //         }
    //         if (dotManagerScript.TotalScore >= GrowingSizes[4] && GrowSize == 4)
    //         {
    //             GrowTime = true;
    //             GrowSize += 1;
    //         }
    //         // Companion increases score mutilpier 
    //         if (dotManagerScript.TotalScore >= GrowingSizes[5] && GrowSize == 5)
    //         {
    //             GrowTime = true;
    //             GrowSize += 1;
    //         }
    //         if (dotManagerScript.TotalScore >= GrowingSizes[6] && GrowSize == 6)
    //         {
    //             GrowTime = true;
    //             GrowSize += 1;
    //         }
    //         // Companion increases score mutilpier 
    //         if (dotManagerScript.TotalScore >= GrowingSizes[7] && GrowSize == 7)
    //         {
    //             GrowTime = true;
    //             GrowSize += 1;
    //         }
    //         if (dotManagerScript.TotalScore >= GrowingSizes[8] && GrowSize == 8)
    //         {
    //             GrowTime = true;
    //             GrowSize += 1;
    //         }
    //         // Companion increases score mutilpier 
    //         if (dotManagerScript.TotalScore >= GrowingSizes[9] && GrowSize == 9)
    //         {
    //             GrowTime = true;
    //             GrowSize += 1;
    //         }
    //         Debug.Log("Checked");
    //         CheckIfCanGrow = false;
    //     }
    //
    //     switch (GrowSize)
    //     {            
    //         // Companion size increases  
    //         case 1:
    //             if (GrowTime)
    //             {
    //                 transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    //                 if (transform.localScale.y > 1.5f)
    //                 {
    //                     GrowTime = false;
    //                 }
    //             }
    //             break;
    //         // Companion size increases  
    //         case 2:
    //             if (GrowTime)
    //             {
    //                 transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    //                 if ( transform.localScale.y > 2)
    //                 {
    //                     GrowTime = false;
    //                 }
    //             }
    //             break;
    //             // Companion size increases and multiplier is increased by 2
    //         case 3:
    //             if (GrowTime)
    //             {
    //                 dotManagerScript.Multipier = multiplier[0];
    //
    //                 transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    //                 if ( transform.localScale.y > 2.5f)
    //                 {
    //                     GrowTime = false;
    //                 }
    //             }
    //             break;
    //         // Companion size increases  
    //         case 4:
    //             if (GrowTime)
    //             {
    //                 transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    //                 if (transform.localScale.y > 3)
    //                 {
    //                     GrowTime = false;
    //                 }
    //             }
    //             break;
    //         case 5:
    //             // Companion size increases and multiplier is increased by 5
    //             if (GrowTime)
    //             {
    //                 dotManagerScript.Multipier = multiplier[1];
    //
    //                 transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    //                 if (transform.localScale.y > 3.5f)
    //                 {
    //                     GrowTime = false;
    //                 }
    //             }
    //             break;
    //         // Companion size increases
    //         case 6:
    //             if (GrowTime)
    //             {
    //                 transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    //                 if (transform.localScale.y > 4)
    //                 {
    //                     GrowTime = false;
    //                 }
    //             }
    //             break;
    //         // Companion size increases and multiplier is increased by 10
    //         case 7:
    //             if (GrowTime)
    //             {
    //                 dotManagerScript.Multipier = multiplier[2];
    //
    //                 transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    //                 if (transform.localScale.y > 4.5f)
    //                 {
    //                     GrowTime = false;
    //                 }
    //             }
    //             break;
    //         // Companion size increases 
    //         case 8:
    //             if (GrowTime)
    //             {
    //                 transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    //                 if (transform.localScale.y > 5)
    //                 {
    //                     GrowTime = false;
    //                 }
    //             }
    //             break;
    //         // Companion size increases 
    //         case 9:
    //             if (GrowTime)
    //             {
    //                 transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    //                 if (transform.localScale.y > 5.5f)
    //                 {
    //                     GrowTime = false;
    //                 }
    //             }
    //             break;
    //         // Companion size increases and multiplier is increased by 25
    //         case 10:
    //             if (GrowTime)
    //             {
    //                 dotManagerScript.Multipier = multiplier[3];
    //
    //                 transform.localScale += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    //                 if (transform.localScale.y > 6)
    //                 {
    //                     GrowTime = false;
    //                 }
    //             }
    //             break;
    //     }
    //
    // }
    public void FeedMonster()
    {

        // gets random x and y so objects dont spawn in eachother
        posX = Random.Range(0, 2);
        posY = Random.Range(0, 10);
            
            // transforms the peices to the eatingspawner position
            for (int i = 0; i < EatingPeices.Count; i++)
            {
             
                 EatingPeices[i].transform.position = EatingPeiceSpawner.transform.position + new Vector3(posX, posY, 0);
                 HungerMultiplier = i;
            }
     }
// when the pieces collide with the companion it will destory them
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Red" || collision.gameObject.tag == "Blue" || collision.gameObject.tag == "Green" || collision.gameObject.tag == "Yellow")
        {
            CheckIfCanGrow = true;
            Hunger += HungerMultiplier;
            Destroy(collision.gameObject);
        }
    }
}
