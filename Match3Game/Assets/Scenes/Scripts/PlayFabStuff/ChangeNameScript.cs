using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeNameScript : MonoBehaviour
{
    GameObject LeaderBoardGameObj;
    LeaderBoardScript LeaderScript;
    int i;
    bool CountDown;
    float Timer = 2;
    private void Start()
    {
        CountDown = false;
    }
    private void Update()
    {
        if(CountDown)
        {
            Timer -= Time.deltaTime;
            if(Timer < 0)
            {
                LeaderScript.LoggedIn();

                CountDown = false;
                Timer = 2;
            }
        }
    }
    // Update is called once per frame
    public void ChangeName()
    {
        LeaderBoardGameObj = GameObject.FindGameObjectWithTag("LeaderBoard");
        LeaderScript = LeaderBoardGameObj.GetComponent<LeaderBoardScript>();
        LeaderScript.ListNames.Clear();
        LeaderScript.OffsetY = 0;

        foreach (Transform child in LeaderScript.transform)
        {
            GameObject.Destroy(child.gameObject);

        }
        LeaderScript.i = 0;
        LeaderScript.NumberOfNames = LeaderScript.NumbOfNamesStore;
         for (  i = 0; i < LeaderScript.NumberOfNames.Length; i++)
         {
             Text Go;
             Go = Instantiate(LeaderScript.text, LeaderScript.transform.position + new Vector3(0, LeaderScript.OffsetY, 0), Quaternion.identity) as Text;
             Go.transform.parent = LeaderScript.transform;
         
             LeaderScript.ListNames.Add(Go);
             LeaderScript.OffsetY -= 7;
         }
         i = 0;
         LeaderScript.UpdateName();
        CountDown = true;
    }

}
