using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used to turn on levelup canvas stuff
public class LevelUpCanvas : MonoBehaviour
{
    
    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnCanvas();
        }
    }
    public void TurnOnCanvas()
    {
        // Enables info on canvas 
        transform.GetChild(0).gameObject.SetActive(true);
        // gets text compenents so they can update with new level and 
        // gold reward
        GameObject LevelUpText = GameObject.Find("LevelUpText");
        LevelUpText.GetComponent<LevelUp>().ShowNewLevel();
    }

   
}
