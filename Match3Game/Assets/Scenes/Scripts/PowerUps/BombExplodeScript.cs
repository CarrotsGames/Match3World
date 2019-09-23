﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombExplodeScript : MonoBehaviour
{
    public float Timer;
    int Index;
    public GameObject ExplosionEffect;
    public List<GameObject> CollidedNodes;
  
    private DotManager DotManagerScript;
    private GameObject DotManagerObj;
    bool Detonate;
    bool AddScore;
    private GameObject AudioManagerGameObj;
    private AudioManager AudioManagerScript;
    private GameObject PowerUpGameObj;
    private GameObject HappinessGameObj;
    public HappinessManager HappinessManagerScript;
    private GameObject Companion;
    void Awake()
    {
        PowerUpGameObj = GameObject.Find("PowerUps");
        Companion = GameObject.FindGameObjectWithTag("Companion");
        AudioManagerGameObj = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManagerScript = AudioManagerGameObj.GetComponent<AudioManager>();
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
        // 12 = BOMB Layer
        // 11 = WALL layer
        // ignroe collisions Between this layer and this layer
        Physics2D.IgnoreLayerCollision(12, 11);
        Physics2D.IgnoreLayerCollision(12, 14);
        Physics2D.IgnoreLayerCollision(12, 15);
        Physics2D.IgnoreLayerCollision(12, 2);

        Detonate = true;
        AddScore = false;
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();

     }

    void Update()
    {
        Timer -= Time.deltaTime;
        // if the bomb is just sitting there not colliding with nodes it will destroy in 3 seconds
        if (Timer <= -3)
        {
            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonEnable();

            DestoryMe();
        }
        if (AddScore)
        {
            // total is equal to amound of collided nodes times current level
            int Total = CollidedNodes.Count * HappinessManagerScript.Level;
            // total is equal to amound of collided nodes times current level + 10(10 being bomb default value)
            int BombEXP = CollidedNodes.Count + HappinessManagerScript.Level + 10;
            Companion.GetComponent<CompanionScript>().ScoreMultiplier(BombEXP, Total, "SuperBomb");
              AddScore = false;
        }
      

    }
     void DestoryMe()
    {
        //destroys gameobject and clears list
        Destroy(this.gameObject);
        CollidedNodes.Clear();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // adds collided nodes to list to be used for particles
        if (!CollidedNodes.Contains(collision.gameObject))
        {
            CollidedNodes.Add(collision.gameObject);

        }

        if (Timer < 0 )
        {
        
            if (Detonate)
            {
                Index = 0;

                for (int i = 0; i < CollidedNodes.Count; i++)
                {
                    // removes node from board to spawn nodes faster
                    CollidedNodes[i].transform.parent = null;
                   // PlayParticle();
                }
                // begins adding score
                AddScore = true;
                // plays particles sound 
                AudioManagerScript.ParticleSource.PlayOneShot(AudioManagerScript.ParticleAudio[0]);
                // spawns in explosion
                Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
                // disables bomb sprite and collider
               // GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;              
                Detonate = false;
                // re enables power up buttons
                PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonEnable();

            }
            if (Timer >= -0.25f)
            {
                // moves collided nodes out of view and destroys them over time
                if (collision.gameObject.tag != "Wall")               
                {
                    collision.gameObject.transform.position = new Vector3(100, 0, 0);
                    collision.gameObject.GetComponent<DotScript>().SelfDestruct = true;
                }
            }
            // destroys this gameobject after 1 second
            else if (Timer <= -1)
            {
                DestoryMe();
            }

        }
        

    }
    void PlayParticle()
    {
       
        // plays particle effect at list index and position of current node
        if (CollidedNodes[Index].tag == "Red")
        {
            Instantiate(DotManagerScript.ParticleEffectPink, CollidedNodes[Index].transform.position, Quaternion.identity);

        }
        else if (CollidedNodes[Index].tag == "Blue")
        {
            Instantiate(DotManagerScript.ParticleEffectBlue, CollidedNodes[Index].transform.position, Quaternion.identity);
        }
        else if (CollidedNodes[Index].tag == "Yellow")
        {
            Instantiate(DotManagerScript.ParticleEffectPurple, CollidedNodes[Index].transform.position, Quaternion.identity);
        }
        else if (CollidedNodes[Index].tag == "Green")
        {
            Instantiate(DotManagerScript.ParticleEffectYellow, CollidedNodes[Index].transform.position, Quaternion.identity);
        }
        Index++;
    }
}
