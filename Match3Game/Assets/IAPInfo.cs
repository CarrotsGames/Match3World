using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPInfo : MonoBehaviour
{

    public GameObject info;
    private bool infoUp;

    public void LoadInfo()
    {
        if (infoUp == false)
        {
            info.SetActive(true);
            infoUp = true;
        }else
        {
            info.SetActive(false);
            infoUp = false;
        }
    }
}
