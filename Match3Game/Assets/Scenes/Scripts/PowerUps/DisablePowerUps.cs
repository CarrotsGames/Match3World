using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisablePowerUps : MonoBehaviour
{
    
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
    public void OnButtonEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "FreezeMultiplier")
            {
                // if the slowdownTime is active keep button disabled
                if (transform.GetChild(i).GetComponent<SlowDownHapiness>().SlowDownTime)
                {
                    transform.GetChild(i).gameObject.layer = 2;
                    transform.GetChild(i).GetComponent<Button>().enabled = false;
                    transform.GetChild(i).GetComponent<Image>().color = Color.gray;
                }
                // if not enable the button
                else
                {
                    transform.GetChild(i).gameObject.layer = 5;
                    transform.GetChild(i).GetComponent<Button>().enabled = true;
                    transform.GetChild(i).GetComponent<Image>().color = Color.white;
                }
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
