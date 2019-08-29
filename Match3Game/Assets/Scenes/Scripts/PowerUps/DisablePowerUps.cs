using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisablePowerUps : MonoBehaviour
{
   public bool DisableFreeze;
   public bool DisableSM;
    private void Start()
    {
        DisableNodes();
    }
    private void Update()
    {
 
        if(Input.GetKeyDown(KeyCode.G))
        {
            OnButtonDisable();
        }
    }
    public void OnButtonDisable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.layer = 2;
            transform.GetChild(i).GetComponent<Button>().enabled = false;
            transform.GetChild(i).GetComponent<Image>().color = Color.gray;
        }
    }
    public void DisableNodes()
    {
       // DisableSM = false;
       // PlayerPrefs.SetInt("DISABLESM", (DisableSM ? 1 : 0));
       //
        DisableSM = (PlayerPrefs.GetInt("DISABLESM") != 0);

        if(DisableSM)
        {
            transform.Find("SuperMutliplier").gameObject.layer = 2;
            transform.Find("SuperMutliplier").GetComponent<Button>().enabled = false;
            transform.Find("SuperMutliplier").GetComponent<Image>().color = Color.gray;
        }
        else
        {
            transform.Find("SuperMutliplier").gameObject.layer = 5;
            transform.Find("SuperMutliplier").GetComponent<Button>().enabled = true;
            transform.Find("SuperMutliplier").GetComponent<Image>().color = Color.white;
        }
    }
    public void OnButtonEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if ( transform.GetChild(i).name == "SuperMutliplier")
            {
                DisableNodes();
            }
            else
            {
                transform.GetChild(i).gameObject.layer = 5;
                transform.GetChild(i).GetComponent<Button>().enabled = true;
                transform.GetChild(i).GetComponent<Image>().color = Color.white;
            }   
            
        }
    }
}
