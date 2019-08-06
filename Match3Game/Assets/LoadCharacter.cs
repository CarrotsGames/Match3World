using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCharacter : MonoBehaviour
{
    public void LoadKoko()
    {
        SceneManager.LoadScene("Triangle Scene");
    }
    public void LoadBinkie()
    {
        SceneManager.LoadScene("Circle Scene");
    }
}
