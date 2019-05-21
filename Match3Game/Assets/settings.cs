using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour {

    public GameObject settingsMenu;

    public GameObject sceneAudio;

    public bool musicOff;


    public void TurnOffTab()
    {
        settingsMenu.SetActive(false);
    }

    public void OpenMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void NoMusic()
    {
        if (musicOff == true)
        {
            sceneAudio.SetActive(true);
            musicOff = false;
        }else
        {
            sceneAudio.SetActive(false);
            musicOff = true;
        }
      
    }
}
