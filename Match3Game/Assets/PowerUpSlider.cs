using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlider : MonoBehaviour
{
    public Animator powerUpAnim;

    public bool open;


    public void Start()
    {
        open = false;
    }


    public void ButtonAnim()
    {
        if(open == false)
        {
            powerUpAnim.SetBool("Open", true);
            powerUpAnim.SetBool("Close", false);
            open = true;
        }
        else
        {
            powerUpAnim.SetBool("Close", true);
            powerUpAnim.SetBool("Open", false);
            open = false;
        }
    }







}
