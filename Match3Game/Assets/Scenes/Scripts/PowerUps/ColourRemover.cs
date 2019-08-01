using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ColourRemover : MonoBehaviour
{

    float Timer = 0.25f;
    public bool Red;  
    public bool Rainbow;
    [HideInInspector]
    public bool HasUsedSCR;
    bool GoTimer;
    public GameObject MouseCursorObj;
    public Component[] Renderer;
    public Material RedMat;
    public Material BlueMat;
    public Material YellowMat;
    public Material PurpleMat;

    private bool PowerUpInUse;
    private DotManager DotManagerScript;
    private GameObject PowerUpManGameObj;
    private GameObject DotManagerObj;
    private BoardScript Board;
    private GameObject BoardGameObj;
    private GameObject SpecialBoardGameObj;
    private PowerUpManager PowerUpManagerScript;
    private int SCRAmount;
    private string Colour;
    private string SceneName;
    private GameObject PowerUpGameObj;
    int TimesUsed;

    // Use this for initialization
    void Start()
    {
        TimesUsed = PlayerPrefs.GetInt("SCR");
        PowerUpGameObj = GameObject.Find("PowerUps");
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneName = CurrentScene.name;
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        BoardGameObj = GameObject.FindGameObjectWithTag("BoardSpawn");
        SpecialBoardGameObj = GameObject.Find("SpecialNodeSpawn");

        // Disables if tutorial is on
        if (SceneName != "Gobu Tutorial")
        {
            Board = BoardGameObj.GetComponent<BoardScript>();

            BoardGameObj.SetActive(true);

            MouseCursorObj = GameObject.FindGameObjectWithTag("Mouse");
        }
        else
        {
            // Sets tutorial board to Boardgameobj
            BoardGameObj = GameObject.FindGameObjectWithTag("BoardSpawn");
            BoardGameObj.SetActive(false);
        }
        PowerUpInUse = false;
        Red = false;
        HasUsedSCR = false;
        GoTimer = false;
    }
    private void Update()
    {
        if(GoTimer)
        {
            DotManagerScript.ResetMaterial = true;

            Timer -= Time.deltaTime;
            if(Timer < 0 )
            {
                DotManagerScript.ResetMaterial = false;
                Timer = 0.25f;
                GoTimer = false;
            }
        }
        // RaycastHit2D hit;
        if (PowerUpInUse)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
             if (hit.collider != null)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    DotManagerScript.CanPlay = false;
                    if (hit.collider.gameObject.tag == "Red")
                    {
 
                        Colour = hit.collider.gameObject.tag;
                           Red = true;
                    }
                    if (hit.collider.gameObject.tag == "Blue")
                    {
 
                        Colour = hit.collider.gameObject.tag;

                        Red = true;
                    }
                    if (hit.collider.gameObject.tag == "Green")
                    {
 
                        Colour = hit.collider.gameObject.tag;

                        Red = true;
                    }
                    if (hit.collider.gameObject.tag == "Yellow")
                    {
 
                        Colour = hit.collider.gameObject.tag;

                        Red = true;
                    }
                    if (hit.collider.gameObject.tag == "Rainbow")
                    {

                        Colour = hit.collider.gameObject.tag;

                        Rainbow = true;
                    }

                }

                // Do something with the object that was hit by the raycast.
            }
            // if the desired colour is true destroy all nodes with that colour
            if (Red)
            {    
                // Counts how many times player uses this powerup
                TimesUsed++;
                PlayerPrefs.SetInt("SCR", TimesUsed);
                for (int i = 0; i < BoardGameObj.transform.childCount; i++)
                {
                    SCRAmount += 1;
                    if (BoardGameObj.transform.GetChild(i).tag == Colour)
                    {
                        Destroy(BoardGameObj.transform.GetChild(i).gameObject);
                    }
                 }
                Red = false;
                PowerUpInUse = false;
                DotManagerScript.ResetMaterial = true;
                GoTimer = true;
                DotManagerScript.TotalScore += SCRAmount * DotManagerScript.Multipier;
                DotManagerScript.HighScore.text = "" + DotManagerScript.TotalScore;
                HasUsedSCR = true;
                PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonEnable();

            }
            //Destroys rainbows nodes 
            // NOTE: this has its own if statement because it is getting the child of a 
            // diffrent gameobject
            if (Rainbow)
            {  
                // Counts how many times player uses this powerup
                TimesUsed++;
                PlayerPrefs.SetInt("SCR", TimesUsed);
                for (int i = 0; i < SpecialBoardGameObj.transform.childCount; i++)
                {
                    SCRAmount += 1;
            
                    if (SpecialBoardGameObj.transform.GetChild(i).tag == "Rainbow")
                    {
                        Destroy(SpecialBoardGameObj.transform.GetChild(i).gameObject);
                    }
                }
                Rainbow = false;
                PowerUpInUse = false;
                DotManagerScript.ResetMaterial = true;
                GoTimer = true;
                DotManagerScript.TotalScore += SCRAmount * DotManagerScript.Multipier;
                DotManagerScript.HighScore.text = "" + DotManagerScript.TotalScore;
                HasUsedSCR = true;
                PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonEnable();

            }


        }

    }
    public void SuperColourRemoverMenu()
    {
        if(PowerUpManagerScript.HasSCR)
        {
            PowerUpGameObj.GetComponent<DisablePowerUps>().OnButtonDisable();
            PowerUpInUse = true;
            DotManagerScript.ResetMaterial = false;
            PowerUpManagerScript.NumOfSCR -= 1;
    
            // Highlights Colours nodes with their desired colour eg red has red outline
            for (int i = 0; i < BoardGameObj.transform.childCount; i++)
            {

                switch (BoardGameObj.transform.GetChild(i).tag)
                {
                    case "Red":
                        BoardGameObj.transform.GetChild(i).GetComponent<Renderer>().material = RedMat;
 
                        break;
                    case "Blue":
                        BoardGameObj.transform.GetChild(i).GetComponent<Renderer>().material = BlueMat;
 
                        break;
                    case "Green":
                        BoardGameObj.transform.GetChild(i).GetComponent<Renderer>().material = YellowMat;
 
                        break;
                    case "Yellow":
                        BoardGameObj.transform.GetChild(i).GetComponent<Renderer>().material = PurpleMat;
 
                        break;
                }
             }
        }
        // If player has no more colourRemovovers Play pop up and bring them to store
        else
        {
            Debug.Log("PowerUpEmpty");
            PowerUpManagerScript.PowerUpEmpty();
        }
    }

 
}
