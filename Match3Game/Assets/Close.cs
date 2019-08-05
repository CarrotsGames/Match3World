using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject menu;



    public void CloseMenu()
    {
        menu.SetActive(false);
    }
}
