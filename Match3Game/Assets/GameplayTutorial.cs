using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayTutorial : MonoBehaviour
{
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
    public GameObject gobu;

    public GameObject finger1;
    public GameObject finger2;


    public int clickAmount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickAmount == 0f)
        {
            basicBubble.SetActive(false);
            scoreboardBubble.SetActive(true);
            finger2.SetActive(true);
            clickAmount++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && clickAmount == 1f)
        {
            finger2.SetActive(false);
            scoreboardBubble.SetActive(false);
            connectionBubble.SetActive(true);
            clickAmount++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && clickAmount == 2f)
        {
            connectionBubble.SetActive(false);
            connectionBubble2.SetActive(true);
            clickAmount++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && clickAmount == 3f)
        {
            finger1.SetActive(true);
            connectionBubble2.SetActive(false);
            clickAmount++;
            gobu.SetActive(false);
            return;
        }


    }
}
