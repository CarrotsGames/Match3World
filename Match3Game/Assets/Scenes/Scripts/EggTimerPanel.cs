using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggTimerPanel : MonoBehaviour {


    public GameObject eggPanel;

    public GameObject arrowIn;
    public GameObject arrowOut;

    private Animator anim;

    public bool isOpen;

    private StoreScript store;
    public GameObject EggHatchObj;

    public Button skipButton;

    private void Start()
    {
        anim = GetComponent<Animator>();
        store = GetComponent<StoreScript>();
        skipButton.interactable = false;
    }

    public void Update()
    {
        // If the countdown has begun 
        if (EggHatchObj.GetComponent<EggHatch>().StartCountDown)
        {
            // Egg panel is active
            eggPanel.SetActive(true);
        }
        else
        {
            eggPanel.SetActive(false);

        }


    }


    //is for the button so it actually opens
    public void OpenPanel ()
    {
        if (isOpen == false)
        {
            anim.SetBool("StartAnim", true);
            isOpen = true;
            skipButton.interactable = true;

        } else
        {
            anim.SetBool("CloseAnim", true);
            isOpen = false;
        }
       
    }



    //Is for the animation for the panel
    public void HardReset()
    {
        if (isOpen)
        {
            arrowIn.SetActive(true);
            arrowOut.SetActive(false);
            anim.SetBool("StartAnim", false);
        }
        else
        {
            arrowIn.SetActive(false);
            arrowOut.SetActive(true);
            anim.SetBool("CloseAnim", false);
        }

    }

}
