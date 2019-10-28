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
  
    // Reset material colours (Green = Purple)
    public Material DefaultMaterial;
 
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
    public int NodeScore;
    public int GoldAmount;
    public int Limit;
    public static int TotalScore;

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
        TotalScore = PlayerPrefs.GetInt("SCORE");
        HighScore.text = "" + TotalScore;

        // Bools start false to be activated later
        NodeSelection = false;
        StartHighliting = false;
        ResetMaterial = false;
        ResetLayer = false;
        CheckConnection = false;
        ResetDotLayers = false;
        CanPlay = true;
        // UI
        
        // MultiplierText.text = "" + Multipier;
        HighScore.text = "" + TotalScore;

        // Gameobject/script refrences
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        CampanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        Companion = CampanionGameObj.GetComponent<CompanionScript>();
        
        CreatureSelectScript = GetComponent<CreatureSelect>();
 
    }

    // checks for connection
    public void CheckPieces()
    {
        // MultiplierText.text = "" + Multipier;
        if (Peices.Count <= 2)
        {
            for (int i = 0; i < Peices.Count; i++)
            {
                Peices[i].GetComponent<Renderer>().material = DefaultMaterial;
            }                  
        }
        // Checkas if colours are connecting
        if (CheckConnection)
        {
            PeicesCount = 0;
            NodeSelection = false;

            StartHighliting = false;
            // Sets node outline to default 
            for (int i = 0; i < Peices.Count; i++)
            {

                //if (Peices[i].tag == "Red")
                //{
                PeicesCount += 1;
                Peices[i].GetComponent<Renderer>().material = DefaultMaterial;
                Peices[i].gameObject.layer = 0;
                PeicesList.Add(Peices[i]);

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



 
    //// Checks which colour made a match
    void AddColourToScore()
    {

        // If the times red was counted is equal to the amount of the peices list was connected
        if (PeicesCount == Peices.Count && PeicesCount > Limit)
        {
            ConnectionMade = true;
            NodeScore += PeicesCount;
            NodeScore *= Peices.Count;
 

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
        ComboScore = NodeScore;
        // Counts the total score within scene
        SceneScore += NodeScore;
        GoldAmount = 0;
        NodeScore = 0;
        // Disables checking for node colour
        NodeSelection = false;
        GoldSelection = false;
        // begins the destroy node process
        GetComponent<DestroyNodes>().StartDestroy = true;
 


    }
 
}
