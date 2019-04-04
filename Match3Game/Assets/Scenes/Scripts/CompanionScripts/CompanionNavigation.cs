using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompanionNavigation : MonoBehaviour
{
    private RealTimeCounter RealTimeScript;
    private GameObject RealTimerGameObj;
    private string CompanionName;
    public int CompanionNumber;
    public List<GameObject> Companions;
    private GameObject CompanionStorage;
    private UnlockableCreatures Unlocklables;
     public int Navigate;
    float Happiness;
    float Happiness1;
    float Happiness2;
    public Slider HappySlider;
     // Use this for initialization
    void Start()
    {
 
      //  HappySlider.value = 0;

        RealTimerGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = RealTimerGameObj.GetComponent<RealTimeCounter>();
        CompanionStorage = GameObject.FindGameObjectWithTag("Creatures");
        for (int i = 0; i < CompanionStorage.transform.childCount; i++)
        {
            Companions.Add(CompanionStorage.transform.GetChild(i).gameObject);
        }
        Companions[0].SetActive(true);

    }

    public void PlayLevel(int Level)
    {
        switch (Level)
        {
            case 1:
                SceneManager.LoadScene("Gobu Level");


                break;
            case 2:
                SceneManager.LoadScene("Circle Scene");


                break;
            case 3:
                SceneManager.LoadScene("Triangle Scene");


                break;
            case 4:
                  SceneManager.LoadScene("Royal Gobu Level 1");
                break;
        }

    }
   public void NavigationControls(int Arrows)
    {
        switch (Arrows)
        {
            case 0:
                if (Navigate == 0)
                {

                    Companions[Navigate].SetActive(false);
                    Navigate = Companions.Count - 1;
                    //   Companions[Navigate].SetActive(true);
                    Navigation();

                }
                else
                {
                    Companions[Navigate].SetActive(false);

                    Navigate -= 1;
                    //   Companions[Navigate].SetActive(true);
                    Navigation();

                }
                break;

            case 1:
                Companions[Navigate].SetActive(false);
                if (Navigate == Companions.Count - 1)
                {
                    Navigate = 0;
                    Navigation();
                    //  Companions[CompanionNumber].SetActive(true);
                }
                else
                {
                    Navigate += 1;
                    Navigation();
                }
                break;
        }

    }
    void Navigation()
    {
        switch (Navigate)
        {
            case 0:
                Companions[Navigate].SetActive(true);
                CompanionName = Companions[Navigate].name;
                 break;

            case 1:
                Companions[Navigate].SetActive(true);
                CompanionName = Companions[Navigate].name;
                 break;
            case 2:
                Companions[Navigate].SetActive(true);
                CompanionName = Companions[Navigate].name;
                 break;
            case 3:
                Companions[Navigate].SetActive(true);
                CompanionName = Companions[Navigate].name;
                 break;
            case 4:
                Companions[Navigate].SetActive(true);
                CompanionName = Companions[Navigate].name;
                 break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (CompanionName)
        {
            case "Gobu":
                Happiness = PlayerPrefs.GetFloat("GobuHappiness");
                RealTimeScript.TimerCountDown = Happiness;
                HappySlider.value = RealTimeScript.TimerCountDown;

                break;
            case "Binky":
                Happiness1 = PlayerPrefs.GetFloat("BinkyHappiness");
                RealTimeScript.TimerCountDown1 = Happiness1;
                HappySlider.value = RealTimeScript.TimerCountDown1;

                break;
            case "Koko":
                Happiness2 = PlayerPrefs.GetFloat("KokoHappiness");
                //HappinessManagerScript.Happiness = RealTimeScript.TimerCountDown2;
                RealTimeScript.TimerCountDown2 = Happiness2;
                HappySlider.value = RealTimeScript.TimerCountDown2;

                break;
            case "NEWGOBU(Clone)":
                Happiness = PlayerPrefs.GetFloat("GobuHappiness");
                RealTimeScript.TimerCountDown = Happiness;
                HappySlider.value = RealTimeScript.TimerCountDown;

                break;
        }
   

    }
}