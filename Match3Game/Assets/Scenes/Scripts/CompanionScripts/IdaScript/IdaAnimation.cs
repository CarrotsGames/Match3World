using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdaAnimation : MonoBehaviour
{

    private GameObject DestroyNodeGameObj;
    private DestroyNodes DestoryNodeScript;

    public Animator idaAnimator;

    // Start is called before the first frame update
    void Start()
    {
        DestroyNodeGameObj = GameObject.FindGameObjectWithTag("DotManager");
        DestoryNodeScript = DestroyNodeGameObj.GetComponent<DestroyNodes>();
    }

    // Update is called once per frame
    void Update()
    {
      //  if(DestoryNodeScript.NormalCombo)
      //  { 
      //      Debug.Log("NormalComboAnim");
      //      idaAnimator.SetBool("Normal Combo", true);
      //  }
      //  else if (DestoryNodeScript.BigCombo)
      //  {
      //      Debug.Log("BigComboAnim");
      //      idaAnimator.SetBool("Big Combo", true);
      //
      //  }
    }


    public void ResetAll()
    {
        idaAnimator.SetBool("Big Combo", false);
        idaAnimator.SetBool("Normal Combo", false);

    }
}
