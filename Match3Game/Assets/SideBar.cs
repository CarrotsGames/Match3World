using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SideBar : MonoBehaviour
{
    public GameObject sideBar;
    public GameObject creatureEggs;
    public GameObject monthlyChallenge;

    public Animator anim;

    public bool pushed;

    public bool eggPanel;
    public bool monthlyPanel;

    public void EggPushed()
    {
        if (pushed == false)
        {
            anim.SetBool("Push", true);
            anim.SetBool("Again", false);
            creatureEggs.SetActive(true);
            monthlyChallenge.SetActive(false);
            pushed = true;
            eggPanel = true;
        }
        else if (pushed == true && eggPanel == true)
        {
            anim.SetBool("Push", false);
            anim.SetBool("Again", true);
            pushed = false;
            eggPanel = false;

        }
        if (pushed == true && monthlyPanel == true)
        {
            monthlyChallenge.SetActive(false);
            creatureEggs.SetActive(true);
            eggPanel = true;
            monthlyPanel = false;
        }



    }
    public void ChallengePushed()
    {
        if (pushed == false)
        {
            anim.SetBool("Push", true);
            anim.SetBool("Again", false);
            creatureEggs.SetActive(false);
            monthlyChallenge.SetActive(true);
            pushed = true;
            monthlyPanel = true;

        }else if (pushed == true && monthlyPanel == true)
        {
            anim.SetBool("Push", false);
            anim.SetBool("Again", true);
            pushed = false;
            monthlyPanel = false;
        }
        if (pushed == true && eggPanel == true)
        {
            creatureEggs.SetActive(false);
            monthlyChallenge.SetActive(true);
            eggPanel = false;
            monthlyPanel = true;
        }
        
    }

    public void CloseSideBar()
    {
        if (pushed == true)
        {
            anim.SetBool("Push", false);
            anim.SetBool("Again", true);
            pushed = false;
            monthlyPanel = false;
            eggPanel = false;
        }
    }





}
