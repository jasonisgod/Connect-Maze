using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int number = 0;

    float deltaStep = 1.0f;

    float wallDistance = 0.5f;
    float targetDistance = 0.1f;
    float finishDistance = 1.8f;
    float speed = 50;
    bool isFinished = false;

    List<GameObject> objList = new List<GameObject>();
    List<Vector3> dirList = new List<Vector3>();

    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        objList.Add(null);
        dirList.Add(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        var offset = (targetPos - transform.position);
        transform.position += offset * 0.5f * speed * Time.deltaTime;
    }

    public void Move(Vector3 dir, bool isVertical)
    {
        if (isFinished)
        {
            return;
        }
        if (Vector3.Distance(transform.position, targetPos) > targetDistance)
        {
            return;
        }
        if (!Physics.Raycast(targetPos, dir, wallDistance))
        {
            var newPos = targetPos + dir * deltaStep;
            var lastObj = objList[objList.Count - 1];
            var lastDir = dirList[dirList.Count - 1];
            if (-dir == lastDir)
            {
                Destroy(lastObj);
                objList.RemoveAt(objList.Count - 1);
                dirList.RemoveAt(dirList.Count - 1);
            }
            else
            {
                var roadPos = (targetPos + newPos) / 2.0f;
                var game = GameObject.Find("Game").GetComponent<Game>();
                var qua = Quaternion.Euler(0, 0, (isVertical? 90: 0));
                var obj = Instantiate(game.roadObj, roadPos, qua);
                objList.Add(obj);
                dirList.Add(dir);
            }
            targetPos = newPos;
            var finishPos = GameObject.Find("FinishPoint").transform.position;
            if (Vector3.Distance(finishPos, targetPos) < finishDistance)
            {
                var game = GameObject.Find("Game").GetComponent<Game>();
                game.SetFinish(number);
                isFinished = true;
            }
            GameObject.Find("PopAudio").GetComponent<AudioSource>().Play();
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.tag == "Finish")
    //     {
    //         Debug.Log("Player " + number + " Finish");
    //         var finish = GameObject.Find("Finish" + number);
    //         finish.SetActive(true);
    //     }
    // }
}
