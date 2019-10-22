using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] tutParts;
    public GameObject tutorialCanvus;


    public void Start()
    {
        tutParts[0].SetActive(true);
    }


    public void LoadPart2()
    {
        tutParts[0].SetActive(false);
        tutParts[1].SetActive(true);
    }
    public void LoadPart3()
    {
        tutParts[1].SetActive(false);
        tutParts[2].SetActive(true);
    }
    public void LoadPart4()
    {
        tutParts[2].SetActive(false);
        tutParts[3].SetActive(true);
    }
    public void LoadPart5()
    {
        tutParts[3].SetActive(false);
        tutParts[4].SetActive(true);
    }
    public void LoadPart6()
    {
        tutParts[4].SetActive(false);
        tutParts[5].SetActive(true);
    }
    public void LoadPart7()
    {
        tutParts[5].SetActive(false);
        tutParts[6].SetActive(true);
    }
    public void LoadPart8()
    {
        tutParts[6].SetActive(false);
        tutParts[7].SetActive(true);
    }
    public void Close()
    {
        tutorialCanvus.SetActive(false);
    }




}
