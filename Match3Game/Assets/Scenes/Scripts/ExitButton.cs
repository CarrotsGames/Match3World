using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

    public GameObject objectThatNeedsClose;

    
    public void CloseMenu()
    {
        objectThatNeedsClose.SetActive(false);
    }


}
