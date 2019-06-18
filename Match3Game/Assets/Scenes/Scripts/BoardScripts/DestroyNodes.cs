using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyNodes : MonoBehaviour {
    // Yeild return values
    public float ComboSpeed;
    public float ComboVanishSpeed;
    public bool StartDestroy;
    private GameObject CompanionGameObj;
    private CompanionScript CompanionScriptRef;
    public GameObject ComboGameObj;
    public Text ComboText;
    public Text ComboScore;
    private bool SlowMotionOn;
    public float SlowMotionTimer;
    private float SlowMotionStorage;
    bool Vibrate;
    private GameObject HappinessGameObj;
    public HappinessManager HappinessManagerScript;
    private int Index;
    private int ComboNum;

    float Timer;
    bool StartTimer;
    bool Reset;
    // Use this for initialization
    void Start ()
    {
        Vibrate = true;
        CompanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        CompanionScriptRef = CompanionGameObj.GetComponent<CompanionScript>();
        ComboGameObj.SetActive(false);
        SlowMotionOn = false;
        SlowMotionStorage = SlowMotionTimer;
        Timer = ComboVanishSpeed;
        StartTimer = false;
         HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (StartTimer)
        {
            ComboVanishSpeed -= Time.deltaTime;
            if (ComboVanishSpeed <= 0)
            {
                StartTimer = false;
                Reset = true;
                ComboVanishSpeed = Timer;
            }
        }
     
        if(Reset)
        {
            //resets combo text 
            ComboText.text = "";
            //disables combo gameobject 
            ComboGameObj.SetActive(false);
            ComboNum = 0;
            GetComponent<DotManager>().ComboScore = 0;
            GetComponent<DotManager>().PeicesCount = 0;
            Reset = false;
        }
        // Begins the node destroy process
        if (StartDestroy)
        {

            StartCoroutine(DestoyNodes());
            ComboGameObj.SetActive(true);

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
            Vibrate = true;
        }
        // resets the combonumber 
        // resets the comboText
        ComboText.text = "" ;
        // disables the StartDestroy void
        StartDestroy = false;
        // Resest list
        if (CompanionScriptRef.EatingPeices.Count > 4)
        {
            DisplayComboScore();
        }

        CompanionScriptRef.EatingPeices.Clear();

    }

    // Displays the ComboScore Text
    void DisplayComboScore()
    {
        int Total;
        int Combo;
        int Multplier;

        GetComponent<DotManager>().PeicesCount = GetComponent<DotManager>().PeicesCount;
        Combo = GetComponent<DotManager>().ComboScore;
        Multplier = HappinessGameObj.GetComponent<HappyMultlpier>().multiplier[HappinessGameObj.GetComponent<HappyMultlpier>().MultlpierNum];
        Total = GetComponent<DotManager>().PeicesCount * Combo;
        Total *= Multplier;

        ComboText.text = "Score:" +  Total;
        StartTimer = true;

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
