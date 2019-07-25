using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayTutorial : MonoBehaviour
{


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
    
    //Gubu Image
    public GameObject gobu;

    //Finger Animation set up to just play on awake finger1 is the swipe anim and finger2 is a scoreboard anim 
    public GameObject finger1;
    public GameObject finger2;
    public GameObject bombFinger;
    public GameObject bombFinger2;
    public GameObject scrFinger;

    //the amount of times the player has clicked on the screen
    public int clickAmount;

    //node groups
    public GameObject nodeRound1;
    public GameObject nodeRound2;


    // Start is called before the first frame update
    void Start()
    {
        // Finds gameobject with tag in hierarchy 
        dotManagerGameObj = GameObject.FindGameObjectWithTag("DotManager");
        // Grabs dotmanager script on that gameobject to get info
        dotManagerScript = dotManagerGameObj.GetComponent<DotManager>();
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
            bombBubble.SetActive(false);
            gobu.SetActive(false);
            bombFinger.SetActive(true);
            clickAmount++;
            return;
        }

        //this is where the code needs to check if the player has swipe if so then turn on speak bubble 5
        if(dotManagerScript.ConnectionMade)
        {
            finger1.SetActive(false);
            badNodesBubble.SetActive(true);
            gobu.SetActive(true);
            Debug.Log("Connectionmade");
            clickAmount++;
            //Disables connectionMade just in case you wanna do it again
            dotManagerScript.ConnectionMade = false;
        }
        if(superBomb.GetComponent<SuperBombScript>().BombHasBeenUsed == true)
        {
            StartCoroutine(WaitForBomb());
            bombFinger2.SetActive(false);
            Debug.Log("HASUSEDBOMB");
            superBomb.GetComponent<SuperBombScript>().BombHasBeenUsed = false;

        }
        if (superColourRemover.GetComponent<ColourRemover>().HasUsedSCR == true)
        {
            Debug.Log("HASUSEDSCR");
            superColourRemover.GetComponent<ColourRemover>().HasUsedSCR = false;
        }
    }

    public void ShowBomb()
    {
        bombFinger.SetActive(false);
        bombFinger2.SetActive(true);
    }

    IEnumerator WaitForBomb()
    {
        yield return new WaitForSeconds(3f);
        rainbowBubble.SetActive(true);
        gobu.SetActive(true);
    }


}
