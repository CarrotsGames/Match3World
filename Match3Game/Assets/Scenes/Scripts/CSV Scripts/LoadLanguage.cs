using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLanguage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextAsset LanguageData = Resources.Load<TextAsset>("Mooblings Text - Sheet1");
        string[] Data = LanguageData.text.Split(new char[] { '\n' });
       // LanguageData.text
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
