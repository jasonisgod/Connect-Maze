using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove : MonoBehaviour
{
    public Vector3 direction = -Vector3.forward;
    public float speed = 10.0f;
    public float distance = 1000.0f;
    public float delayTime = 0.0f;

    Vector3 initPos;

    float pastTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pastTime += Time.deltaTime;

        if (pastTime < delayTime)
        {
            return;
        }

        if (Vector3.Distance(initPos, transform.position) < distance)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
