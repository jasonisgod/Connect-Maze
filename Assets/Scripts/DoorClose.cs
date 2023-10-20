using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorClose : MonoBehaviour
{
    GameObject doorTopObj;
    GameObject doorBottomObj;

    // Start is called before the first frame update
    void Start()
    {
        doorTopObj = GameObject.Find("DoorTop");
        doorTopObj.SetActive(false);
        doorBottomObj = GameObject.Find("DoorBottom");
        doorBottomObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Run()
    {
        doorTopObj.SetActive(true);
        doorBottomObj.SetActive(true);
    }
}
