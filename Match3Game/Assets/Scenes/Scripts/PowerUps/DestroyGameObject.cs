using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT EXISTS TO DESTORY INSTANTIATED PARTICLES AFTER THE BOMB GAMEOBJECT WAS DESTORYED
public class DestroyGameObject : MonoBehaviour {

    public float Timer;
	// Use this for initialization
	void Start () {
   

    }
	
	// Update is called once per frame
	void Update () {
        Timer -= Time.deltaTime;
        if(Timer < 0)
        {
            Destroy(this.gameObject);
        }
	}
}
