using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCam : MonoBehaviour
{
    float speedA = 1.5f;
    Vector3 posA = new Vector3(0, 0, 0);
    Vector3 angleA = new Vector3(0, 359.9f, 0);
    float speedB = 0.4f;
    Vector3 posB = new Vector3(5, 0, 5);
    Vector3 angleB = new Vector3(0, 270, 0);
    float speedC = 0.4f;
    Vector3 posC = new Vector3(1f, 0, 0.5f);
    Vector3 angleC = new Vector3(0, 340, 0);

    Vector3 targetPos;
    Vector3 targetAngle;

    float speed = 0.5f;

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
        yield return new WaitForSeconds(8.0f);
        speed = speedC;
        targetPos = posC;
        targetAngle = angleC;
        yield return new WaitForSeconds(4.0f);
        speed = speedB;
        targetPos = posB;
        targetAngle = angleB;
        yield return new WaitForSeconds(11.0f);
        speed = speedA;
        targetPos = posA;
        targetAngle = angleA;
    }
}
