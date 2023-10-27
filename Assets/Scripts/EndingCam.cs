using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCam : MonoBehaviour
{
    Vector3 posA = new Vector3(0, 0, 0);
    Vector3 angleA = new Vector3(0, 359.9f, 0);
    Vector3 posB = new Vector3(5, 0, 5);
    Vector3 angleB = new Vector3(0, 270, 0);

    Vector3 targetPos;
    Vector3 targetAngle;

    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = posA;
        targetAngle = angleA;
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        var offsetPos = (targetPos - transform.position);
        transform.position += (offsetPos) * speed * Time.deltaTime;
        var offsetAngle = (targetAngle - transform.eulerAngles);
        transform.eulerAngles += (offsetAngle) * speed * Time.deltaTime;
    }
    
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5.0f);
        targetPos = posB;
        targetAngle = angleB;
        yield return new WaitForSeconds(5.0f);
        targetPos = posA;
        targetAngle = angleA;
    }
}
