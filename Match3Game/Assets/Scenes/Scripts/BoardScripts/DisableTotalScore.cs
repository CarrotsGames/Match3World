using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTotalScore : MonoBehaviour
{
    float RemoveTotalTimer;

    // Start is called before the first frame update
    void Start()
    {
         RemoveTotalTimer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Make this run when gameobject setActive is true 

        if (this.gameObject.activeInHierarchy)
        {
            if (RemoveTotalTimer < 0)
            {
                this.gameObject.SetActive(false);
                RemoveTotalTimer += 0.5f;
                //TotalScoreGameObj.transform.position = new Vector3(500, 0, 0);
            }
            else
            {
                RemoveTotalTimer -= Time.deltaTime;
            }
        }
        else
        {
            Debug.Log("Disabled");
        }
    }
}
