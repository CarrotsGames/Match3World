using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
public class DotManager : MonoBehaviour
{
    [HideInInspector]
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
   // public GameObject ParticleEffectFireWork;

    public GameObject PartySpawner;
    // Will contain light[0] and Heavy[1] particle 
    public GameObject[] PartyEffect;
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
 
    public bool GoldSelection;
    // Resets node properties
    public bool ResetLayer;
    public bool ResetMaterial;
    public bool ChangeMaterial;
    public bool CanPlay;
    public int RedScore;
    public int BlueScore;
    public int YellowScore;
    public int GreenScore;
    public int GoldAmount;
    public int Multipier;
    public int LineCount;
    public int Limit;
    public int NumOfPeices;
    public int TotalScore;
    [HideInInspector]
    public int ComboScore;
     
    // public int Currency;
    public int PeicesCountCombo;

    public int PeicesCount;
 
    private int Num;

    public float SceneScore;
    public Text HighScore;
    public Text MultiplierText;
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
        ChangeMaterial = false;
        CanPlay = true;
        // UI
        LineCount = 0;
        Multipier = 1;
        MultiplierText.text = "" + Multipier;
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


    private void Update()
    {

        MultiplierText.text = "x" + Multipier;

        PlayerPrefs.SetInt("SCORE", TotalScore);
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
                Gold.Clear();
                Companion.EatingPeices.Clear();
                Peices.Clear();
                PeicesList.Clear();
                ResetLayer = true;

            }
            PeicesCountCombo = PeicesCount;
            CheckConnection = false;
            // clears EatingPeice List
         
        }


    }
    // adds particle effect to the map
    void AddBoardParticles()
    {
        if (Peices.Count >= 7)
        {
            Instantiate(PartyEffect[0], PartySpawner.transform.position, Quaternion.identity);
            Instantiate(PartyEffect[1], PartySpawner.transform.position, Quaternion.identity); 

        }
        else if (Peices.Count >= 5)
        {
            Instantiate(PartyEffect[0], PartySpawner.transform.position, Quaternion.identity);
        }

    }


    // Checks which colour made a match
    void AddColourToScore()
    {

        // If the times red was counted is equal to the amount of the peices list Red was connected
        if (PeicesCount == Peices.Count && PeicesCount > Limit)
        { 
            RedScore += PeicesCount;
            RedScore *= Peices.Count;
            RedScore *= Multipier;

            for (Num = 0; Num < PeicesCount; Num++)
            {
                PeicesList[Num].layer = LayerMask.GetMask("Default");
                Companion.EatingPeices.Add(PeicesList[Num]);
                

            }
            PeicesList.Clear();
            PeicesCount = 0;

        }

        if (GoldAmount == Peices.Count && GoldAmount > Limit)
        {
            PowerUpManagerScript.Currency += GoldAmount;
            for (int i = 0; i < GoldAmount; i++)
            {
                Destroy(Gold[i].gameObject);

            }
        }
        // if the colour wasnt matched reset lists, scores, counts and selections
        // Counts the current combo going on 
            ComboScore = RedScore + BlueScore + GreenScore + YellowScore; 
        // Counts the total score within scene
            SceneScore += RedScore + BlueScore + GreenScore + YellowScore;

        //  Debug.Log("No connection");
 
            Gold.Clear();
             
            GoldAmount = 0;
             RedScore = 0;
            BlueScore = 0;
            YellowScore = 0;
            GreenScore = 0;
            LineCount = 0;
            NodeSelection = false;
 
            GoldSelection = false;
            Companion.FeedMonster();
            AddBoardParticles();
            // ResetDotLayers = true;
            // Adds board particles
          
 
    }
    // This exists only to play particle on gold which works differently than normal nodes 
    // (doesent give score, happiness or combo)
    // and at the time seemed like the cleanest way of spawning a particle on the gold
    void PlayGoldPartice()
    {

    }
}
