using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGameplay : MonoBehaviour
{
    public GameObject tutCanvus;

    public GameObject[] connectionStep;

    private GameObject dotManagerGameObj;
    private DotManager dotManagerScript;
    public Animator powerUpAnim;

    int movesDone;
    public void Start()
    {
        dotManagerGameObj = GameObject.FindGameObjectWithTag("DotManager");
        dotManagerScript = dotManagerGameObj.GetComponent<DotManager>();
        tutCanvus.SetActive(true);
        connectionStep[0].SetActive(true);

    }
    private void Update()
    {
        if (dotManagerScript.ConnectionMade)
        {
            movesDone++;
            dotManagerScript.ConnectionMade = false;
            if (movesDone == 5)
            {
                tutCanvus.SetActive(true);
                connectionStep[1].SetActive(true);
            }
        }

        // IF DONE WITH TUTORIAL
        // if()
        // {
        // PlayerPrefs.SetInt("FTS", 1);
        // }
       
    }
    public void CloseTut()
    {
        connectionStep[0].SetActive(false);
        connectionStep[1].SetActive(false);
        tutCanvus.SetActive(false);
    }
    public void CloseTut2()
    {
        connectionStep[0].SetActive(false);
        connectionStep[1].SetActive(false);
        tutCanvus.SetActive(false);
        powerUpAnim.SetBool("StartAnim", true);
    }
    


}
