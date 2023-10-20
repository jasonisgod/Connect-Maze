using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string nextSceneName;

    float delaySeconds = 2.0f;
    bool isRunning = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Run();
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

    private IEnumerator _Run()
    {
        if (nextSceneName != "Ending")
        {
            // GameObject.Find("BGM").GetComponent<MusicFadeOut>().Run();
            MusicFadeOut.Run("BGM");
        }
        GameObject.Find("DoorCloseScript").GetComponent<DoorClose>().Run();
        Debug.Log("LoadEndScene waiting...");
        yield return new WaitForSeconds(delaySeconds);
        Debug.Log("LoadEndScene " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}
