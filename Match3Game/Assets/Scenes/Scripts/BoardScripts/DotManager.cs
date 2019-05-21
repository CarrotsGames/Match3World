using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
public class DotManager : MonoBehaviour
{

    CompanionScript Companion;
    GameObject CampanionGameObj;

    public List<GameObject> Peices;
    public List<GameObject> RedPieces;
    public List<GameObject> BluePieces;
    public List<GameObject>  GreenPieces;
    public List<GameObject> YellowPieces;
    public List<GameObject> Gold;

    public GameObject ParticleEffectPink;
    public GameObject ParticleEffectPurple;
    public GameObject ParticleEffectBlue;
    public GameObject ParticleEffectYellow;
    public GameObject ParticleEffectFireWork;

    public GameObject MouseCursorObj;

    public Material Red;
    public Material Blue;
    public Material Green;
    public Material Yellow;

    public bool CheckConnection;
    public bool ResetDotLayers;
    public bool StartHighliting;
    public bool RedSelection;
    public bool BlueSelection;
    public bool YellowSelection;
    public bool PurpleSelection;
    public bool GoldSelection;
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
    private int test;

    public float SceneScore;
    private MouseFollowScript MouseFollow;
    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
    private CreatureSelect CreatureSelectScript;
    public Text HighScore;
    public Text MultiplierText;
     private void Awake()
    {
        TotalScore = PlayerPrefs.GetInt("SCORE");
        HighScore.text = "" + TotalScore;
    }
    private void Start()
    {
        // Bools start false to be activated later
        RedSelection  = false;
        BlueSelection = false;
        YellowSelection = false;
        PurpleSelection = false;
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
            SortingColours();
 
            CheckConnection = false;
            // clears EatingPeice List
            Companion.EatingPeices.Clear();
        }

 
    }
    // Checks which colour made a match
    void SortingColours()
    {
      
        // If the times red was counted is equal to the amount of the peices list Red was connected
            if (RedCount == Peices.Count && RedCount > Limit)
            {
                RedScore += RedCount;
                RedScore *= Peices.Count;
                RedScore *= Multipier;
                TotalScore += RedScore;

                for (test = 0; test < RedCount; test++)
                {

                RedPieces[test].layer = LayerMask.GetMask("Default");
                Instantiate(ParticleEffectPink, RedPieces[test].transform.position, Quaternion.identity);

                if (  Peices.Count > 4)
                {
                    Instantiate(ParticleEffectFireWork, RedPieces[test].transform.position, Quaternion.identity);
                }
                
                Companion.EatingPeices.Add(RedPieces[test]);

                }
                Companion.FeedMonster();
                RedSelection = false;
                BlueSelection = false;
                YellowSelection = false;
                PurpleSelection = false;
            // RedPieces.Clear();
        }
        // If the times Blue was counted is equal to the amount of the peices list Blue was connected
        if (BlueCount == Peices.Count && BlueCount > Limit)
            {
                BlueScore += BlueCount;
                BlueScore *= Peices.Count;
                BlueScore *= Multipier;
                TotalScore += BlueScore;

                for (int i = 0; i < BlueCount; i++)
                {
                    BluePieces[i].layer = LayerMask.GetMask("Default");
                    Instantiate(ParticleEffectBlue, BluePieces[i].transform.position, Quaternion.identity);

                if (  Peices.Count > 4)
                {
                    Instantiate(ParticleEffectFireWork, BluePieces[i].transform.position, Quaternion.identity);
                }
              
                Companion.EatingPeices.Add(BluePieces[i]);
                }
                Companion.FeedMonster();
                RedSelection = false;
                BlueSelection = false;
                YellowSelection = false;
                PurpleSelection = false;
            // BluePieces.Clear();

        }
        // If the times Yellow was counted is equal to the amount of the peices list Yellow was connected
        if (YellowCount == Peices.Count && YellowCount > Limit)
            {
                YellowScore += YellowCount;
                YellowScore *= Peices.Count;
                YellowScore *= Multipier;
                TotalScore += YellowScore;


                for (int i = 0; i < YellowCount; i++)
                {
                    YellowPieces[i].layer = LayerMask.GetMask("Default");
                    Instantiate(ParticleEffectPurple, YellowPieces[i].transform.position, Quaternion.identity);
                if ( Peices.Count > 4)
                {
                    Instantiate(ParticleEffectFireWork, YellowPieces[i].transform.position, Quaternion.identity);
                }
                
                Companion.EatingPeices.Add(YellowPieces[i]);
                }
                Companion.FeedMonster();
                RedSelection = false;
                BlueSelection = false;
                YellowSelection = false;
                PurpleSelection = false;
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

                for (int i = 0; i < GreenCount; i++)
                {
                    GreenPieces[i].layer = LayerMask.GetMask("Default");
                    Instantiate(ParticleEffectYellow, GreenPieces[i].transform.position, Quaternion.identity);

                if ( Peices.Count > 4)
                {
                    Instantiate(ParticleEffectFireWork, GreenPieces[i].transform.position, Quaternion.identity);
                }
               
                Companion.EatingPeices.Add(GreenPieces[i]);

                }
                RedSelection = false;
                BlueSelection = false;
                YellowSelection = false;
                PurpleSelection = false;
                Companion.FeedMonster();
                //    GreenPieces.Clear();
            }
        if(GoldAmount == Peices.Count && GoldAmount > Limit)
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
             RedSelection = false;
             BlueSelection = false;
             YellowSelection = false;
             PurpleSelection = false;
             GoldSelection = false;
            // ResetDotLayers = true;
        }
            Peices.Clear();
        }
  
}
