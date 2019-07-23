using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RenderVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer video;

    private void Start()
    {
        StartCoroutine(PlayVideo());
    }



    IEnumerator PlayVideo()
    {
        video.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!video.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = video.texture;
        video.Play();
        
    }



}
