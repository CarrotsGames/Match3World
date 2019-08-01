using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{


    //Speak Bubbles
    public GameObject tutorialCanvus;
    public GameObject tutPanel;
    public GameObject gobu1;
    public GameObject gobu2;

    public GameObject welcomeToMooblings;
    public GameObject gobuIntroduction;
    public GameObject letsBegin;
    public GameObject leaderboardIntro;
    public GameObject nameInputBubble;
    public GameObject storeBubble;

    public Button gobuButton;
    public Button storeButton;
    public Button leaderButton;

    //Animation Stuff
    public GameObject finger;
    public GameObject finger2;

    //Leaderboard Stuff
    public bool leaderboardNotShowing;
    public GameObject scoreboard;
    public GameObject inputField;


    public float numberOfClicks = 0f;

    public void Start()
    {
        leaderboardNotShowing = true;
        inputField.SetActive(false);
        gobuButton.interactable = false;
        storeButton.interactable = false;

    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && numberOfClicks == 0f)
        {
            welcomeToMooblings.SetActive(false);
            gobuIntroduction.SetActive(true);

            numberOfClicks++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && numberOfClicks == 1f)
        {
            gobuIntroduction.SetActive(false);
            letsBegin.SetActive(true);
            numberOfClicks++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && numberOfClicks == 2f)
        {
            letsBegin.SetActive(false);
            leaderboardIntro.SetActive(true);
            numberOfClicks++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && numberOfClicks == 3f)
        {
            finger.SetActive(true);
            gobu1.SetActive(false);
            leaderboardIntro.SetActive(false);
            tutorialCanvus.SetActive(false);
            numberOfClicks++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && numberOfClicks == 4f)
        {
            gobu1.SetActive(false);
            nameInputBubble.SetActive(false);
        }


        if (Input.GetMouseButtonDown(0) && numberOfClicks == 5f)
        {
            storeBubble.SetActive(false);
            gobu2.SetActive(false);
            tutPanel.SetActive(false);
            finger2.SetActive(true);
            storeButton.interactable = true;
        }
    }



    public void ShowLeader()
    {
        if(leaderboardNotShowing == true)
        {
            gobu1.SetActive(true);
            scoreboard.SetActive(true);
            inputField.SetActive(true);
            leaderboardNotShowing = false;
            tutorialCanvus.SetActive(true);
            nameInputBubble.SetActive(true);
            tutPanel.SetActive(false);
            finger.SetActive(false);

        } else if (leaderboardNotShowing == false)
        {
            scoreboard.SetActive(false);
            leaderboardNotShowing = true;
            nameInputBubble.SetActive(false);
            inputField.SetActive(false);
            gobu1.SetActive(false);
            gobu2.SetActive(true);
            storeBubble.SetActive(true);
            tutPanel.SetActive(true);
            leaderButton.interactable = false;
            numberOfClicks++;
        }


    }


    public void LoadTutorialStore()
    {
        SceneManager.LoadScene("StoreScene Tutorial");
    }



}
