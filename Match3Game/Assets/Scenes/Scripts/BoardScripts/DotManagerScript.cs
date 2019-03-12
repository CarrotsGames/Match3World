﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
public class DotManagerScript : MonoBehaviour
{

    CompanionScript Companion;
    GameObject CampanionGameObj;

    public DotScript dotScript;
    public List<GameObject> Peices;
    public List<GameObject> RedPieces;
    public List<GameObject> BluePieces;
    public List<GameObject>  GreenPieces;
    public List<GameObject> YellowPieces;
    public GameObject DotGameObj;
    public GameObject ParticleEffectPink;
    public GameObject ParticleEffectPurple;
    public GameObject ParticleEffectBlue;
    public GameObject ParticleEffectYellow;
    
    public Material Red;
    public Material Blue;
    public Material Green;
    public Material Yellow;

    public int NumberOfNeighbours = 0;
    public int RedScore;
    public int BlueScore;
    public int YellowScore;
    public int GreenScore;
    public int Multipier;
    public int LineCount;
    public int Limit;
    public int NumOfPeices;
    public int TotalScore;
    public bool CheckConnection;
    public bool ResetDotLayers;
    public bool StartHighliting;
    private int RedCount;
    private int BlueCount;
    private int YellowCount;
    private int GreenCount;
    int test;
    public Text HighScore;
    public Text MultiplierText;

    private void Awake()
    {
        TotalScore = PlayerPrefs.GetInt("SCORE");
        HighScore.text = "" + TotalScore;
    }
    private void Start()
    {
        StartHighliting = false;
        LineCount = 0;
        Multipier = 1;
        CheckConnection = false;
        ResetDotLayers = false;
        MultiplierText.text = "" + Multipier;
        HighScore.text = "" + TotalScore;
        CampanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        Companion = CampanionGameObj.GetComponent<CompanionScript>();
        TotalScore = PlayerPrefs.GetInt("SCORE");
        HighScore.text = "" + TotalScore;

        //HighlitedColour = GetComponent<Renderer>().material;
    }


    private void Update()
    {
         MultiplierText.text = "" + Multipier;
        PlayerPrefs.SetInt("SCORE", TotalScore);
        if (CheckConnection)
        {
            for (int i = 0; i < Peices.Count; i++)
            {

                if (Peices[i].tag == "Red")
                {
                    RedCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Red;
                    RedPieces.Add(Peices[i]);
                }
                else if (Peices[i].tag == "Blue")
                {
                    BlueCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Blue;

                    BluePieces.Add(Peices[i]);

                }
                else if (Peices[i].tag == "Yellow")
                {
                    YellowCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Yellow;

                    YellowPieces.Add(Peices[i]);

                }
                else if (Peices[i].tag == "Green")
                {
                    GreenCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Green;

                    GreenPieces.Add(Peices[i]);
                }


            }
            SortingColours();
            CheckConnection = false;
            Companion.EatingPeices.Clear();
        }
    }
    void SortingColours()
    {
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
                    Companion.EatingPeices.Add(RedPieces[test]);

                }
                Companion.FeedMonster();

                // RedPieces.Clear();
            }
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
                    Companion.EatingPeices.Add(BluePieces[i]);
                }
                Companion.FeedMonster();

                // BluePieces.Clear();

            }
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
                    Companion.EatingPeices.Add(YellowPieces[i]);
                }
                Companion.FeedMonster();

                //YellowPieces.Clear();
            }
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
                    Companion.EatingPeices.Add(GreenPieces[i]);

                }
                Companion.FeedMonster();
                //    GreenPieces.Clear();
            }
            if (RedCount != Peices.Count || BlueCount != Peices.Count || GreenCount != Peices.Count || YellowCount != Peices.Count)
            {

                //  Debug.Log("No connection");
                RedPieces.Clear();
                BluePieces.Clear();
                YellowPieces.Clear();
                GreenPieces.Clear();
                RedCount = 0;
                BlueCount = 0;
                YellowCount = 0;
                GreenCount = 0;
                NumberOfNeighbours = 0;
                RedScore = 0;
                BlueScore = 0;
                YellowScore = 0;
                GreenScore = 0;
            LineCount = 0;

                // ResetDotLayers = true;
            }
            Peices.Clear();
        }
  
}