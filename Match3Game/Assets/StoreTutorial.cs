using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreTutorial : MonoBehaviour
{
    public GameObject speakBubble;
    public GameObject navigationBubble;
    public GameObject moneyBubble;
    public GameObject headHomeBubble;

    public GameObject fingers;
    public GameObject finger;

    public GameObject particle;

    public int clickNumber;
    public int arrowClickNumber;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickNumber == 0f)
        {
            speakBubble.SetActive(false);
            navigationBubble.SetActive(true);

            clickNumber++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && clickNumber == 1f)
        {
            navigationBubble.SetActive(false);
            fingers.SetActive(true);
            clickNumber++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && clickNumber == 2f)
        {
            navigationBubble.SetActive(false);
            //clickNumber++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && clickNumber == 3f)
        {
            moneyBubble.SetActive(false);
            headHomeBubble.SetActive(true);
            clickNumber++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && clickNumber == 4f)
        {
            headHomeBubble.SetActive(false);
            finger.SetActive(true);
            clickNumber++;
            particle.SetActive(true);
            return;
        }
    }


    public void ArrowClicked()
    {
        arrowClickNumber++;
        fingers.SetActive(false);

        if (arrowClickNumber == 5)
        {
            moneyBubble.SetActive(true);
            clickNumber++;
        }

    }


    public void LoadNextTutorial()
    {
        SceneManager.LoadScene("Tutorial 2");
    }

}
