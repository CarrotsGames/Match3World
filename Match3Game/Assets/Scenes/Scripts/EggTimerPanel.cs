using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggTimerPanel : MonoBehaviour {


    public GameObject eggPanel;

    public GameObject arrowIn;
    public GameObject arrowOut;

    private Animator anim;

    public bool isOpen;


    private void Start()
    {
        anim = GetComponent<Animator>();
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
