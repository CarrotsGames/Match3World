using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSelect : MonoBehaviour {

    public GameObject gobu;
    public GameObject koko;
    public GameObject binky;

    public bool middleCreature = true;
    public bool leftCreature = false;
    public bool rightCreature = false;


    void Awake()
    {
        gobu.SetActive(true);
        koko.SetActive(false);
        binky.SetActive(false);
        rightCreature = false;
        middleCreature = true;
        leftCreature = false;
    }
    public void RightArrowClicked()
    {
        if(middleCreature == true)
        {
            gobu.SetActive(false);
            koko.SetActive(true);
            rightCreature = true;
            middleCreature = false;
        }
        if(leftCreature == true)
        {
            gobu.SetActive(true);
            binky.SetActive(false);
            leftCreature = false;
            middleCreature = true;
        }
        if(rightCreature == true)
        {
            koko.SetActive(false);
            binky.SetActive(true);
            rightCreature = false;
            leftCreature = true;
        }
    }
    public void LeftArrowClicked()
    {
        if(middleCreature == true)
        {
            gobu.SetActive(false);
            binky.SetActive(true);
            leftCreature = true;
            middleCreature = false;
        }
        if(leftCreature == true)
        {
            binky.SetActive(false);
            koko.SetActive(true);
            leftCreature = false;
            rightCreature = true;
        }
        if(rightCreature == true)
        {
            koko.SetActive(false);
            gobu.SetActive(true);
            rightCreature = false;
            middleCreature = true;
        }
    }


 
}
