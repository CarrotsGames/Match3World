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

    public void EggPushed()
    {
        if (pushed == false)
        {
            anim.SetBool("Push", true);
            anim.SetBool("Again", false);
            creatureEggs.SetActive(true);
            monthlyChallenge.SetActive(false);
        }else
        {
            anim.SetBool("Push", false);
            anim.SetBool("Again", true);
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
        }else
        {
            anim.SetBool("Push", false);
            anim.SetBool("Again", true);
        }
        
        
    }



}
