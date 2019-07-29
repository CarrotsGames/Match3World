using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyNodes : MonoBehaviour {
    // Yeild return values
    public float ComboSpeed;
    public float ComboVanishSpeed;
    public bool StartDestroy;
    public GameObject ComboGameObj;
    public Text ComboText;
    public Text ComboScore;
    public HappinessManager HappinessManagerScript;
    public DotManager DotManagerScript;
    public List<GameObject> ComboList;
     
    private GameObject CompanionGameObj;
    private CompanionScript CompanionScriptRef;
    private GameObject HappinessGameObj;
    private int Index;
    private GameObject DotManagerObj;
    private float Timer;
    private int Combo;
    private float ComboTime;
    private int Test;
    private bool Reset;
    private bool ComboPause;
    private GameObject PowerUpGameObj;

    // These are used in the Idasauros Script to know when the animation should play
    [HideInInspector]
    public bool NormalCombo;
    [HideInInspector]
    public bool BigCombo;

    // Use this for initialization
    void Start ()
    {
        PowerUpGameObj = GameObject.Find("PowerUps");

        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
         // Referneces DotManagerScript
        ComboTime = ComboVanishSpeed ;
        CompanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        CompanionScriptRef = CompanionGameObj.GetComponent<CompanionScript>();
        ComboGameObj.SetActive(false);
       
        Timer = 0;
         HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(ComboList.Count < 1 && GetComponent<DestroyGold>().GoldList.Count < 1)
        {

            DotManagerScript.CanPlay = true;
            Index = 0;
        }
        // pauses the combo display 
        if(ComboPause)
        {
            ComboTime -= Time.deltaTime;
            if(ComboTime < 0)
            {
                ComboPause = false;
                Reset = true;
                ComboTime = ComboVanishSpeed ;
            }
        }
        // when the combo is over it resets all values
        if(Reset)
        {
            PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonEnable();

            DotManagerScript.CanPlay = true;
             //resets combo text 
            ComboText.text = "";
            //disables combo gameobject 
            ComboGameObj.SetActive(false);
            Combo = 0;
            GetComponent<DotManager>().ComboScore = 0;
            GetComponent<DotManager>().PeicesCount = 0;
            Reset = false;
            BigCombo = false;
            NormalCombo = false;
        }
        // begins coutning the combo and addind particles
        if (StartDestroy)
        {
            PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonDisable();
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
            NormalCombo = true;
            ComboText.text = "COMBO : " + Combo;
        }
        else
        {
            BigCombo = true;
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
