using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float ShakeAmount;
    public float ShakeTimer;
    private Vector3 StartPos;
	// Use this for initialization
	void Start ()
    {
        StartPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ShakeCamera(ShakeAmount, 0.5f);
        }
		if(ShakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * ShakeAmount;
            transform.position = StartPos;
            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y,transform.position.z);
            ShakeTimer -= Time.deltaTime;
        }
        else
        {
            transform.position = StartPos;

        }
    }
    public void ShakeCamera(float ShakePower, float ShakeDuration)
    {
        ShakeAmount = ShakePower;
        ShakeTimer = ShakeDuration;
    }
}
