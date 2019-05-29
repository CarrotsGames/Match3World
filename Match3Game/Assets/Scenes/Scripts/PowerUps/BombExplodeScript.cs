using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombExplodeScript : MonoBehaviour
{
    float Timer = 1;
    public GameObject Board;
    public GameObject ExplosionEffect;
    public List<GameObject> CollidedNodes;
  
    private DotManager DotManagerScript;
    private GameObject DotManagerObj;
      bool Detonate;
    bool AddScore;
    private GameObject AudioManagerGameObj;
    private AudioManager AudioManagerScript;

    void Start()
    {
        AudioManagerGameObj = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManagerScript = AudioManagerGameObj.GetComponent<AudioManager>();
        // 12 = BOMB Layer
        // 11 = WALL layer
        // ignroe collisions Between this layer and this layer
        Physics2D.IgnoreLayerCollision(12, 11);
        Physics2D.IgnoreLayerCollision(12, 14);
         Detonate = true;
        AddScore = false;
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();

     }

    void Update()
    {
        Timer -= Time.deltaTime;
        
        if(AddScore)
        {
            DotManagerScript.TotalScore += CollidedNodes.Count * DotManagerScript.Multipier;
            DotManagerScript.HighScore.text = "" + DotManagerScript.TotalScore;
            AddScore = false;
        }
      

    }
     void DestoryMe()
    {
        Destroy(this.gameObject);
        CollidedNodes.Clear();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
         if (CollidedNodes.Contains(collision.gameObject))
        {
            Debug.Log("Already contains me");
        }
        else
        {
            CollidedNodes.Add(collision.gameObject);

        }
        if (Timer < 0 )
        {
            if (Detonate)
            {
                AddScore = true;
                AudioManagerScript.ParticleSource.PlayOneShot(AudioManagerScript.ParticleAudio[0]);
                Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
                Detonate = false;
            }
            if(Timer >= -0.25f)
            {
                Destroy(collision.gameObject);
            }
            else if (Timer <= -1)
            {
                DestoryMe();
            }

        }
        

    }
}
