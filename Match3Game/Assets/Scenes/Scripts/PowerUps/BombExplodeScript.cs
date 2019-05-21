using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombExplodeScript : MonoBehaviour
{
    float Timer = 1;
    public GameObject Board;
    public GameObject ExplosionEffect;
    public List<GameObject> CollidedOutfits;
    private DotManager DotManagerScript;
    private GameObject DotManagerObj;

    // Update is called once per frame
    private void Start()
    {
        // 12 = BOMB Layer
        // 11 = WALL layer
        // ignroe collisions Between this layer and this layer
        Physics2D.IgnoreLayerCollision( 12, 11);
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer < 0)
        {
        Instantiate(ExplosionEffect,transform.position, Quaternion.identity);
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (CollidedOutfits.Contains(collision.gameObject))
        {
            Debug.Log("Already contains me");
        }
        else
        {
            CollidedOutfits.Add(collision.gameObject);

        }
        if (Timer < 0 )
        {
            DotManagerScript.TotalScore += CollidedOutfits.Count * DotManagerScript.Multipier;
            DotManagerScript.HighScore.text = "" + DotManagerScript.TotalScore;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            CollidedOutfits.Clear();

        }
    }
}
