﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CompanionScript : MonoBehaviour
{
    public List<GameObject> EatingPeices;
    // Use this for initialization
    public GameObject EatingPeiceSpawner; 
    // max it can go to is 10
    public float[] GrowingSizes;

 
    DotManagerScript dotManagerScript;
    GameObject DotManagerObj;
    RealTimeCounter RealTimeScript;
    GameObject RealTimerGameObj;
    // Update is called once per frame
    int posX;
    int posY;
    public Text HungerMetre;
    public float Hunger;
    int HungerMultiplier = 1;
    // Must cap at 4
    public int[] multiplier;


    private void Start()
    {
        RealTimerGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = RealTimerGameObj.GetComponent<RealTimeCounter>();
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();

    }

    private void Update()
    {

        HungerMetre.text = "" + Hunger;
        Hunger = Mathf.Clamp(Hunger, 0, 100);

        Hunger -= Time.deltaTime;
        PlayerPrefs.SetFloat("CurrentHunger", Hunger);

        // if hunger less than 20
        if (Hunger < 20)
        {
             dotManagerScript.Multipier = 1;
            // changes size of companion
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
  //  public void ShrinkingPeices()
  //  {
  //
  //
  //      StartCoroutine(TEST());
  //
  //      //FeedMonster();
  //  }
  //  IEnumerator TEST()
  //  {
  //      for (Peice = 0; Peice < EatingPeices.Count; Peice++)
  //      {
  //          EatingPeices[Peice].gameObject.transform.localScale -= new Vector3(15, 15, 15) * Time.deltaTime;
  //          yield return new WaitForSeconds(0);
  //          GrowTime = true;
  //          Debug.Log("3 secodns up");
  //      }
  //  }
    public void FeedMonster()
    {

        // gets random x and y so objects dont spawn in eachother
        posX = Random.Range(0, 2);
        posY = Random.Range(0, 10);
            
            // transforms the peices to the eatingspawner position
            for (int i = 0; i < EatingPeices.Count; i++)
            {
             
                 EatingPeices[i].transform.position = EatingPeiceSpawner.transform.position + new Vector3(posX, posY, 0);
                 HungerMultiplier = i / 2;
            }
     }
// when the pieces collide with the companion it will destory them
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Red" || collision.gameObject.tag == "Blue" || collision.gameObject.tag == "Green" || collision.gameObject.tag == "Yellow")
        {
             Hunger += HungerMultiplier;
            Destroy(collision.gameObject);
        }
    }
    private void OnApplicationPause(bool pause)
    {
        RealTimeScript.ResetClock();

    }
    private void OnApplicationQuit()
    {
        RealTimeScript.ResetClock();

    }
}
