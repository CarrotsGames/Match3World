using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DisablePowerUps : MonoBehaviour
{
   public bool DisableFreeze;
   public bool DisableSM;
    public GameObject[] PowerUps;
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
        if (!GameObject.Find("CHALLENGE"))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                PowerUps[i].gameObject.layer = 2;
                PowerUps[i].GetComponent<Button>().enabled = false;
                PowerUps[i].GetComponent<Image>().color = Color.gray;
            }
        }
    }
    public void DisableNodes()
    {
        if (!GameObject.Find("CHALLENGE"))
        {
            // DisableSM = false;
            // PlayerPrefs.SetInt("DISABLESM", (DisableSM ? 1 : 0));
            //
            DisableSM = (PlayerPrefs.GetInt("DISABLESM") != 0);

            if (DisableSM)
            {
                PowerUps[3].gameObject.layer = 2;
                PowerUps[3].GetComponent<Button>().enabled = false;
                PowerUps[3].GetComponent<Image>().color = Color.gray;
            }
            else
            {
                PowerUps[3].gameObject.layer = 5;
                PowerUps[3].GetComponent<Button>().enabled = true;
                PowerUps[3].GetComponent<Image>().color = Color.white;
            }
        }
    }
    public void OnButtonEnable()
    {
        for (int i = 0; i < PowerUps.Length; i++)
        {
            if (i == 3)
            {
                DisableNodes();
            }
            else
            {
                PowerUps[i].gameObject.layer = 5;
                PowerUps[i].GetComponent<Button>().enabled = true;
                PowerUps[i].GetComponent<Image>().color = Color.white;
            }   
            
        }
    }
}
