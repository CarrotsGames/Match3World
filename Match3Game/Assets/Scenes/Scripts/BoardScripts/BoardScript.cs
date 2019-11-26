using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    int Rand;
    public int Limit;
  
    public float DelaySpawn;
 
    // Start is called before the first frame update
    [HideInInspector]
    public ObjectPooler ObjectPoolerScript;
    string[] Colours = {"Red" ,"Blue","Green","Pink" };
    private void Start()
    {
      
        // if no delay time is set automatically set it to 1 
        if (DelaySpawn == 0)
        {
            DelaySpawn = 1;
        }
    
        ObjectPoolerScript = ObjectPooler.Instance;          
    }
    private void FixedUpdate()
    {
        if (DelaySpawn < 0)
        {
            ChildCount();
        }
        else 
        {
            DelaySpawn -= Time.deltaTime;
        }
    }
    void InitialSpawn()
    {
        for (int i = 0; i < Limit; i++)
        {
            Randomise();
            Spawn();
        }
    }
    public void ChildCount()
    {

        if (transform.childCount < Limit)
        {
            Randomise();
            // Rand = Random.Range(0, 3);
            Spawn();

        }
    }
    void Randomise()
    {
        Rand = Random.Range(0, 4);
        
    }
    void Spawn()
    {
        ObjectPooler.Instance.SpawnFromPool(Colours[Rand], transform.position, Quaternion.identity);
    }
  
}
