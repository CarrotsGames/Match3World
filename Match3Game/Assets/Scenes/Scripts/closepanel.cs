using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closepanel : MonoBehaviour
{


    public GameObject unlockScreen;

    public GameObject eggUnlock;
    public GameObject scrUnlock;
    public GameObject shuffleUnlock;
    public GameObject bombUnlock;
    public GameObject multiUnlock;


    public void TurnOffTab()
    {
        unlockScreen.SetActive(false);
        eggUnlock.SetActive(false);
        scrUnlock.SetActive(false);
        shuffleUnlock.SetActive(false);
        bombUnlock.SetActive(false);
        multiUnlock.SetActive(false);

    }
}
