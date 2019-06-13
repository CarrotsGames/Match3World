using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyNodes : MonoBehaviour {
    // Yeild return values
    public float ComboSpeed;
    public float ComboVanishSpeed;
    public bool StartDestroy;
    int Index;
    int ComboNum;
    private GameObject CompanionGameObj;
    private CompanionScript CompanionScriptRef;
    public GameObject ComboGameObj;
    public Text ComboText;
    public Text ComboScore;
    bool CanChangeText;
    private bool SlowMotionOn;
    public float SlowMotionTimer;
    private float SlowMotionStorage;
    // Use this for initialization
    void Start ()
    {
         CompanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        CompanionScriptRef = CompanionGameObj.GetComponent<CompanionScript>();
        ComboGameObj.SetActive(false);
        SlowMotionOn = false;
        SlowMotionStorage = SlowMotionTimer;

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
        if(CanChangeText)
        {
            StartCoroutine(DisplayComboScore());

        }
        if(SlowMotionOn)
        {

            SlowMotionTimer -= Time.deltaTime;
  
            Time.timeScale = 0.1f;
            
        }
        if (SlowMotionTimer < 0)
        {
            SlowMotionOn = false;
            Time.timeScale = 1.0f;
            SlowMotionTimer = SlowMotionStorage;
        }
    }
    // Destorys nodes in the eatingPeices list
    IEnumerator DestoyNodes()
    {
       // Set time for delay
        WaitForSeconds wait = new WaitForSeconds(ComboSpeed);
        WaitForSeconds SlowMotion = new WaitForSeconds(10);

        for (int i = 0; i < CompanionScriptRef.EatingPeices.Count; i++)
        {

            Index = i;
            if (CompanionScriptRef.EatingPeices.Count > 6  )
            {
                if(ComboNum < 1)
                {
                    SlowMotionOn = true;
                }
                ComboText.text = "BIG \nCOMBO:" + ComboNum;
                bool Vibrate = true;
                if (Vibrate)
                {
                    Handheld.Vibrate();
                    Vibrate = false;

                }
            }
            // Displays the combo currently happening in game
            else if (CompanionScriptRef.EatingPeices.Count > 4)
            {
                ComboText.text = "COMBO:" + ComboNum;
                bool Vibrate = true;
                if (Vibrate)
                {
                    Handheld.Vibrate();
                    Vibrate = false;

                }
               
            }
           
            // destroys current peice
            Destroy(CompanionScriptRef.EatingPeices[i].gameObject);
            // plays that peices particle depending on colour
            PlayParticle();
            // Delays forloop So that nodes are destroyed one by one
            ComboNum += 1;

            yield return wait;

        }
        // resets the combonumber 
        ComboNum = 0;
        // resets the comboText
        ComboText.text = "" ;
        // disables the StartDestroy void
        StartDestroy = false;
        // Resest list
        if (CompanionScriptRef.EatingPeices.Count > 4)
        {
            CanChangeText = true;
        }
        CompanionScriptRef.EatingPeices.Clear();

    }

    // Displays the ComboScore Text
    IEnumerator DisplayComboScore()
    {
         WaitForSeconds ComboVanish = new WaitForSeconds(ComboVanishSpeed);
        ComboText.text = "Score:" + GetComponent<DotManager>().ComboScore;
        // waits comboVanish value until it continues
        yield return ComboVanish;
        //resets combo text 
        ComboText.text = "";
        //disables combo gameobject 
        ComboGameObj.SetActive(false);
        CanChangeText = false;
        // resets comboscore
        GetComponent<DotManager>().ComboScore = 0;

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
