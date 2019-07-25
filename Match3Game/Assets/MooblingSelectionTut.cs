using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MooblingSelectionTut : MonoBehaviour
{
    public GameObject mooblingsBubble;
    public GameObject changeBubble;
    public GameObject selectBubble;
    public int clickAmount;
    public Button gobuSelect;
    public GameObject finger;

    public int swipeTotal;

    public void Start()
    {
        gobuSelect.interactable = false;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickAmount == 0f)
        {
            mooblingsBubble.SetActive(false);
            changeBubble.SetActive(true);

            clickAmount++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && clickAmount == 1f)
        {
            changeBubble.SetActive(false);
            finger.SetActive(true);
            return;
        }
        if (swipeTotal == 1)
        {
            Destroy(finger);
            return;
        }
        if (swipeTotal == 5)
        {
            selectBubble.SetActive(true);
            clickAmount++;
            swipeTotal++;
            return;
        }
        if (Input.GetMouseButtonDown(0) && clickAmount == 2f)
        {
            gobuSelect.interactable = true;
            selectBubble.SetActive(false);
            return;
        }
    }



    public void AddCount()
    {
        swipeTotal++;
        return;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Gobu Tutorial");
    }



}
