using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.time = 212f;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
