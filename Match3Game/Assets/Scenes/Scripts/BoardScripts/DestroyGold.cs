using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGold : MonoBehaviour
{

    public bool StartDestroyGold;
    private float Timer;
    private int Index;
    public List<GameObject> GoldList = new List<GameObject>();
    private GameObject PowerUpGameObj;
    bool Reset;
    private void Start()
    {
        PowerUpGameObj = GameObject.Find("PowerUps");
        Reset = false;
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
            PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonDisable();

            StartDestory();
        }
        if (Reset)
        {
        

            GetComponent<DotManager>().CanPlay = true;
            Index = 0;
            GoldList.Clear();
         
            Reset = false;
        }
    }
   
   public void StartGoldDestroy()
    {
        GoldList.Clear();
        // puts gold into a new list to begin the destroging process
        for (int i = 0; i < GetComponent<DotManager>().Gold.Count; i++)
        {
 
            GoldList.Add(GetComponent<DotManager>().Gold[i]);
        }
        GetComponent<DotManager>().Gold.Clear();
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
            Instantiate(GetComponent<DotManager>().ParticleEffectGold, GoldList[Index].transform.position, Quaternion.identity);
            GoldList[Index].transform.position += new Vector3(100, 0, 0);
            GoldList[Index].GetComponent<DotScript>().SelfDestruct = true;
            Index++;
        }
        else
        {
            GoldList.Clear();
            StartDestroyGold = false;
            PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonEnable();

        }
        if(Index == GoldList.Count)
        {
            Reset = true;
        }
    }

 
}
