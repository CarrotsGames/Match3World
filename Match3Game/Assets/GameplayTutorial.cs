using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayTutorial : MonoBehaviour
{
    //Unity Buttons (Powerups)
    public Button scr;
    public Button bomb;
    public Button shuffle;
    public Button multi;

    //Speak Bubbles
    private GameObject dotManagerGameObj;
    private DotManager dotManagerScript;
    public GameObject superBomb;
    public GameObject superColourRemover;
 
    public GameObject basicBubble;
    public GameObject scoreboardBubble;
    public GameObject connectionBubble;
    public GameObject connectionBubble2;
    public GameObject badNodesBubble;
    public GameObject bombBubble;
    public GameObject rainbowBubble;
    public GameObject happinessBubble;
    public GameObject happinessBubble2;
    public GameObject goldBubble;
    public GameObject golfBubble2;
    public GameObject multiBubble;
    public GameObject multtBubble2;
    public GameObject multiBubble3;
    public GameObject thatsAllBubble;

    //Misalanious Image
    public GameObject gobu;
    public Button pause;

    //Finger Animation set up to just play on awake finger1 is the swipe anim and finger2 is a scoreboard anim 
    public GameObject finger1;
    public GameObject finger2;
    public GameObject bombFinger;
    public GameObject bombFinger2;
    public GameObject scrFinger;
    public GameObject scrFinger2;
    public GameObject gearFinger;
    public GameObject exitFinger;

    private HappinessManager HappinessManagerScript;
    private GameObject HappinessGameObj;

    //the amount of times the player has clicked on the screen
    public int clickAmount;

    //node groups
    public GameObject nodeRound1;
    public GameObject nodeRound2;
    public GameObject nodeRound3;
    public GameObject nodeRoundGold;
    // Start is called before the first frame update
    void Start()
    {
        // Finds gameobject with tag in hierarchy 
        dotManagerGameObj = GameObject.FindGameObjectWithTag("DotManager");
        // Grabs dotmanager script on that gameobject to get info
        dotManagerScript = dotManagerGameObj.GetComponent<DotManager>();

        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
        pause.interactable = false;
        bomb.interactable = false;
        scr.interactable = false;
        shuffle.interactable = false;
        multi.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        //when the player clicks for the first time the first speak bubble turns of and the second one turns on finger2 anim also starts to show the player the scoreboard
        if (Input.GetMouseButtonDown(0) && clickAmount == 0f)
        {
            basicBubble.SetActive(false);
            scoreboardBubble.SetActive(true);
            finger2.SetActive(true);
            clickAmount++;
            return;
        }
        //when the player clicks again it turns the 2nd bubble and finger off turns the 3rd bubble on.
        if (Input.GetMouseButtonDown(0) && clickAmount == 1f)
        {
            finger2.SetActive(false);
            scoreboardBubble.SetActive(false);
            connectionBubble.SetActive(true);
            clickAmount++;
            return;
        }
        //turns 3rd off and turns 4 on
        if (Input.GetMouseButtonDown(0) && clickAmount == 2f)
        {
            connectionBubble.SetActive(false);
            connectionBubble2.SetActive(true);
            clickAmount++;
            return;
        }
        //turns 4 off and 5 on this is where the finger animation starts and the player will need to start to swipe
        if (Input.GetMouseButtonDown(0) && clickAmount == 3f)
        {
            finger1.SetActive(true);
            connectionBubble2.SetActive(false);
            clickAmount++;
            gobu.SetActive(false);
            return;
        }
        if (Input.GetMouseButton(0)&& clickAmount == 5f)
        {
            badNodesBubble.SetActive(false);
            bombBubble.SetActive(true);
            nodeRound1.SetActive(false);
            nodeRound2.SetActive(true);
            clickAmount++;
            return;
        }
        if (Input.GetMouseButton(0) && clickAmount == 6f)
        {
            bomb.interactable = true;
            bombBubble.SetActive(false);
            gobu.SetActive(false);
            bombFinger.SetActive(true);
            clickAmount++;
            return;
        }
        if (Input.GetMouseButton(0) && clickAmount == 8f)
        {
            rainbowBubble.SetActive(false);
            scrFinger.SetActive(true);
            scr.interactable = true;
            clickAmount++;
            return;
        }
        if(Input.GetMouseButtonDown(0) && clickAmount == 11f)
        {
            happinessBubble.SetActive(false);
            happinessBubble2.SetActive(true);
            finger2.SetActive(false);
            clickAmount++;
            return;

        }
        if (Input.GetMouseButtonDown(0) && clickAmount == 12f)
        {
            happinessBubble2.SetActive(false);
            goldBubble.SetActive(true);
            //Puts moobling to sleep
            HappinessManagerScript.HappinessSliderValue = 100;
            clickAmount++;
            return;
            //set happiness to 100 and make gobu sleep sleep
        }
        if (Input.GetMouseButtonDown(0) && clickAmount == 13f)
        {
            goldBubble.SetActive(false);
            golfBubble2.SetActive(true);
            clickAmount++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && clickAmount == 14f)
        {
            golfBubble2.SetActive(false);
            multiBubble.SetActive(true);
            clickAmount++;
            return;
        }
        if(Input.GetMouseButtonDown(0) && clickAmount == 15f)
        {
            multiBubble.SetActive(false);
            multtBubble2.SetActive(true);
            clickAmount++;
            return;
        }
        if(Input.GetMouseButtonDown(0) && clickAmount == 16f)
        {
            multtBubble2.SetActive(false);
            multiBubble3.SetActive(true);
            clickAmount++;
            return;
        }
        if(Input.GetMouseButtonDown(0) && clickAmount == 17f)
        {
            multiBubble3.SetActive(false);
            thatsAllBubble.SetActive(true);
            clickAmount++;
            return;
        }
        if(Input.GetMouseButtonDown(0) && clickAmount == 18f)
        {
            thatsAllBubble.SetActive(false);
            gearFinger.SetActive(true);
            gobu.SetActive(false);
            clickAmount++;
            pause.interactable = true;
            return;
        }


        //this is where the code needs to check if the player has swipe if so then turn on speak bubble 5
        if (dotManagerScript.ConnectionMade)
        {
            finger1.SetActive(false);
            badNodesBubble.SetActive(true);
            gobu.SetActive(true);
            Debug.Log("Connectionmade");
            clickAmount++;
            //Disables connectionMade just in case you wanna do it again
            dotManagerScript.ConnectionMade = false;
            return;
        }
        if(superBomb.GetComponent<SuperBombScript>().BombHasBeenUsed == true)
        {
            StartCoroutine(WaitForBomb());
            bombFinger2.SetActive(false);
            Debug.Log("HASUSEDBOMB");
            superBomb.GetComponent<SuperBombScript>().BombHasBeenUsed = false;
            return;
        }
        if (superColourRemover.GetComponent<ColourRemover>().HasUsedSCR == true)
        {
            StartCoroutine(WaitForSCR());
            scrFinger.SetActive(false);
            scrFinger2.SetActive(false);
            clickAmount++;
            Debug.Log("HASUSEDSCR");
            superColourRemover.GetComponent<ColourRemover>().HasUsedSCR = false;
            return;
        }
    }

    public void ShowBomb()
    {
        bombFinger.SetActive(false);
        bombFinger2.SetActive(true);
    }

    public void ShowSCR()
    {
        scrFinger.SetActive(false);
        scrFinger2.SetActive(true);
    }

IEnumerator WaitForBomb()
    {
        yield return new WaitForSeconds(1.5f);
        rainbowBubble.SetActive(true);
        gobu.SetActive(true);
        nodeRound2.SetActive(false);
        nodeRound3.SetActive(true);
        bomb.interactable = false;
        clickAmount++;
    }
    IEnumerator WaitForSCR()
    {
        yield return new WaitForSeconds(1f);
        happinessBubble.SetActive(true);
        finger2.SetActive(true);
        clickAmount++;
        scr.interactable = false;
    }

    public void PointHome()
    {
        gearFinger.SetActive(false);
        exitFinger.SetActive(true);
    }

    public void NoFinger()
    {
        exitFinger.SetActive(false);
        PlayerPrefs.SetInt("TUTORIAL", 1);
    }


}
