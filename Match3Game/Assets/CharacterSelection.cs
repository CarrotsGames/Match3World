using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject popUpCanvus;

    public GameObject[] characterPanels;

    public void CloseEverything()
    {
        characterPanels[0].SetActive(false);
        characterPanels[1].SetActive(false);
        characterPanels[2].SetActive(false);
        characterPanels[3].SetActive(false);
        characterPanels[4].SetActive(false);
        characterPanels[5].SetActive(false);
        characterPanels[6].SetActive(false);
        characterPanels[7].SetActive(false);
        characterPanels[8].SetActive(false);
        popUpCanvus.SetActive(false);
    }
    public void OpenBinkie()
    {
        popUpCanvus.SetActive(true);
        characterPanels[0].SetActive(true);
    }
    public void OpenKoko()
    {
        popUpCanvus.SetActive(true);
        characterPanels[1].SetActive(true);
    }
    public void OpenCrius()
    {
        popUpCanvus.SetActive(true);
        characterPanels[2].SetActive(true);
    }
    public void OpenSauco()
    {
        popUpCanvus.SetActive(true);
        characterPanels[3].SetActive(true);
    }
    public void OpenSquishy()
    {
        popUpCanvus.SetActive(true);
        characterPanels[4].SetActive(true);
    }
    public void OpenChickPea()
    {
        popUpCanvus.SetActive(true);
        characterPanels[5].SetActive(true);
    }
    public void OpenCronus()
    {
        popUpCanvus.SetActive(true);
        characterPanels[6].SetActive(true);
    }
    public void OpenOkami()
    {
        popUpCanvus.SetActive(true);
        characterPanels[7].SetActive(true);
    }
    public void OpenIda()
    {
        popUpCanvus.SetActive(true);
        characterPanels[8].SetActive(true);
    }




}
