using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitions : MonoBehaviour {

    public GameObject tranistion;
    public GameObject gameController;
    private CreatureSelect creatureScript;

    public AudioSource audioData;
    public AudioSource giggleData;

    public void Awake()
    {
       //tranistion.SetActive(false);
        creatureScript = gameController.GetComponent<CreatureSelect>();

        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }

    public void SelectStage()
    {
        creatureScript.LoadCreatureLevels();
    }


    public void PopSound()
    {
        audioData.Play(0);
    }

    public void GiggleSound()
    {
        giggleData.Play(0);
    }





}
