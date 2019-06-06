using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
public class DotManager : MonoBehaviour
{

    CompanionScript Companion;
    GameObject CampanionGameObj;
    // GamePiece lists
    public List<GameObject> Peices;
    public List<GameObject> RedPieces;
    public List<GameObject> BluePieces;
    public List<GameObject> GreenPieces;
    public List<GameObject> YellowPieces;
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
    public bool StopInteracting;
    public bool ChangeMaterial;

    public int NumberOfNeighbours = 0;
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
    // public int Currency;

    private int RedCount;
    private int BlueCount;
    private int YellowCount;
    private int GreenCount;
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
        StopInteracting = false;
        ChangeMaterial = false;

        // UI
        LineCount = 0;
        Multipier = 1;
        MultiplierText.text = "" + Multipier;
        HighScore.text = "" + TotalScore;
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
            ResetLayer = true;
            StartHighliting = false;
            // sorts each colour found in the peices list 
            for (int i = 0; i < Peices.Count; i++)
            {

                if (Peices[i].tag == "Red")
                {
                    RedCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Red;
                    Peices[i].gameObject.layer = 0;
                    RedPieces.Add(Peices[i]);
                }
                else if (Peices[i].tag == "Blue")
                {
                    BlueCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Blue;
                    Peices[i].gameObject.layer = 0;

                    BluePieces.Add(Peices[i]);

                }
                else if (Peices[i].tag == "Yellow")
                {
                    YellowCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Yellow;
                    Peices[i].gameObject.layer = 0;

                    YellowPieces.Add(Peices[i]);

                }
                else if (Peices[i].tag == "Green")
                {
                    GreenCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Green;
                    Peices[i].gameObject.layer = 0;

                    GreenPieces.Add(Peices[i]);
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
            AddColourToScore();

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
        if (RedCount == Peices.Count && RedCount > Limit)
        {
            RedScore += RedCount;
            RedScore *= Peices.Count;
            RedScore *= Multipier;
            TotalScore += RedScore;

            for (Num = 0; Num < RedCount; Num++)
            {
                RedPieces[Num].layer = LayerMask.GetMask("Default");
                Companion.EatingPeices.Add(RedPieces[Num]);
                if (Peices.Count >= 8)
                {
                  //  Instantiate(ParticleEffectFireWork, RedPieces[Num].transform.position, Quaternion.identity);

                }
            }
             Companion.FeedMonster();
 
        }
        // If the times Blue was counted is equal to the amount of the peices list Blue was connected
        if (BlueCount == Peices.Count && BlueCount > Limit)
        {
            BlueScore += BlueCount;
            BlueScore *= Peices.Count;
            BlueScore *= Multipier;
            TotalScore += BlueScore;

            for (Num = 0; Num < BlueCount; Num++)
            {
                BluePieces[Num].layer = LayerMask.GetMask("Default");
                Companion.EatingPeices.Add(BluePieces[Num]);
                if(Peices.Count >= 8)
                {
                  //  Instantiate(ParticleEffectFireWork, BluePieces[Num].transform.position, Quaternion.identity);
                }
            }

            Companion.FeedMonster();
 

        }

        // If the times Yellow was counted is equal to the amount of the peices list Yellow was connected
        if (YellowCount == Peices.Count && YellowCount > Limit)
        {
            YellowScore += YellowCount;
            YellowScore *= Peices.Count;
            YellowScore *= Multipier;
            TotalScore += YellowScore;

            for (Num = 0; Num < YellowCount; Num++)
            {

                YellowPieces[Num].layer = LayerMask.GetMask("Default");
                Companion.EatingPeices.Add(YellowPieces[Num]);
                if (Peices.Count >= 8)
                {
                  //  Instantiate(ParticleEffectFireWork, YellowPieces[Num].transform.position, Quaternion.identity);
                }
            }

            Companion.FeedMonster();
 
            //YellowPieces.Clear();
        }
        // TODO CHANGE GREEN TO PURPLE
        // If the times Green(Purple) was counted is equal to the amount of the peices list Green was connected

        if (GreenCount == Peices.Count && GreenCount > Limit)
        {
            GreenScore += GreenCount;
            GreenScore *= Peices.Count;
            GreenScore *= Multipier;
            TotalScore += GreenScore;

            for (Num = 0; Num < GreenCount; Num++)
            {

                GreenPieces[Num].layer = LayerMask.GetMask("Default");
                Companion.EatingPeices.Add(GreenPieces[Num]);
                if (Peices.Count >= 8)
                {
                  //  Instantiate(ParticleEffectFireWork, GreenPieces[Num].transform.position, Quaternion.identity);
                }
            }
       
            Companion.FeedMonster();
            //    GreenPieces.Clear();
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
        if (RedCount != Peices.Count || BlueCount != Peices.Count || GreenCount != Peices.Count || YellowCount != Peices.Count)
        {
      
            SceneScore += RedScore + BlueScore + GreenScore + YellowScore;
            //  Debug.Log("No connection");
            RedPieces.Clear();
            BluePieces.Clear();
            YellowPieces.Clear();
            GreenPieces.Clear();
            Gold.Clear();
            RedCount = 0;
            BlueCount = 0;
            YellowCount = 0;
            GreenCount = 0;
            GoldAmount = 0;
            NumberOfNeighbours = 0;
            RedScore = 0;
            BlueScore = 0;
            YellowScore = 0;
            GreenScore = 0;
            LineCount = 0;
            NodeSelection = false;
 
            GoldSelection = false;
            AddBoardParticles();
            // ResetDotLayers = true;
            // Adds board particles
         }
        Peices.Clear();
    }

}
