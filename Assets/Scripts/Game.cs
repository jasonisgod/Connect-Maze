using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<GameObject> playerList;
    public List<GameObject> finishList;
    public GameObject roadObj;
    public GameObject videoObj;
    public GameObject bgmObj;

    float delaySeconds = 2.0f;
    int countFinish = 0;

    int currentNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            currentNumber = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            currentNumber = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            currentNumber = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            currentNumber = 4;
        }

        // var player = GameObject.Find("Player" + currentNumber).GetComponent<Player>();
        var player = playerList[currentNumber].GetComponent<Player>();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.Move(Vector3.up, true);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.Move(Vector3.left, false);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.Move(-Vector3.up, true);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.Move(-Vector3.left, false);
        }
    }

    public void SetFinish(int number)
    {
        Debug.Log("Player" + number + " Finish");
        finishList[number].SetActive(true);
        countFinish += 1;
        if (countFinish == 4)
        {
            StartCoroutine(PlayVideo());
        }
    }

    private IEnumerator PlayVideo()
    {
        Debug.Log("PlayVideo waiting...");
        yield return new WaitForSeconds(delaySeconds);
        Debug.Log("PlayVide");
        bgmObj.SetActive(false);
        videoObj.SetActive(true);
    }
}
