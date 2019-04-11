using UnityEngine;
using System.Collections;

public class BombExplodeScript : MonoBehaviour
{
    float Timer = 1;
    public GameObject Board;
    public GameObject ExplosionEffect;


    // Update is called once per frame
    private void Start()
    {
        // 12 = BOMB Layer
        // 11 = WALL layer
        // ignroe collisions Between this layer and this layer
        Physics2D.IgnoreLayerCollision( 12, 11);
     
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
    
        if (Timer < 0 )
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
