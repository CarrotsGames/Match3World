using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdaAnimation : MonoBehaviour
{

    private GameObject DestroyNodeGameObj;
    private DestroyNodes DestoryNodeScript;

    // Start is called before the first frame update
    void Start()
    {
        DestroyNodeGameObj = GameObject.FindGameObjectWithTag("DotManager");
        DestoryNodeScript = DestroyNodeGameObj.GetComponent<DestroyNodes>();
    }

    // Update is called once per frame
    void Update()
    {
        if(DestoryNodeScript.NormalCombo)
        {
            Debug.Log("NormalComboAnim");

        }
        else if (DestoryNodeScript.BigCombo)
        {
            Debug.Log("BigComboAnim");

        }
    }
}
