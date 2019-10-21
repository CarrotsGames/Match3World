using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    private Text NewLevel;
    private GameObject HappinessManagerGameObj;
    private HappinessManager HappinessManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        HappinessManagerGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessManagerGameObj.GetComponent<HappinessManager>();
        NewLevel = GetComponent<Text>();  
    }

    // Update is called once per frame
    void Update()
    {
        NewLevel.text = "" + HappinessManagerScript.Level;
    }
}
