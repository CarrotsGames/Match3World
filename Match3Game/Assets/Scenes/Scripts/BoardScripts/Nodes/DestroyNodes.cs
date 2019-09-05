using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyNodes : MonoBehaviour {
    // Yeild return values
    [SerializeField]
    private GameObject ComboBomb;
    [SerializeField]
    private GameObject SCR;
    [HideInInspector]
    public Vector3 LastKnownPosition;

    public float ComboSpeed;
    public float ComboVanishSpeed;
    public bool StartDestroy;
    public GameObject ComboGameObj;
    public Text ComboText;
    public Text ComboScore;
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
   // private bool Reset;
    private bool ComboPause;
    private GameObject Board;
    private GameObject PowerUpGameObj;
    // Checks how many combos have been done all time
    private int ComboNum;
    // Checks how many Big Combos have been done all time
    private int BigComboNum;
    // These are used in the Idasauros Script to know when the animation should play
    [HideInInspector]
    public bool NormalCombo;
    [HideInInspector]
    public bool BigCombo;
    private GameObject Analytics;
    string SceneName;
    // Use this for initialization
    void Start ()
    {

        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneName = CurrentScene.name;
        PowerUpGameObj = GameObject.Find("PowerUps");
        Analytics = GameObject.FindGameObjectWithTag("PlayFab");
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
         // Referneces DotManagerScript
        ComboTime = ComboVanishSpeed ;
        CompanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        CompanionScriptRef = CompanionGameObj.GetComponent<CompanionScript>();
        ComboGameObj.SetActive(false);    
        Timer = 0;
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        Board = GameObject.FindGameObjectWithTag("BoardSpawn");
     }

    // Update is called once per frame
    private void Update()
    {       
        // pauses the combo display 
        if (ComboPause)
        {
            ComboTime -= Time.deltaTime;
            if(ComboTime < 0)
            {
                ComboPause = false;
                ResetNodes();
                ComboTime = ComboVanishSpeed ;
            }
        }
      
        // begins coutning the combo and addind particles
        if (StartDestroy)
        {
            DotManagerScript.CanPlay = false;

            PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonDisable();
            StartNodeDestroy();
            ComboGameObj.SetActive(true);
        }
    }
 
    void ResetNodes()
    {
        CompanionScriptRef.ScoreMultiplier();

        Index = 0;
        if (NormalCombo)
        {
            ComboNum = PlayerPrefs.GetInt(Analytics.GetComponent<PlayFabAnalytics>().SaveScoreName + "COMBONUM");
            ComboNum++;
            PlayerPrefs.SetInt(Analytics.GetComponent<PlayFabAnalytics>().SaveScoreName + "COMBONUM", ComboNum);
        }
        else if (BigCombo)
        {
            BigComboNum = PlayerPrefs.GetInt(Analytics.GetComponent<PlayFabAnalytics>().SaveScoreName + "BIGCOMBONUM");
            BigComboNum++;
            PlayerPrefs.SetInt(Analytics.GetComponent<PlayFabAnalytics>().SaveScoreName + "BIGCOMBONUM", BigComboNum);
        }
        PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonEnable();
        DotManagerScript.CanPlay = true;
        //resets combo text 
        ComboText.text = "";
        //disables combo gameobject 
        ComboGameObj.SetActive(false);
        Combo = 0;
        GetComponent<DotManager>().ComboScore = 0;
        GetComponent<DotManager>().PeicesCount = 0;
        BigCombo = false;
        NormalCombo = false;
       
    }
 
    // Destorys nodes in the eatingPeices list
    void StartNodeDestroy()
    {
       //// Set time for delay
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
            LastKnownPosition = ComboList[Index].transform.position;
            // Moves node at index out of sight
            ComboList[Index].transform.position += new Vector3(100, 0, 0);
            // Removes node from parent to insta spawn nodes
            ComboList[Index].transform.parent = null;
            // sets the node to destroy itself        
            ComboList[Index].GetComponent<DotScript>().SelfDestruct = true;
            SCR.GetComponent<ColourRemover>().Colour = ComboList[Index].transform.gameObject.tag;
            // if the combo is greater than 4 start the ui counting

            if (ComboList.Count > 4)
            {
                Index++;
                SpawnPowerUp();
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
                ResetNodes();
            }
            // clear combo list
            ComboList.Clear();
            StartDestroy = false;
        }


    }

    void SpawnPowerUp()
    {
        // the current index is equal to the combo
        Combo = Index;
        CountCombo();
        // if the combo is half the board destory rest of board
        if (Index == ComboList.Count && Index >= Board.transform.childCount / 2)
        {
            Debug.Log("BOMBSPAWN");
            // Activates colour remover for all colours 
            // RED
            SCR.GetComponent<ColourRemover>().Colour = "Red";
            SCR.GetComponent<ColourRemover>().Red = true;
            SCR.GetComponent<ColourRemover>().RemoveColour();
            // BLUE
            SCR.GetComponent<ColourRemover>().Colour = "Blue";
            SCR.GetComponent<ColourRemover>().Red = true;
            SCR.GetComponent<ColourRemover>().RemoveColour();
            // GREEN
            SCR.GetComponent<ColourRemover>().Colour = "Green";
            SCR.GetComponent<ColourRemover>().Red = true;
            SCR.GetComponent<ColourRemover>().RemoveColour();
            // YELLOW (NOTE YELLOW IS NOW PINK)
            SCR.GetComponent<ColourRemover>().Colour = "Yellow";
            SCR.GetComponent<ColourRemover>().Red = true;
            SCR.GetComponent<ColourRemover>().RemoveColour();
            ComboTime += 0.50f;
        }
        // if combo is more than 11 activate scr and bomb
        else if (Index == ComboList.Count && Index > 11)
        {
            Debug.Log("SuperCombo");
            SCR.GetComponent<ColourRemover>().Red = true;
            SCR.GetComponent<ColourRemover>().RemoveColour();
            Instantiate(ComboBomb, LastKnownPosition, Quaternion.identity);
            ComboTime += 0.50f;
        }
        // if more than 8 activate scr
        else if (Index == ComboList.Count && Index > 7)
        {
            SCR.GetComponent<ColourRemover>().Red = true;

            SCR.GetComponent<ColourRemover>().RemoveColour();
          //  Debug.Log("SCRSPAWN");
            ComboTime += 0.50f;
        }
        // if more than 5 activate bomb
        else if (Index == ComboList.Count && Index > 4)
        {
            //Debug.Log("BOMBSPAWN");
            Instantiate(ComboBomb, LastKnownPosition, Quaternion.identity);
            ComboTime += 0.50f;


        }

    }

    void CountCombo()
    {
        if (ComboList.Count > 8)
        {
            BigCombo = true;

            ComboText.text = "BIG \n COMBO : : " + Combo;
        }
        else if (ComboList.Count > 4)
        {
            NormalCombo = true;

            ComboText.text = "COMBO : " + Combo;
        }
    }

    // Displays the ComboScore Text
    void DisplayComboScore()
    {
        int Total;
        int Combo;
        int Multplier;

       
        Combo = GetComponent<DotManager>().ComboScore;
        // Score multiplier is total amount * level
        Multplier = HappinessGameObj.GetComponent<HappinessManager>().Level;
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
