using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MooblingSave 
{
    public int Level;
    public int EXP;
    public int TotalEXP = 250;


    public MooblingSave(HappinessManager Moobling)
    {
        Level = Moobling.Level;
        EXP = (int)Moobling.HappinessSliderValue;
        TotalEXP = Moobling.HappinessClamp;
    }
    
}
