﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyNodes : MonoBehaviour {


    public bool StartDestroy;
    int Index;
    int ComboNum;
    string Colour;
    private GameObject CompanionGameObj;
    private CompanionScript CompanionScriptRef;
    public GameObject ComboGameObj;
    public Text ComboText;

    // Use this for initialization
    void Start ()
    {
        CompanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        CompanionScriptRef = CompanionGameObj.GetComponent<CompanionScript>();
        ComboGameObj.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        // Begins the node destroy process
        if (StartDestroy)
        {
            StartCoroutine(DestoyNodes());
            ComboGameObj.SetActive(true);

        }

    }
    // Destorys nodes in the eatingPeices list
    IEnumerator DestoyNodes()
    {
       // Set time for delay
        WaitForSeconds wait = new WaitForSeconds(0.15f);

        for (int i = 0; i < CompanionScriptRef.EatingPeices.Count; i++)
        {
            Index = i;
            ComboText.text = "COMBO:" + ComboNum;

            PlayParticle();
            Destroy(CompanionScriptRef.EatingPeices[i].gameObject);
            // Delays forloop So that nodes are destroyed one by one
            ComboNum += 1;

            yield return wait;

        }
        ComboGameObj.SetActive(false);
        ComboNum = 0;

        StartDestroy = false;
        // Resest list
        CompanionScriptRef.EatingPeices.Clear();

    }

    // plays particle effect for each node
    void PlayParticle()
    {
        // plays particle effect at list index and position of current node
        switch (CompanionScriptRef.EatingPeices[Index].tag)
        {
            case "Red":
                {
                    Instantiate(GetComponent<DotManager>().ParticleEffectPink, CompanionScriptRef.EatingPeices[Index].transform.position, Quaternion.identity);

                }
                break;
            case "Blue":
                {
                    Instantiate(GetComponent<DotManager>().ParticleEffectBlue, CompanionScriptRef.EatingPeices[Index].transform.position, Quaternion.identity);

                }
                break;
            case "Yellow":
                {
                    Instantiate(GetComponent<DotManager>().ParticleEffectPurple, CompanionScriptRef.EatingPeices[Index].transform.position, Quaternion.identity);
                }
                break;
            case "Green":
                {
                    Instantiate(GetComponent<DotManager>().ParticleEffectYellow, CompanionScriptRef.EatingPeices[Index].transform.position, Quaternion.identity);
                }
                break;
        }

    }
}