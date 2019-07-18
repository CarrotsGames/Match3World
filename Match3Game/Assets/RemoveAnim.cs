using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAnim : MonoBehaviour
{

    public GameObject fadeCanvus;
    public void DetroyCanvus()
    {
        Destroy(fadeCanvus);
    }
}
