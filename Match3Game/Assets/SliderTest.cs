using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTest : MonoBehaviour
{
    public Slider happinessSlider;
    public float happinessSliderValue;

   // public string campionSave;

    public GameObject[] slider;


    GameObject HappinessManagerGameObj;
    HappinessManager HappinessManagerScript;





    // Start is called before the first frame update
    void Start()
    {

        HappinessManagerGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessManagerGameObj.GetComponent<HappinessManager>();
        happinessSliderValue = happinessSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
  //      happinessSlider.value = happinessSliderValue;
    //    PlayerPrefs.SetFloat(campionSave, happinessSliderValue);

        if (HappinessManagerScript.HappinessSliderValue > 0 && HappinessManagerScript.HappinessSliderValue < 10)
        {
            slider[0].SetActive(true);
            slider[1].SetActive(false);
            slider[9].SetActive(false);
        }
        if (HappinessManagerScript.HappinessSliderValue > 10 && HappinessManagerScript.HappinessSliderValue < 20)
        {
            slider[0].SetActive(false);
            slider[1].SetActive(true);
            slider[2].SetActive(false);
        }
        if (HappinessManagerScript.HappinessSliderValue > 20 && HappinessManagerScript.HappinessSliderValue < 30)
        {
            slider[1].SetActive(false);
            slider[2].SetActive(true);
            slider[3].SetActive(false);
        }
        if (HappinessManagerScript.HappinessSliderValue > 30 && HappinessManagerScript.HappinessSliderValue < 40)
        {
            slider[2].SetActive(false);
            slider[3].SetActive(true);
            slider[4].SetActive(false);
        }
        if (HappinessManagerScript.HappinessSliderValue > 40 && HappinessManagerScript.HappinessSliderValue < 50)
        {
            slider[3].SetActive(false);
            slider[4].SetActive(true);
            slider[5].SetActive(false);
        }
        if (HappinessManagerScript.HappinessSliderValue > 50 && HappinessManagerScript.HappinessSliderValue < 60)
        {
            slider[4].SetActive(false);
            slider[5].SetActive(true);
            slider[6].SetActive(false);
        }
        if (HappinessManagerScript.HappinessSliderValue > 60 && HappinessManagerScript.HappinessSliderValue < 70)
        {
            slider[5].SetActive(false);
            slider[6].SetActive(true);
            slider[7].SetActive(false);
        }
        if (HappinessManagerScript.HappinessSliderValue > 70 && HappinessManagerScript.HappinessSliderValue < 80)
        {
            slider[6].SetActive(false);
            slider[7].SetActive(true);
            slider[8].SetActive(false);
        }
        if (HappinessManagerScript.HappinessSliderValue > 80 && HappinessManagerScript.HappinessSliderValue < 90)
        {
            slider[7].SetActive(false);
            slider[8].SetActive(true);
            slider[9].SetActive(false);
        }
        if (HappinessManagerScript.HappinessSliderValue > 90 && HappinessManagerScript.HappinessSliderValue < 99)
        {
            slider[8].SetActive(false);
            slider[9].SetActive(true);
            slider[1].SetActive(false);
        }





    }


}
