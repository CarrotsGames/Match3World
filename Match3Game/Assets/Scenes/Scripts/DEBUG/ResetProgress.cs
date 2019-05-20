using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgress : MonoBehaviour {

    public bool Reset;
    public GameObject NodeManager;
    public GameObject Unlockables;
	// Use this for initialization
	void Start () {
        Reset = false;

    }
    private void Update()
    {
         if (Reset)
        {
            Debug.Log("RESET");
            NodeManager.GetComponent<DotManager>().TotalScore = 0;
            // Unlockables.GetComponent<UnlockableCreatures>().UnlockableMoobling[0] = "";
            PlayerPrefs.SetString("BINKY", "Nothing");
            //  Unlockables.GetComponent<UnlockableCreatures>().UnlockableMoobling[1] = "";
            PlayerPrefs.SetString("KOKO", "Nothing");
            PlayerPrefs.SetString("CRIUS", "Nothing");

            PlayerPrefs.SetString("UNLOCKED", "Nothing");
        }
    }
    // Update is called once per frame
    public void ResetData ()
    {
        Reset = true;
    }
}
