using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseChallenge : MonoBehaviour
{

    public GameObject[] challengeFaces;
    public GameObject challengeCanvus;


    public void PanelReset()
    {
        challengeCanvus.SetActive(false);
        for (int i = 0; i < challengeFaces.Length; i++)
        {
            challengeFaces[i].SetActive(false);
        }
    }




}
