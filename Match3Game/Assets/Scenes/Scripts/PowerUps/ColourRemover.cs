using UnityEngine;
using System.Collections;

public class ColourRemover : MonoBehaviour
{

    BoardScript Board;
    GameObject BoardGameObj;
    public bool Red;
    public bool Blue;
    public bool Yellow;
    public bool Purple;
    // Use this for initialization
    void Start()
    {
        BoardGameObj = GameObject.FindGameObjectWithTag("BoardSpawn");
        Board = BoardGameObj.GetComponent<BoardScript>();
        Red = false;
        Blue = false;
        Yellow = false;
        Purple = false ;
    }
    private void Update()
    {
        
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
        }
    }
    public void SuperColourRemover()
    {
        // Put UI menu in here
    }

    void RedButton()
    {
        Red = true;
    }
    void BlueButton()
    {
        Blue = true;
    }
    void PurpleButton()
    {
        Purple = true;
    }
    void YellowButton()
    {
        Yellow = true;
    }
}
