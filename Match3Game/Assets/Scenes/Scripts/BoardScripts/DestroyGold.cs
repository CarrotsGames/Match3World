using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGold : MonoBehaviour
{

    public bool StartDestroyGold;
    private float Timer;
    private int Index;
    public List<GameObject> GoldList = new List<GameObject>();
    private void Start()
    {
        StartDestroyGold = false;
        Timer = 0.1f;
        Index = 0;
    }
    // Update is called once per frame
    void Update()
    {
         // Begins the process
        if (StartDestroyGold)
        {
            StartDestory();
        }
        // when both destroy node lists are less than 0 the player can play
        if (GoldList.Count < 1 && GetComponent<DestroyNodes>().ComboList.Count < 1)
        {
 
            GetComponent<DotManager>().CanPlay = true;
            Index = 0;
            GoldList.Clear();
        }
        else
        {
            GetComponent<DotManager>().CanPlay = false;
         }

    }
   
   public void StartGoldDestroy()
    {
        // puts gold into a new list to begin the destroging process
        for (int i = 0; i < GetComponent<DotManager>().Gold.Count; i++)
        {
            GoldList.Add(GetComponent<DotManager>().Gold[i]);
        }

        StartDestroyGold = true;
     }
   public void StartDestory()
    {
        // Delays the destruction of each node to give it a neat look
        Timer -= Time.deltaTime;
        if(Timer < 0)
        {
            if (GoldList.Count >= 0)
            {
                Destroy();
                Timer = 0.1f;
            }
            
        }
     
    }

    public void Destroy()
    {
        // while the index is greater than the goldlist count
        if (Index < GoldList.Count)
        {
            Instantiate(GetComponent<DotManager>().ParticleEffectYellow, GoldList[Index].transform.position, Quaternion.identity);
            GoldList[Index].transform.position += new Vector3(100, 0, 0);
            GoldList[Index].GetComponent<DotScript>().SelfDestruct = true;
            Index++;
        }
        else
        {
            GoldList.Clear();
            StartDestroyGold = false;

        }
    }

 
}
