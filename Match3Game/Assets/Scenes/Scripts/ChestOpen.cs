using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour {

    public GameObject chestWalls;
    public GameObject openChest;
    public Animator anim;

    public int waitTimer = 5;

	// Use this for initialization
	void Start () {
        StartCoroutine(OpenChest());
        openChest.SetActive(false);
	}


    IEnumerator OpenChest ()
    {
        yield return new WaitForSeconds(waitTimer);
        anim.SetBool("StartAnim", true);
        
    }


    public void AnimDone()
    {
        Destroy(chestWalls);
        openChest.SetActive(true);
        Destroy(this.gameObject);
    }

}
