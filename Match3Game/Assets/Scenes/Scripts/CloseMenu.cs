using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour {

    public GameObject unlockScreen;

    public void TurnOffTab()
    {
        unlockScreen.SetActive(false);
    }

}
