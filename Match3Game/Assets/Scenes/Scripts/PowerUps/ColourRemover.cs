using UnityEngine;
using System.Collections;

public class ColourRemover : MonoBehaviour
{

    public GameObject Menu;
    public GameObject MouseCursorObj;
    BoardScript Board;
    GameObject BoardGameObj;
    
    public bool Red;
    public bool Blue;
    public bool Yellow;
    public bool Purple;
    bool PowerUpInUse;
    private MouseFollowScript MouseFollow;
    private DotManagerScript dotManagerScript;
    private GameObject DotManagerObj;
    // Use this for initialization
    void Start()
    {
        Menu.SetActive(false);
        BoardGameObj = GameObject.FindGameObjectWithTag("BoardSpawn");
        Board = BoardGameObj.GetComponent<BoardScript>();
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        PowerUpInUse = false;
        MouseCursorObj = GameObject.FindGameObjectWithTag("Mouse");
        MouseFollow = MouseCursorObj.GetComponent<MouseFollowScript>();
        Red = false;
        Blue = false;
        Yellow = false;
        Purple = false ;
    }
    private void Update()
    {
        // RaycastHit2D hit;
        if (PowerUpInUse)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    dotManagerScript.StopInteracting = true;
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

            }
            MouseCursorObj.SetActive(false);

        }

    }
    public void SuperColourRemoverMenu()
    {
        PowerUpInUse = true;
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
