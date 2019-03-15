using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTransitions : MonoBehaviour {

    public AudioSource antiPop;
    public AudioSource pop;
    public AudioSource giggle;
    public GameObject sceneTransitions;
    private Animator anim;

	// Use this for initialization
	void Awake () {
        anim = sceneTransitions.GetComponent<Animator>();

        anim.SetBool("UnTransition", true);
	}

    private void Start()
    {
        StartCoroutine(EndAnim());
    }

    public void PopSound()
    {
        pop.Play(0);
    }

    public void AntiPopSound()
    {
        antiPop.Play(0);
    }
    public void GiggleSound()
    {
        giggle.Play(0);
    }


    IEnumerator EndAnim()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("UnTransition", false);

    }



}
