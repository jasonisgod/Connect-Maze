using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    public List<GameObject> playerList;
    public List<GameObject> finishList;
    public GameObject roadObj;
    public GameObject videoObj;
    public GameObject bgmObj;
    public GameObject activatePanel;
    public TMP_Text activateText;
    public TMP_Text activateBarText;
    public GameObject activateSuccess;
    public Queue<string> cmdQueue = new Queue<string>();

    float delaySeconds = 2.0f;
    int countFinish = 0;
    int currentNumber = 1;
    bool isFirst = true;
    public bool isActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovePlayerFirst());
        activatePanel.SetActive(false);
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
        // var player = playerList[currentNumber].GetComponent<Player>();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayer(currentNumber, "W");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayer(currentNumber, "A");
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayer(currentNumber, "S");
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayer(currentNumber, "D");
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
        
        // if (Input.GetKeyDown(KeyCode.Return))
        // {
        //     StartCoroutine(Activate());
        // }
    }

    private IEnumerator MovePlayerFirst()
    {
        yield return new WaitForSeconds(2.0f);
        for (var i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("MovePlayerFirst");
            MovePlayer(1, "S", true);
            MovePlayer(2, "A", true);
            MovePlayer(3, "D", true);
            MovePlayer(4, "W", true);
        }
    }

    public void MovePlayer(int id, string key, bool sound = true)
    {
        // if (sound)
        // {
        //     GameObject.Find("PopAudio").GetComponent<AudioSource>().Play();
        // }
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
        GameObject.Find("FinishAudio").GetComponent<AudioSource>().Play();
        finishList[number].SetActive(true);
        countFinish += 1;
        if (countFinish == 4)
        {
            // StartCoroutine(PlayVideo());
            // StartCoroutine(LoadEndScene());
            Activate();
        }
    }

    public void Activate()
    {
        if (isActivated)
        {
            return;
        }
        isActivated = true;
        StartCoroutine(_Activate());
    }

    private IEnumerator _Activate()
    {
        Debug.Log("Activate()");
        activateText.text = "0%";
        yield return new WaitForSeconds(0.5f);
        activatePanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("ProcessAudio").GetComponent<AudioSource>().Play();
        for (var i = 0; i <= 100; i++)
        {
            yield return new WaitForSeconds(0.02f);
            activateText.text = i.ToString() + "%";
            var barStr = "";
            for (var j = 0; j < 20; j++)
            {
                barStr += (i / 5 > j? "> ": "_ ");
            }
            activateBarText.text = barStr;
        }
        GameObject.Find("NextScene").GetComponent<NextScene>().Run();
        yield return new WaitForSeconds(0.5f);
        activateSuccess.SetActive(true);
        GameObject.Find("FinishAudio").GetComponent<AudioSource>().Play();
        // for (var i = 0; i < 3; i++)
        // {
        //     yield return new WaitForSeconds(0.5f);
        // }
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
