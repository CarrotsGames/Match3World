using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyNodes : MonoBehaviour {

    public float ComboSpeed;
    public float ComboVanishSpeed;
    [HideInInspector]
    public bool UsingBomb;
    [HideInInspector]
    public bool BigCombo;
    public bool StartDestroy;
    public Text ComboText;
    public Text ComboScore;
    public DotManager DotManagerScript;
    // Yeild return values
    [SerializeField]
    private GameObject ComboBomb;
    [SerializeField]
    private GameObject SCR;
    public List<GameObject> ComboList;
    [HideInInspector]
    public Vector3 LastKnownPosition;
  
    // Checks how many combos have been done all time
    private int ComboNum;
    // Checks how many Big Combos have been done all time
    private int BigComboNum;
    private int Index;
    private int Combo;
    private int Test;
    private float Timer;
    private float ComboTime;
    private bool InChallengeScene;
    private GameObject CompanionGameObj;
    private GameObject HappinessGameObj;
    private GameObject DotManagerObj;
    private GameObject Board;
    [SerializeField]
    private GameObject PowerUpGameObj;
    private GameObject PowerUpManager;
    // These are used in the Idasauros Script to know when the animation should play
    private GameObject Analytics;
    private string SceneName;
    // private bool Reset;
    private List<int> NodeScore;
    private CompanionScript CompanionScriptRef;
    // Use this for initialization
    void Start()
    {
        NodeScore = new List<int>();
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneName = CurrentScene.name;
        PowerUpGameObj = GameObject.Find("PowerUps");
        Analytics = GameObject.FindGameObjectWithTag("PlayFab");
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        // Referneces DotManagerScript
        ComboTime = ComboVanishSpeed;
        CompanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        CompanionScriptRef = CompanionGameObj.GetComponent<CompanionScript>();
        //ComboGameObj.SetActive(false);    
        Timer = 0;
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        Board = GameObject.FindGameObjectWithTag("BoardSpawn");
        PowerUpManager = GameObject.FindGameObjectWithTag("PUM");
        UsingBomb = false;
        InChallengeScene = false;
        if (GameObject.Find("CHALLENGE"))
        {
            InChallengeScene = true;
        }

     }

    // Update is called once per frame
    private void Update()
    {       
 
        // begins coutning the combo and addind particles
        if (StartDestroy)
        {
            DotManagerScript.CanPlay = false;
            PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonDisable();
            StartNodeDestroy();
         }
    }
    // calculates total score to show on each node
    void CalculateScore()
    {
        int Total = ComboList.Count;
        int LevelMultiplier = HappinessGameObj.GetComponent<HappinessManager>().Level;
        if (SuperMultiplierScript.CanUseSuperMultiplier)
        {
            Total *= 2;
        }
    
        Total *= LevelMultiplier;
        Total *= 5;
        int NumOfNodes = ComboList.Count;
        int EXPTotal = Total + HappinessGameObj.GetComponent<HappinessManager>().Level;
        for (int i = 0; i < ComboList.Count ; i++)
        {
            int DivideNum = Total;
            int DividedScore = DivideNum /= NumOfNodes;
            NodeScore.Add(DividedScore);
            NumOfNodes--;

        }
    }
    void ResetNodes()
    {
        int Total = ComboList.Count;
        int EXPTotal = Total + HappinessGameObj.GetComponent<HappinessManager>().Level;
        CompanionScriptRef.ScoreMultiplier(EXPTotal, Total, "Normal");
        // clear combo list
        ComboList.Clear();
        NodeScore.Clear();
        Index = 0;
 
        if (!UsingBomb)
        {
            DotManagerScript.CanPlay = true;
            PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonEnable();

        }
        //resets combo text 
        ComboText.text = "";
         
        Combo = 0;
        GetComponent<DotManager>().ComboScore = 0;
        GetComponent<DotManager>().PeicesCount = 0;
        BigCombo = false;
       // NormalCombo = false;
       
    }

    // Destorys nodes in the eatingPeices list
    void StartNodeDestroy()
    {
        if (Index < 1)
        {
            if (!InChallengeScene)
            {
                // gets nodes final position to spawn bomb on 
                CalculateScore();
            }
            int LastPos = ComboList.Count - 1;
           
        }
      
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
        {
            if (!InChallengeScene)
            {
                CompanionScriptRef.TotalScoreGameObj.SetActive(true);
                LastKnownPosition = ComboList[Index].transform.position;
                CompanionScriptRef.TotalScore.text = "" + NodeScore[Index];
                CompanionScriptRef.TotalScore.transform.position = LastKnownPosition;
            }
            // plays particle at index
            PlayParticle();
           // LastKnownPosition = ComboList[Index].transform.position;
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
                ResetNodes();
            }
            // if there was no combo reset all properties
            else
            {
                ResetNodes();
            }

            StartDestroy = false;
        }


    }

    void SpawnPowerUp()
    {
        // the current index is equal to the combo
        Combo = Index;
        // if the combo is half the board destory rest of board
        if (Index == ComboList.Count && Index >= Board.transform.childCount / 2)
        {
            PowerUpManager.GetComponent<PowerUpManager>().Currency += 5;
            PowerUpManager.GetComponent<PowerUpManager>().PowerUpSaves();
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
 
            SCR.GetComponent<ColourRemover>().Red = true;
            SCR.GetComponent<ColourRemover>().RemoveColour();
            Instantiate(ComboBomb, LastKnownPosition, Quaternion.identity);
            ComboTime += 0.50f;
            UsingBomb = true;

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
            UsingBomb = true;

        }

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
