using UnityEngine;
using System.Collections;

public class ColourRemover : MonoBehaviour
{

    float Timer = 0.25f;

    public bool Red;
    public bool Blue;
    public bool Yellow;
    public bool Purple;
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
    private PowerUpManager PowerUpManagerScript;

    // Use this for initialization
    void Start()
    {
         PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        BoardGameObj = GameObject.FindGameObjectWithTag("BoardSpawn");
        Board = BoardGameObj.GetComponent<BoardScript>();
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        MouseCursorObj = GameObject.FindGameObjectWithTag("Mouse");   
 
        PowerUpInUse = false;
        Red = false;
        Blue = false;
        Yellow = false;
        Purple = false;
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
                    DotManagerScript.StopInteracting = true;
                    if (hit.collider.gameObject.tag == "Red")
                    {
                        Red = true;
                    }
                    if (hit.collider.gameObject.tag == "Blue")
                    {
                        Blue = true;
                    }
                    if (hit.collider.gameObject.tag == "Green")
                    {
                        Yellow = true;
                    }
                    if (hit.collider.gameObject.tag == "Yellow")
                    {
                        Purple = true;
                    }
                }

                // Do something with the object that was hit by the raycast.
            }

            if (Red)
            {
                for (int i = 0; i < BoardGameObj.transform.childCount; i++)
                {
                    if (BoardGameObj.transform.GetChild(i).tag == "Red")
                    {
                        Destroy(BoardGameObj.transform.GetChild(i).gameObject);
                    }
                }
                Red = false;
                PowerUpInUse = false;
                DotManagerScript.ResetMaterial = true;
                GoTimer = true;

            }
            if (Blue)
            {
                for (int i = 0; i < BoardGameObj.transform.childCount; i++)
                {
                    if (BoardGameObj.transform.GetChild(i).tag == "Blue")
                    {
                        Destroy(BoardGameObj.transform.GetChild(i).gameObject);
                    }
                }
                Blue = false;
                PowerUpInUse = false;
                DotManagerScript.ResetMaterial = true;
                GoTimer = true;

            }
            if (Yellow)
            {
                for (int i = 0; i < BoardGameObj.transform.childCount; i++)
                {
                    if (BoardGameObj.transform.GetChild(i).tag == "Green")
                    {
                        Destroy(BoardGameObj.transform.GetChild(i).gameObject);
                    }
                }
                Yellow = false;
                PowerUpInUse = false;
                DotManagerScript.ResetMaterial = true;
                GoTimer = true;

            }
            if (Purple)
            {
                for (int i = 0; i < BoardGameObj.transform.childCount; i++)
                {
                    if (BoardGameObj.transform.GetChild(i).tag == "Yellow")
                    {
                        Destroy(BoardGameObj.transform.GetChild(i).gameObject);
                    }
                }
                Purple = false;
                PowerUpInUse = false;
                DotManagerScript.ResetMaterial = true;
                GoTimer = true;

            }
            MouseCursorObj.SetActive(false);
        }

    }
    public void SuperColourRemoverMenu()
    {
        if(PowerUpManagerScript.HasSCR)
        { 
        PowerUpInUse = true;
        DotManagerScript.ResetMaterial = false;
            PowerUpManagerScript.NumOfSCR -= 1;
            for (int i = 0; i < BoardGameObj.transform.childCount; i++)
            {

                switch (BoardGameObj.transform.GetChild(i).tag)
                {
                    case "Red":
                        BoardGameObj.transform.GetChild(i).GetComponent<Renderer>().material = RedMat;
                        //BoardGameObj.transform.GetChild(i).GetComponentInChildren<Renderer>().material = RedMat;

                        break;
                    case "Blue":
                        BoardGameObj.transform.GetChild(i).GetComponent<Renderer>().material = BlueMat;
                        //    BoardGameObj.transform.GetChild(i).GetComponentInChildren<Renderer>().material = BlueMat;

                        break;
                    case "Green":
                        BoardGameObj.transform.GetChild(i).GetComponent<Renderer>().material = YellowMat;
                        //    BoardGameObj.transform.GetChild(i).GetComponentInChildren<Renderer>().material = YellowMat;

                        break;
                    case "Yellow":
                        BoardGameObj.transform.GetChild(i).GetComponent<Renderer>().material = PurpleMat;
                        //    BoardGameObj.transform.GetChild(i).GetComponentInChildren<Renderer>().material = PurpleMat;

                        break;
                }
                Debug.Log("Permanent");
            }
        }
        else
        {
            Debug.Log("PowerUpEmpty");
            PowerUpManagerScript.PowerUpEmpty();
        }
    }

   //public void RedButton()
   //{
   //   Red = true;
   //   Menu.SetActive(false);
   //
   //}
   //public void BlueButton()
   //{
   //   Blue = true;
   //   Menu.SetActive(false);
   //
   //}
   //public void PurpleButton()
   //{
   //   Purple = true;
   //   Menu.SetActive(false);
   //
   //}
   //public void YellowButton()
   //{
   //   Yellow = true;
   //   Menu.SetActive(false);
   //}
}
