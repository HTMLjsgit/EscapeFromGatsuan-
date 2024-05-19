using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Video;
public class VideoPlayForWebGL : MonoBehaviour
{
    public string FileName;
    // Start is called before the first frame update
    void Start()
    {
        VideoPlayer videoPlayer = this.gameObject.GetComponent<VideoPlayer>();
        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, FileName);
            Debug.Log(videoPath);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
