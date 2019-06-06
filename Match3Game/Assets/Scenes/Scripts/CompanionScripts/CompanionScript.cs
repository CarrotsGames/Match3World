using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
public class CompanionScript : MonoBehaviour
{
    public List<GameObject> EatingPeices;
    // Use this for initialization
    public GameObject EatingPeiceSpawner;
 
    public Slider HungerSlider;
 
    private GameObject DotManagerObj;
    private GameObject MainCamera;
    private GameObject PowerUpManGameObj;
    private GameObject HappinessGameObj;
    private DotManager DotManagerScriptRef;
    private RealTimeCounter RealTimeScript;
    private PowerUpManager PowerUpManagerScript;
    public HappinessManager HappinessManagerScript;
    // Update is called once per frame
    private int posX;
    private int posY;
    // Chain multiplier depending on how big your chain is
    private int HungerMultiplier = 1;
    private int CurrencyChance;
    private GameObject AudioManagerGameObj;
    private AudioManager AudioManagerScript;
    bool StartDestroy;
    int Index;
    string Colour;

    void Start()
    {
        AudioManagerGameObj = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManagerScript = AudioManagerGameObj.GetComponent<AudioManager>();
         // References the Realtimescript which is located on camera (TEMP)
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = MainCamera.GetComponent<RealTimeCounter>();

        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
      
        // Referneces DotManagerScript
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScriptRef = DotManagerObj.GetComponent<DotManager>();
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        // HungerSlider min and max
        HungerSlider.maxValue = 99;
        HungerSlider.minValue = 0f;
    }


    private void Update()
    {
        if(StartDestroy)
        {
            StartCoroutine(DestoyNodes());
        }
       
          

         
    }
    void PlayParticle()
    {
        switch (EatingPeices[Index].tag)
        {
            case "Red":
                {
                    Instantiate(DotManagerScriptRef.ParticleEffectPink, EatingPeices[Index].transform.position, Quaternion.identity);

                }
                break;
            case "Blue":
                {
                    Instantiate(DotManagerScriptRef.ParticleEffectBlue, EatingPeices[Index].transform.position, Quaternion.identity);

                }
                break;
            case "Yellow":
                {
                    Instantiate(DotManagerScriptRef.ParticleEffectPurple, EatingPeices[Index].transform.position, Quaternion.identity);
                }
                break;
            case "Green":
                {
                    Instantiate(DotManagerScriptRef.ParticleEffectYellow, EatingPeices[Index].transform.position, Quaternion.identity);
                }
                break;
        }
        
    }
    IEnumerator DestoyNodes()
    {
        //   Destroy(EatingPeices[Index++]);
        //   Invoke("AHHHH", 1);
        //   if(EatingPeices.Count <= 0)
        //   {
        //       Test = false;
        //   }
     
        WaitForSeconds wait = new WaitForSeconds(0.15f);
      
        for (int i = 0; i < EatingPeices.Count; i++)
        {
            Index = i;
            PlayParticle();
            Destroy(EatingPeices[i].gameObject);
            yield return wait;
        
        }
       
        StartDestroy = false;
        EatingPeices.Clear();
         
    }
    public void FeedMonster()
    {
        // transforms the peices to the eatingspawner position
        for (int i = 0; i < EatingPeices.Count; i++)
        {

            CurrencyChance = HungerMultiplier;
           // Destroy(EatingPeices[i].gameObject);
            HungerMultiplier = i / 2;
            MainCamera.GetComponent<CameraShake>().ShakeCamera(HappinessGameObj.GetComponent<HappyMultlpier>().MultlpierNum / 1.5f, 0.25f);
            // displays total score to Text
 
            DotManagerScriptRef.HighScore.text = "" + DotManagerScriptRef.TotalScore;
        }

        if (HappinessManagerScript.CanGetCurrency)
        {
            int chance = Random.Range(CurrencyChance, 100);
            if (chance >= 90)
            {
                PowerUpManagerScript.Currency += 1;
            }
            Debug.Log(chance);
            //  DotManagerScript.Currency 
        }
        if (!HappinessManagerScript.IsSleeping)
        {
            // adds happyness to the companion
            // Hunger multlplier = i(Num of peices) / 2 
            HappinessManagerScript.HappinessSliderValue += HungerMultiplier;

           
            int RandomSound = Random.Range(0, AudioManagerScript.MooblingAudio.Length);
            // When fed the companion will play a random sound in list
            AudioManagerScript.MooblingSource.clip = AudioManagerScript.MooblingAudio[RandomSound];
            AudioManagerScript.MooblingSource.Play();
     
        }
        StartDestroy = true;
    }
 
    // when the pieces collide with the companion it will destory them

    //when game closes save the current hugner and start counting down outside of the app
    private void OnApplicationPause(bool pause)
    {
      // RealTimeScript.ResetClock();
      // pause = true;
    }
    private void OnApplicationQuit()
    {
        RealTimeScript.ResetClock();
    }
}
