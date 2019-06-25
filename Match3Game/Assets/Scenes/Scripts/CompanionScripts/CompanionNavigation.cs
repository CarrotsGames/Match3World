using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// uses Realtime script to count down happiness
public class CompanionNavigation : MonoBehaviour
{
    private RealTimeCounter RealTimeScript;
    private GameObject RealTimerGameObj;
    // [HideInInspector]
    public string CompanionName;
    public int CompanionNumber;
    // Gets unlcoked companions in list
    public List<GameObject> Companions;
    private GameObject CompanionStorage;
    public int Navigate;
    public float[] Happiness;

    private Vector2 StartPos;
    private Vector2 SwipeDelta;

    private bool SwipeRight;
    private bool Swipeleft;
    private bool IsDragging;


    public Slider HappySlider;
     // Use this for initialization
    void Start()
    {
 
      //  HappySlider.value = 0;

        RealTimerGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = RealTimerGameObj.GetComponent<RealTimeCounter>();
        CompanionStorage = GameObject.FindGameObjectWithTag("Creatures");
        // Adds all objects in gameobject to the Companions list 
        for (int i = 0; i < CompanionStorage.transform.childCount; i++)
        {
            Companions.Add(CompanionStorage.transform.GetChild(i).gameObject);
        }
        // sets the first avaialble companion to appear on screen(GOBU)
        Companions[0].SetActive(true);
        CompanionName = Companions[0].name;
        CompanionSwitch();
    }
    private void Update()
    {
        // if mouse is down begin drag
        if (Input.GetMouseButtonDown(0))
        {
            StartPos = Input.mousePosition;
            IsDragging = true ;
        }
        // when released reset everything
        else if(Input.GetMouseButtonUp(0))
        {
            IsDragging = false;
            Reset();
        }
        // gets the first finger on the screen and follows that position 
        if (Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                IsDragging = true;

                StartPos = Input.touches[0].position;

            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                IsDragging = false;

                Reset();

            }
        }
        
        SwipeDelta = Vector2.zero;
        // if a drag is occuring
        if (IsDragging)
        {
            if (Input.touches.Length > 0)
            {
                SwipeDelta = Input.touches[0].position - StartPos;
            }
            else if (Input.GetMouseButton(0))
            {
                SwipeDelta = (Vector2)Input.mousePosition - StartPos;
 
            }
        }
        // if the  swipe goes past its limit check if right or left swipe
        if(SwipeDelta.magnitude > 100)
        {
            // Direction of swipe 
            float x = SwipeDelta.x;
            float y = SwipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                if(x < 0)
                {
                    NavLeft();
                }
                else
                {
                     NavRight();
                }
            }
            Reset();
        }
    }
    private void Reset()
    {
        StartPos = SwipeDelta = Vector2.zero;
        IsDragging = false;
    }
 
    public void PlayLevel(int Level)
    {
        // each character button has assigned Level value which when pressed loads level
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
            case 5:
                SceneManager.LoadScene("Crius");
                break;

            case 6:
                SceneManager.LoadScene("Sauco");
                break;
            case 7:
                SceneManager.LoadScene("Chick-Pee");
                break;
            case 9:
                SceneManager.LoadScene("Cronus");
                break;
        }

    }
    public void NavLeft()
    {
        // disable current companion
        Companions[Navigate].SetActive(false);
        if (Navigate == Companions.Count - 1)
        {
            // go back to first companion in list
            Navigate = 0;
            //activate new companion
            Companions[Navigate].SetActive(true);
            CompanionName = Companions[Navigate].name;
      
        }
        // go to next companion in list
        else
        {
            Navigate += 1;
            Companions[Navigate].SetActive(true);
            CompanionName = Companions[Navigate].name;
            //    Navigation();
        }
        Reset();
        CompanionSwitch();

    }
    public void NavRight()
    {

        // if companions on right go right
        if (Navigate == 0)
        {

            Companions[Navigate].SetActive(false);
            Navigate = Companions.Count - 1;
            Companions[Navigate].SetActive(true);
            CompanionName = Companions[Navigate].name;
            //   Companions[Navigate].SetActive(true);
            //     Navigation();

        }
        else
        {
            Companions[Navigate].SetActive(false);

            Navigate -= 1;
            Companions[Navigate].SetActive(true);
            CompanionName = Companions[Navigate].name;
            //   Companions[Navigate].SetActive(true);
            //   Navigation();

        }
        Reset();
        CompanionSwitch();

    }

    // Update is called once per frame
    void CompanionSwitch()
    {
        // checks name of companion and displays how much happiness 
        // that specific companion has when highlited 
        switch (CompanionName)
        {
            case "Gobu":
                Happiness[0] = PlayerPrefs.GetFloat("GobuHappiness");
                RealTimeScript.HappinessCountDown[0] = Happiness[0];
                HappySlider.value = RealTimeScript.HappinessCountDown[0];

                break;
            case "Binkie Locked":
                Happiness[1] = PlayerPrefs.GetFloat("BinkyHappiness");
                RealTimeScript.HappinessCountDown[1] = Happiness[1];
                HappySlider.value = RealTimeScript.HappinessCountDown[1];

                break;
            case "Koko Locked":
                Happiness[2] = PlayerPrefs.GetFloat("KokoHappiness");
                //HappinessManagerScript.Happiness = RealTimeScript.TimerCountDown2;
                RealTimeScript.HappinessCountDown[2] = Happiness[2];
                HappySlider.value = RealTimeScript.HappinessCountDown[2];

                break;
            //shares happiness with Gobu
            case "Crius Locked":
                Happiness[3] = PlayerPrefs.GetFloat("CriusHappiness");
                RealTimeScript.HappinessCountDown[3] = Happiness[3];
                HappySlider.value = RealTimeScript.HappinessCountDown[3];

                break;
          
            case "Sauco Locked":
                Happiness[4] = PlayerPrefs.GetFloat("SaucoHappiness");
                RealTimeScript.HappinessCountDown[4] = Happiness[4];
                HappySlider.value = RealTimeScript.HappinessCountDown[4];

                break;

            case "Chick-Pee Locked":
                Happiness[5] = PlayerPrefs.GetFloat("ChickPeaHappiness");
                RealTimeScript.HappinessCountDown[5] = Happiness[5];
                HappySlider.value = RealTimeScript.HappinessCountDown[5];

                break;
            case "Cronus Locked":
                Happiness[6] = PlayerPrefs.GetFloat("ChickPeaHappiness");
                RealTimeScript.HappinessCountDown[6] = Happiness[6];
                HappySlider.value = RealTimeScript.HappinessCountDown[6];

                break;
        }
   

    }
}