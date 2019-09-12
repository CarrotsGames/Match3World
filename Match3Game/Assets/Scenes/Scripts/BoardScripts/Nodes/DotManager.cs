using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
public class DotManager : MonoBehaviour
{
     public CompanionScript Companion;
    [HideInInspector]
    public GameObject CampanionGameObj;
    // GamePiece lists
    public List<GameObject> Peices;
    public List<GameObject> PeicesList;
    public List<GameObject> Gold;
    //Particle effects 
    public GameObject ParticleEffectPink;
    public GameObject ParticleEffectPurple;
    public GameObject ParticleEffectBlue;
    public GameObject ParticleEffectYellow;
    public GameObject ParticleEffectGold;

    public GameObject PartySpawner;
    // Will contain light[0] and Heavy[1] particle 
    public GameObject[] PartyEffect;
    //Will play the Gold particle effect 
    public GameObject GoldEffect;
    public GameObject MouseCursorObj;
    // Reset material colours (Green = Purple)
    public Material Red;
    public Material Blue;
    public Material Green;
    public Material Yellow;
    // checks for node connection
    public bool CheckConnection;
    public bool ResetDotLayers;
    public bool StartHighliting;
    // Checks if speicifc colour is being highlited in dotscript 
    public bool NodeSelection;
    //Used in tutorial
    [HideInInspector]
    public bool ConnectionMade;
    public bool GoldSelection;
    // Resets node properties
    public bool ResetLayer;
    public bool ResetMaterial;
    public bool CanPlay;
    public int RedScore;
    public int GoldAmount;
    public int Multipier;
    public int Limit;
    public int TotalScore;

    [HideInInspector]
    public int ComboScore;   
    // public int Currency;
    public int PeicesCountCombo;

    public int PeicesCount;
 
    private int Num;

    public float SceneScore;
    // Getting gold score here to write to analytics
    public int GoldScore;
    public Text HighScore;
    //public Text MultiplierText;
    private MouseFollowScript MouseFollow;
    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
    private CreatureSelect CreatureSelectScript;
    private string Colour;
     private void Awake()
     {
         TotalScore = PlayerPrefs.GetInt("SCORE");
         HighScore.text = "" + TotalScore;
     }
    private void Start()
    {
        // Bools start false to be activated later
        NodeSelection = false;
        StartHighliting = false;
        ResetMaterial = false;
        ResetLayer = false;
        CheckConnection = false;
        ResetDotLayers = false;
        CanPlay = true;
        // UI
        Multipier = 1;
       // MultiplierText.text = "" + Multipier;
        HighScore.text = "" + TotalScore;
 
        // Gameobject/script refrences
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        CampanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        Companion = CampanionGameObj.GetComponent<CompanionScript>();
        TotalScore = PlayerPrefs.GetInt("SCORE");
        MouseCursorObj = GameObject.FindGameObjectWithTag("Mouse");
        MouseFollow = MouseCursorObj.GetComponent<MouseFollowScript>();
        CreatureSelectScript = GetComponent<CreatureSelect>();
        if (CreatureSelectScript == null)
        {
            MouseCursorObj.SetActive(false);
        }
        else
        {
            MouseCursorObj.SetActive(false);
        }

    }


    public void CheckPieces()
    {
        // MultiplierText.text = "" + Multipier;

        // Checkas if colours are connecting
        if (CheckConnection)
        {
            PeicesCount = 0;
            NodeSelection = false;

            StartHighliting = false;
            // sorts each colour found in the peices list 
            for (int i = 0; i < Peices.Count; i++)
            {

                if (Peices[i].tag == "Red")
                {
                    PeicesCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Red;
                    Peices[i].gameObject.layer = 0;
                    PeicesList.Add(Peices[i]);
                }
                else if (Peices[i].tag == "Blue")
                {
                    PeicesCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Blue;
                    Peices[i].gameObject.layer = 0;

                    PeicesList.Add(Peices[i]);

                }
                else if (Peices[i].tag == "Yellow")
                {
                    PeicesCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Yellow;
                    Peices[i].gameObject.layer = 0;

                    PeicesList.Add(Peices[i]);

                }
                else if (Peices[i].tag == "Green")
                {
                    PeicesCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Green;
                    Peices[i].gameObject.layer = 0;

                    PeicesList.Add(Peices[i]);
                }
                else if (Peices[i].tag == "Gold")
                {
                    Debug.Log("GOLDCONNECTION");
                    GoldAmount += 1;
                    Peices[i].GetComponent<Renderer>().material = Green;
                    Peices[i].gameObject.layer = 0;

                    Gold.Add(Peices[i]);
                }
            }
            if (Limit < Gold.Count)
            {
                // Adds to goldscore analytic
                GoldScore += Gold.Count;
                // Adds specific color node to score(Now just adds nodes to score)
                AddColourToScore();
                // clears list to avoid null refs
                Peices.Clear();
                // adds the board particles
               // AddBoardParticles();
            }
            else
            {
                Gold.Clear();
            }
            // Checks which colour made a match  
            if (Limit < Peices.Count)
            {

                AddColourToScore();
                Peices.Clear();
                PeicesList.Clear();
            }
            else
            {
                GoldAmount = 0;
                GetComponent<DestroyNodes>().ComboList.Clear();
                Peices.Clear();
                PeicesList.Clear();
                ResetLayer = true;

            }
          
            PeicesCountCombo = PeicesCount;
            CheckConnection = false;
            // clears EatingPeice List
         
        }


    }
 
    //// Checks which colour made a match
    void AddColourToScore()
    {

        // If the times red was counted is equal to the amount of the peices list Red was connected
        if (PeicesCount == Peices.Count && PeicesCount > Limit)
        {
            ConnectionMade = true;
            RedScore += PeicesCount;
            RedScore *= Peices.Count;
            RedScore *= Multipier;

            for (Num = 0; Num < PeicesCount; Num++)
            {
                PeicesList[Num].layer = LayerMask.GetMask("Default");
                // adds to the list to be destroyed
                GetComponent<DestroyNodes>().ComboList.Add(PeicesList[Num]);
                
            }
            // gets how many nodes are in connection
            Companion.TotalConnection = PeicesList.Count;
            PeicesList.Clear();
            PeicesCount = 0;

        }

        if (GoldAmount == Peices.Count && GoldAmount > Limit)
        {
            PowerUpManagerScript.Currency += GoldAmount;       
            GetComponent<DestroyGold>().StartGoldDestroy();
             
        }
        // if the colour wasnt matched reset lists, scores, counts and selections
        // Counts the current combo going on 
            ComboScore = RedScore; 
        // Counts the total score within scene
            SceneScore += RedScore;
        
            GoldAmount = 0;
            RedScore = 0;            
            NodeSelection = false;
 
            GoldSelection = false;
           GetComponent<DestroyNodes>().StartDestroy = true;
          //GetComponent<DestroyNodes>().CreateComboList();
          //  AddBoardParticles();
          // ResetDotLayers = true;
          // Adds board particles


    }
 
}
