using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggTimerPanel : MonoBehaviour {


    public GameObject eggPanel;

    public GameObject arrowIn;
    public GameObject arrowOut;

    private Animator anim;

    public bool isOpen;

    private StoreScript store;
    public GameObject EggHatchObj;

    private void Start()
    {
        anim = GetComponent<Animator>();
        store = GetComponent<StoreScript>();
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



    public void OpenPanel ()
    {
        if (isOpen == false)
        {
            anim.SetBool("StartAnim", true);
            isOpen = true;

        } else
        {
            anim.SetBool("CloseAnim", true);
            isOpen = false;
        }
       
    }




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
