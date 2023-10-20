using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    private void Awake()
    {
        print("Video.Awake()");
        var player = GetComponent<VideoPlayer>();
        player.waitForFirstFrame = true;
        player.skipOnDrop = false;
        player.sendFrameReadyEvents = true;
        // player.frameReady += Prepare_frameReady;
        player.Play();
    }

    private void Prepare_frameReady(VideoPlayer source, long frameIdx)
    {
        print("Prepare_frameReady()");
        var player = GetComponent<VideoPlayer>();
        player.Pause();
        player.sendFrameReadyEvents = false;
    }

    void initVideoPlayer()
    {
        // // var rendTex = new CustomRenderTexture(rendTexWidth, rendTexHeight, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
        // var rendTex = new CustomRenderTexture(16, 9, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
        // rendTex.initializationMode = CustomRenderTextureUpdateMode.OnDemand;
        // rendTex.initializationSource = CustomRenderTextureInitializationSource.TextureAndColor;
       
        // rendTex.initializationColor = new Color(1, 0, 0, 0);
        // rendTex.autoGenerateMips = false;
        // rendTex.useMipMap = false;
        // rendTex.Initialize();
     
        // // material.mainTexture = rendTex;

        // var videoPlayer = GameObject.Find("PlaneBack").GetComponent<VideoPlayer>();
        // videoPlayer.renderMode = VideoRenderMode.RenderTexture; 
        // videoPlayer.targetTexture = rendTex;
        // videoPlayer.Play();
    }
}
