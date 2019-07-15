using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlipAnimation : MonoBehaviour
{
    public GameObject paperSprite;




    public void StopAnim()
    {
        paperSprite.SetActive(false);
    }
}
