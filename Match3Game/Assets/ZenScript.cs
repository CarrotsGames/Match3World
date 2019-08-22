using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenScript : MonoBehaviour
{

    public GameObject challengeCanvus;
    public GameObject[] mooblingChallengePanels;

    public void OpenGobu()
    {
        mooblingChallengePanels[0].SetActive(true);
        challengeCanvus.SetActive(true);
    }
    public void OpenBinkie()
    {

    }
    public void OpenKoko()
    {

    }
    public void OpenCrius()
    {

    }
    public void OpenSauco()
    {

    }
    public void OpenChickPea()
    {

    }
    public void OpenSquishy()
    {

    }
    public void OpenOkami()
    {

    }
    public void OpenIdiasurous()
    {

    }

    public void RestartAll()
    {
        mooblingChallengePanels[0].SetActive(false);
        mooblingChallengePanels[1].SetActive(false);
        mooblingChallengePanels[2].SetActive(false);
        mooblingChallengePanels[3].SetActive(false);
        mooblingChallengePanels[4].SetActive(false);
        mooblingChallengePanels[5].SetActive(false);
        mooblingChallengePanels[6].SetActive(false);
        mooblingChallengePanels[7].SetActive(false);
        mooblingChallengePanels[8].SetActive(false);
    }




}
