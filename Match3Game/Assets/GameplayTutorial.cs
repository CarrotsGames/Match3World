using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayTutorial : MonoBehaviour
{


    //Speak Bubbles
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

    //the amount of times the player has clicked on the screen
    public int clickAmount;


    // Start is called before the first frame update
    void Start()
    {
        
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

        //this is where the code needs to check if the player has swipe if so then turn on speak bubble 5


    }
}
