using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitions : MonoBehaviour {

    public GameObject tranistion;
    public GameObject gameController;
    private CreatureSelect creatureScript;

    public void Awake()
    {
        tranistion.SetActive(false);
        creatureScript = gameController.GetComponent<CreatureSelect>();
    }

    public void SelectStage()
    {
        creatureScript.LoadCreatureLevels();
    }





}
