using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonthlyChallengePanel : MonoBehaviour
{

    public Animator panelAnim;
    public GameObject inArrow;
    public GameObject outArrow;

    public bool panelIsOut = false;



    public void MonthlyMove()
    {
        if (panelIsOut == false)
        {
            panelAnim.SetBool("Panel Out",true);
            panelIsOut = true;

        }
        else if (panelIsOut)
        {
            panelIsOut = false;
            panelAnim.SetBool("Panel Retract", true);
        }
    }


    public void HardReset()
    {
        if (panelIsOut)
        {
            inArrow.SetActive(true);
            outArrow.SetActive(false);
            panelAnim.SetBool("Panel Out", false);
        }else
        {
            inArrow.SetActive(false);
            outArrow.SetActive(true);
            panelAnim.SetBool("Panel Retract", false);
        }
    }

}
