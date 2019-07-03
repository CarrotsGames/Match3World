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
    public DotManager DotManagerScript;
    private GameObject DotManagerObj;
    public List<GameObject> ComboList;
    float Timer;
    bool StartTimer;
    bool Reset;
    bool ComboPause;
    int Combo;
    float ComboTime;
    int Test;
    // Use this for initialization
    void Start ()
    {
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
         // Referneces DotManagerScript
        ComboTime = ComboVanishSpeed ;
        Vibrate = true;
        CompanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        CompanionScriptRef = CompanionGameObj.GetComponent<CompanionScript>();
        ComboGameObj.SetActive(false);
        SlowMotionOn = false;
        SlowMotionStorage = SlowMotionTimer;
        Timer = 0;
        StartTimer = false;
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(ComboList.Count < 1)
        {
            DotManagerScript.CanPlay = true;
            Index = 0;
        }
   
         
        if(ComboPause)
        {
            //StartTimer = false;
            ComboTime -= Time.deltaTime;
            if(ComboTime < 0)
            {
                ComboPause = false;
                Reset = true;
                ComboTime = ComboVanishSpeed ;
            }
        }
        if(Reset)
        {
            DotManagerScript.CanPlay = true;

            StartTimer = false;
            //resets combo text 
            ComboText.text = "";
            //disables combo gameobject 
            ComboGameObj.SetActive(false);
            ComboNum = 0;
            Combo = 0;
            GetComponent<DotManager>().ComboScore = 0;
            GetComponent<DotManager>().PeicesCount = 0;
            Reset = false;
        }
        if (StartDestroy)
        {

            StartNodeDestroy();
            ComboGameObj.SetActive(true);

        }
 

    }
 
    public void CreateComboList()
    {
        ComboList.Clear();
        Test = CompanionScriptRef.EatingPeices.Count;
        DotManagerScript.CanPlay = false;
        for (int i = 0; i < CompanionScriptRef.EatingPeices.Count; i++)
        {
            if(!ComboList.Contains(CompanionScriptRef.EatingPeices[i]))
            {
                ComboList.Add(CompanionScriptRef.EatingPeices[i]);
                ComboList[i].gameObject.layer = 2;
            }
            else
            {
                Debug.Log("Duplicate");
            }
        }
        CompanionScriptRef.EatingPeices.Clear();
        StartDestroy = true;
    }
    // Destorys nodes in the eatingPeices list
    void StartNodeDestroy()
    {
       //// Set time for delay
       //WaitForSeconds wait = new WaitForSeconds(ComboSpeed);
       //WaitForSeconds SlowMotion = new WaitForSeconds(0.5f);
       Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            DestoryNodes();
            Timer = ComboSpeed;
        }


    }
    void DestoryNodes()
    {

        if (Index < ComboList.Count)
        {  // plays particle at index
            PlayParticle();
            // Moves node at index out of sight
            ComboList[Index].transform.position += new Vector3(100, 0, 0);
            // sets the node to destroy itself
            ComboList[Index].GetComponent<DotScript>().SelfDestruct = true;
           
            // if the combo is greater than 4 start the ui counting
            if (ComboList.Count > 4)
            {
                // the current index is equal to the combo
                Index++;
                Combo = Index;
                CountCombo();
              //  Handheld.Vibrate();
            }
            // if not than add anyway to avoid to play particles
            else
            {
                Index++;
            }
          
         }
        else
        {
            // if the combo is higher than 4 pause the combo 
            if (Index > 4)
            {
                ComboPause = true;
            }
            // if there was no combo reset all properties
            else
            {
                Reset = true;
            }
            // clear combo list
            ComboList.Clear();
            StartDestroy = false;
        }


    }
    void CountCombo()
    {
        if (ComboList.Count < 6)
        {
            ComboText.text = "COMBO : " + Combo;
        }
        else
        {
            ComboText.text = "BIG \n COMBO : " + Combo;

        }
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
        if(ComboList[Index].tag == "Red")
        {
            Instantiate(GetComponent<DotManager>().ParticleEffectPink, ComboList[Index].transform.position, Quaternion.identity);

        }
        else if (ComboList[Index].tag == "Blue")
        {
            Instantiate(GetComponent<DotManager>().ParticleEffectBlue, ComboList[Index].transform.position, Quaternion.identity);

        }
        else if (ComboList[Index].tag == "Yellow")
        {
            Instantiate(GetComponent<DotManager>().ParticleEffectPurple, ComboList[Index].transform.position, Quaternion.identity);

        }
        else if (ComboList[Index].tag == "Green")
        {
            Instantiate(GetComponent<DotManager>().ParticleEffectYellow, ComboList[Index].transform.position, Quaternion.identity);

        }


    }
     
}
