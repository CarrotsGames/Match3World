using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombExplodeScript : MonoBehaviour
{
    float Timer;
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
    void Awake()
    {
        PowerUpGameObj = GameObject.Find("PowerUps");

        Timer = 1;
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
      
        if (AddScore)
        {
            int Total = CollidedNodes.Count * HappinessManagerScript.Level;
            int BombEXP = CollidedNodes.Count + HappinessManagerScript.Level + 10;
            Total *= HappinessManagerScript.Level;

            if (SuperMultiplierScript.CanUseSuperMultiplier)
            {
                int SuperMultiplier = 2;
                Total *= SuperMultiplier;
                DotManagerScript.TotalScore += Total;
                DotManagerScript.HighScore.text = "" + DotManagerScript.TotalScore;
                // bombs do a defualt 10 Exp
                BombEXP *= SuperMultiplier;
                HappinessManagerScript.HappinessSliderValue += BombEXP;
                HappinessManagerScript.HappinessBar();
            }
            else
            {
                Total *= HappinessManagerScript.Level;
                DotManagerScript.TotalScore += Total;
                DotManagerScript.HighScore.text = "" + DotManagerScript.TotalScore;
                // bombs do a defualt 10 Exp
                
                HappinessManagerScript.HappinessSliderValue += BombEXP;
                HappinessManagerScript.HappinessBar();
            }
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
         if (!CollidedNodes.Contains(collision.gameObject))
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
                PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonEnable();

            }
            if (Timer >= -0.25f)
            {
            

                if (collision.gameObject.tag == "DeadNode" || collision.transform.gameObject.layer == 16)
                {
                    Destroy(collision.gameObject);
                }
                else if (collision.gameObject.tag == "Rainbow" )
                {
                    // do nothing
                }
                else
                {
                    collision.gameObject.transform.position = new Vector3(100, 0, 0);
                    collision.gameObject.GetComponent<DotScript>().SelfDestruct = true;
                }
            }
            else if (Timer <= -1)
            {
                DestoryMe();
            }

        }
        

    }
}
