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
    public List<GameObject> ComboList;
    float Timer;
    bool StartTimer;
    bool Reset;
    // Use this for initialization
    void Start ()
    {  // Referneces DotManagerScript
   
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


     
        Debug.Log(GetComponent<DotManager>().ComboScore);
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
   
    public void CreateComboList()
    {
        for (int i = 0; i < CompanionScriptRef.EatingPeices.Count; i++)
        {
            ComboList.Add(CompanionScriptRef.EatingPeices[i]);
          
        }
        StartDestroy = true;
    }
    // Destorys nodes in the eatingPeices list
    IEnumerator DestoyNodes()
    {
        // Set time for delay
        WaitForSeconds wait = new WaitForSeconds(ComboSpeed);
        WaitForSeconds SlowMotion = new WaitForSeconds(10);

        for (int i = 0; i < ComboList.Count; i++)
        {

            Index = i;
            if (ComboList.Count > 6)
            {
                if(ComboNum < 1)
                {
                    SlowMotionOn = true;
                }
                ComboText.text = "BIG \nCOMBO:" + ComboNum;
                if (Vibrate)
                {
                    ComboNum += 1;

                    Handheld.Vibrate();
                    Vibrate = false;

                }
            }
            // Displays the combo currently happening in game
            else if (ComboList.Count > 4)
            {
                ComboText.text = "COMBO:" + ComboNum;
                 if (Vibrate)
                {
                    ComboNum += 1;
                     Handheld.Vibrate();
                    Vibrate = false;

                }
               
            }

            // destroys current peice
            // plays that peices particle depending on colour
         
             
            PlayParticle();
             
            Destroy(ComboList[i].gameObject);
             // Delays forloop So that nodes are destroyed one by one

            yield return wait;
            Vibrate = true;
        }
        // resets the combonumber 
        // resets the comboText
        ComboText.text = "" ;
        // disables the StartDestroy void
        StartDestroy = false;
        // Resest list
        if (ComboList.Count > 4)
        {
            DisplayComboScore();
        }

         ComboList.Clear();
    }

    // Displays the ComboScore Text
    void DisplayComboScore()
    {
        int Total;
        int Combo;
        int Multplier;

       
        Combo = GetComponent<DotManager>().ComboScore;
        Multplier = HappinessGameObj.GetComponent<HappyMultlpier>().multiplier[HappinessGameObj.GetComponent<HappyMultlpier>().MultlpierNum];
        Total = GetComponent<DotManager>().PeicesCount + Combo;
        Total *= Multplier;

        ComboText.text = "Score:" +  Total;
        StartTimer = true;

    }
    // plays particle effect for each node
    void PlayParticle()
    {
            // plays particle effect at list index and position of current node
        switch (ComboList[Index].tag)
        {
            case "Red":
                {
                    Instantiate(GetComponent<DotManager>().ParticleEffectPink, ComboList[Index].transform.position, Quaternion.identity);

                }
                break;
            case "Blue":
                {
                    Instantiate(GetComponent<DotManager>().ParticleEffectBlue, ComboList[Index].transform.position, Quaternion.identity);

                }
                break;
            case "Yellow":
                {
                    Instantiate(GetComponent<DotManager>().ParticleEffectPurple, ComboList[Index].transform.position, Quaternion.identity);
                }
                break;
            case "Green":
                {
                    Instantiate(GetComponent<DotManager>().ParticleEffectYellow, ComboList[Index].transform.position, Quaternion.identity);
                }
                break;
        }

    }
}
