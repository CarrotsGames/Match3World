using UnityEngine;
using System.Collections;
using PlayFab;
using PlayFab.ClientModels;
public class LogInScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if(string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "144";
        }
     }

    // Update is called once per frame
    void Update()
    {

    }
}
