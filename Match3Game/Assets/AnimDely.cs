using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDely : MonoBehaviour
{
    public Animator anim;

    public float waitTime = 3;




    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("StartAnim", true);
    }

    // Update is called once per frame
    

    public void StopAnim()
    {
        anim.SetBool("StartAnim", false);
        StartCoroutine(WaitForAnim());
    }

    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("StartAnim", true);
        StopCoroutine(WaitForAnim());
    }


}
