using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombExplodeScript : MonoBehaviour
{
    float Timer = 1;
    public GameObject Board;
    public GameObject ExplosionEffect;
    public List<GameObject> CollidedNodes;
    public AudioClip Audio;
    private DotManager DotManagerScript;
    private GameObject DotManagerObj;
    private AudioSource Source;
    // Update is called once per frame
    private void Start()
    {
        // 12 = BOMB Layer
        // 11 = WALL layer
        // ignroe collisions Between this layer and this layer
        Physics2D.IgnoreLayerCollision( 12, 11);
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        Source = GetComponent<AudioSource>();
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer < 0)
        {
            Source.clip = Audio;
            Source.Play();
            Instantiate(ExplosionEffect,transform.position, Quaternion.identity);
        }
       
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
            DotManagerScript.TotalScore += CollidedNodes.Count * DotManagerScript.Multipier;
            DotManagerScript.HighScore.text = "" + DotManagerScript.TotalScore;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            CollidedNodes.Clear();

        }
    }
}
