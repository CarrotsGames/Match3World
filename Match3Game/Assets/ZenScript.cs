using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenScript : MonoBehaviour
{
    public GameObject zenButton;
    public GameObject challengeButton;
    public GameObject challengeGameObject;

    public GameObject zenText;
    public GameObject challengeText;


    public GameObject challengeCanvus;
    public GameObject[] mooblingChallengePanels;

    private void Start()
    {
        // make sure that this is disabled at beggining of game
        challengeGameObject.SetActive(false);

    }
    public void OpenGobu()
    {
        mooblingChallengePanels[0].SetActive(true);
        challengeCanvus.SetActive(true);
    }
    public void OpenBinkie()
    {
        mooblingChallengePanels[1].SetActive(true);
        challengeCanvus.SetActive(true);
    }
    public void OpenKoko()
    {
        mooblingChallengePanels[2].SetActive(true);
        challengeCanvus.SetActive(true);
    }
    public void OpenCrius()
    {
        mooblingChallengePanels[3].SetActive(true);
        challengeCanvus.SetActive(true);
    }
    public void OpenSauco()
    {
        mooblingChallengePanels[4].SetActive(true);
        challengeCanvus.SetActive(true);
    }
    public void OpenChickPea()
    {
        mooblingChallengePanels[5].SetActive(true);
        challengeCanvus.SetActive(true);
    }
    public void OpenSquishy()
    {
        mooblingChallengePanels[6].SetActive(true);
        challengeCanvus.SetActive(true);
    }
    public void OpenOkami()
    {
        mooblingChallengePanels[7].SetActive(true);
        challengeCanvus.SetActive(true);
    }
    public void OpenIdiasurous()
    {
        mooblingChallengePanels[8].SetActive(true);
        challengeCanvus.SetActive(true);
    }
    public void OpenConus()
    {
        mooblingChallengePanels[9].SetActive(true);
        challengeCanvus.SetActive(true);
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
        mooblingChallengePanels[9].SetActive(false);
    }

    public void ChallengeMode()
    {
        challengeGameObject.SetActive(false);
        zenButton.SetActive(true);
        challengeButton.SetActive(false);
        zenText.SetActive(true);
        challengeText.SetActive(false);
    }


    public void ZenMode()
    {
        challengeGameObject.SetActive(true);
        challengeButton.SetActive(true);
        zenButton.SetActive(false);
        challengeText.SetActive(true);
        zenText.SetActive(false);
    }






}
