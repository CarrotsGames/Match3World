using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyNodes : MonoBehaviour {
    // Yeild return values
    public float ComboSpeed;
    public float ComboVanishSpeed;
    public float ComboScorePause;
    private float ClearText;
    public bool StartDestroy;
    int Index;
    int ComboNum;
    string Colour;
    private GameObject CompanionGameObj;
    private CompanionScript CompanionScriptRef;
    public GameObject ComboGameObj;
    public Text ComboText;
    public Text ComboScore;
    bool TextVanish;
    bool CanChangeText;
    // Use this for initialization
    void Start ()
    {
        ClearText = 1;
        CompanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        CompanionScriptRef = CompanionGameObj.GetComponent<CompanionScript>();
        ComboGameObj.SetActive(false);
        TextVanish = false;
    }

    // Update is called once per frame
    private void Update()
    {
         
            // Begins the node destroy process
            if (StartDestroy)
            {
                StartCoroutine(DestoyNodes());
                ComboGameObj.SetActive(true);

            }
            if (CanChangeText)
            {
                StartCoroutine(ChangeText());
            }

        if (TextVanish)
        {
            ComboScore.text = "           " + GetComponent<DotManager>().ComboScore;

            ClearText -= Time.deltaTime;
            if (ClearText < 0)
            {
                TextVanish = false;
                GetComponent<DotManager>().ComboScore = 0;
                ComboScore.text = "           ";
                ClearText = 1;

           }
        }

    }
    // Destorys nodes in the eatingPeices list
    IEnumerator DestoyNodes()
    {
       // Set time for delay
        WaitForSeconds wait = new WaitForSeconds(ComboSpeed);

        for (int i = 0; i < CompanionScriptRef.EatingPeices.Count; i++)
        {
            Index = i;
            if (CompanionScriptRef.EatingPeices.Count > 4)
            {
                ComboText.text = "COMBO:" + ComboNum;
                bool Vibrate = true;
                if (Vibrate)
                {
                    Handheld.Vibrate();
                    Vibrate = false;

                }
            }
            PlayParticle();
            Destroy(CompanionScriptRef.EatingPeices[i].gameObject);
            // Delays forloop So that nodes are destroyed one by one
            ComboNum += 1;

            yield return wait;

        }
        ComboNum = 0;
        ComboText.text = "" ;

        StartDestroy = false;
        // Resest list
        if (CompanionScriptRef.EatingPeices.Count > 4)
        {
            CanChangeText = true;
        }
        CompanionScriptRef.EatingPeices.Clear();

    }
    IEnumerator ChangeText()
    {
        CanChangeText = false;
        WaitForSeconds ComboVanish = new WaitForSeconds(ComboVanishSpeed);

        WaitForSeconds ComboPause = new WaitForSeconds(ComboScorePause);  
        yield return ComboVanish;
        TextVanish = true;
         
     }
    // plays particle effect for each node
    void PlayParticle()
    {
        // plays particle effect at list index and position of current node
        switch (CompanionScriptRef.EatingPeices[Index].tag)
        {
            case "Red":
                {
                    Instantiate(GetComponent<DotManager>().ParticleEffectPink, CompanionScriptRef.EatingPeices[Index].transform.position, Quaternion.identity);

                }
                break;
            case "Blue":
                {
                    Instantiate(GetComponent<DotManager>().ParticleEffectBlue, CompanionScriptRef.EatingPeices[Index].transform.position, Quaternion.identity);

                }
                break;
            case "Yellow":
                {
                    Instantiate(GetComponent<DotManager>().ParticleEffectPurple, CompanionScriptRef.EatingPeices[Index].transform.position, Quaternion.identity);
                }
                break;
            case "Green":
                {
                    Instantiate(GetComponent<DotManager>().ParticleEffectYellow, CompanionScriptRef.EatingPeices[Index].transform.position, Quaternion.identity);
                }
                break;
        }

    }
}
