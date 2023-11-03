using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NextScene : MonoBehaviour
{
    public string nextSceneName;

    float delaySeconds = 2.0f;
    bool isRunning = false;
    // int pressCount = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var name = SceneManager.GetActiveScene().name;
            if (name == "Starting")
            {
                Run();
            }
            if (name == "Waiting")
            {
                Run();
            }
            if (name == "SampleScene")
            {
                var game = GameObject.Find("Game").GetComponent<Game>();
                if (!game.isActivated)
                {
                    game.Activate();
                }
                else
                {
                    Run();
                }
            }
            if (name == "Ending")
            {
                var endingFlag = GameObject.Find("EndingFlag").GetComponent<EndingFlag>();
                if (endingFlag.flag)
                {
                    Run();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public void Run()
    {
        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine(_Run());
        }
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator _Run()
    {
        if (nextSceneName != "Ending")
        {
            // GameObject.Find("BGM").GetComponent<MusicFadeOut>().Run();
            MusicFadeOut.Run("BGM");
        }

        try
        {
            GameObject.Find("DoorCloseScript").GetComponent<DoorClose>().Run();
        }
        catch (Exception e)
        {
            print(e);
        }
        
        Debug.Log("LoadEndScene waiting...");
        yield return new WaitForSeconds(delaySeconds);
        Debug.Log("LoadEndScene " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}
