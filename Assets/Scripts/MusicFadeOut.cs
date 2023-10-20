using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicFadeOut : MonoBehaviour
{
    float fadeTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        StartCoroutine(_Run());
    }

    public IEnumerator _Run()
    {
        print("MusicFadeOut.Run()");
        AudioSource audioSource = GetComponent<AudioSource>();
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            // print("audioSource.volume " + audioSource.volume);
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime; 
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public static void Run(string id)
    {
        try
        {
            GameObject.Find(id).GetComponent<MusicFadeOut>().Run();
        }
        catch (Exception e)
        {
            print(e);
        }
    }
}
