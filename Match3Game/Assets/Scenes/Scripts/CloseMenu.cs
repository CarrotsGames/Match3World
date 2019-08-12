using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour {

    public GameObject unlockScreen;
    public GameObject egg;
    public GameObject superCR;
    public GameObject shuffle;
    public GameObject bomb;
    public GameObject multi;
    public GameObject multiFreeze;


    public void TurnOffTab()
    {
        unlockScreen.SetActive(false);
        egg.SetActive(false);
        superCR.SetActive(false);
        shuffle.SetActive(false);
        bomb.SetActive(false);
        multi.SetActive(false);
        multiFreeze.SetActive(false);
    }

}
