using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowReciever : MonoBehaviour {

    public GameObject gameManager;
    private CreatureSelect creatureSelectScript;

	// Use this for initialization
	void Awake () {
       // creatureSelectScript = gameManager.GetComponent<CreatureSelect>();
	}


    public void RightButtonClicked()
    {
        creatureSelectScript.RightArrowClicked();
    }

    public void LeftButtonClicked()
    {
        creatureSelectScript.LeftArrowClicked();
    }

    public void CreatureClicked()
    {
        creatureSelectScript.StartTransitions();
    }

}
