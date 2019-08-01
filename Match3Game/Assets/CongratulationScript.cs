using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CongratulationScript : MonoBehaviour
{

    public GameObject congratsCanvus;
    public GameObject CriusUnlockImage;
    public GameObject OkamiUnlockImage;
    public GameObject SaucoUnlockImage;
    public GameObject ChickPeaUnlockImage;
    public GameObject SquishyUnlockImage;
    public GameObject MoneyUnlockImage;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (congratsCanvus.active && Input.GetMouseButtonDown(0))
        {
            congratsCanvus.SetActive(false);
            CriusUnlockImage.SetActive(false);
            OkamiUnlockImage.SetActive(false);
            SaucoUnlockImage.SetActive(false);
            SquishyUnlockImage.SetActive(false);
            ChickPeaUnlockImage.SetActive(false);
            MoneyUnlockImage.SetActive(false);
        }
    }
}
