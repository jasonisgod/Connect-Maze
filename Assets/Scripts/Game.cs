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
    public Queue<string> cmdQueue = new Queue<string>();

    float delaySeconds = 2.0f;
    int countFinish = 0;
    int currentNumber = 1;
    bool isFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovePlayerFirst());
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

        while (cmdQueue.Count > 0)
        {
            var cmd = cmdQueue.Dequeue();
            var id = int.Parse(cmd.Substring(0,1));
            var key = cmd.Substring(2,1);
            Debug.Log("Dequeue id=" + id + " key=" + key);
            MovePlayer(id, key);
        }
        
        if (isFirst)
        {
            isFirst = false;
            MovePlayerFirst();
        }
    }

    private IEnumerator MovePlayerFirst()
    {
        for (var i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("MovePlayerFirst");
            MovePlayer(1, "S");
            MovePlayer(2, "A");
            MovePlayer(3, "D");
            MovePlayer(4, "W");
        }
    }

    public void MovePlayer(int id, string key)
    {
        var player = playerList[id].GetComponent<Player>();
        switch (key)
        {
            case "W": player.Move(Vector3.up, true); break;
            case "A": player.Move(Vector3.left, false); break;
            case "S": player.Move(-Vector3.up, true); break;
            case "D": player.Move(-Vector3.left, false); break;
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
