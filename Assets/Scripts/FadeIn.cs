using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    Vector3 targetScale;
    bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        targetScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning && transform.position.z < 30f)
        {
            isRunning = true;
            print("FadeIn trigger");
        }

        if (isRunning)
        {
            var offset = targetScale - transform.localScale;
            transform.localScale += offset * 0.9f * Time.deltaTime;
        }
    }
}
