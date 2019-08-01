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
            transform.GetChild(i).GetComponent<Button>().enabled = false;
            transform.GetChild(i).GetComponent<Image>().color = Color.gray;
        }
    }
    public void OnButtonEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
 
            transform.GetChild(i).GetComponent<Button>().enabled = true;
            transform.GetChild(i).GetComponent<Image>().color = Color.white;

        }
    }
}
