using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingFlag : MonoBehaviour
{
    bool flag = false;

    GameObject titleObj;
    GameObject botObj;

    // Start is called before the first frame update
    void Start()
    {
        botObj = GameObject.Find("vbot7-run");
        titleObj = GameObject.Find("Title");
        titleObj.SetActive(false);
        // GameObject.Find("TitleBlock1").GetComponent<LinearMove>().enabled = false;
        // GameObject.Find("TitleBlock2").GetComponent<LinearMove>().enabled = false;
        // GameObject.Find("BGM").GetComponent<MusicFadeOut>().Run();
        MusicFadeOut.Run("BGM");
        StartCoroutine(DestroyDoor());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 3f)
        {
            botObj.SetActive(false);
        }
        if (!flag && transform.position.z < 0)
        {
            flag = true;
            titleObj.SetActive(true);
            // GameObject.Find("TitleBlock1").GetComponent<LinearMove>().enabled = true;
            // GameObject.Find("TitleBlock2").GetComponent<LinearMove>().enabled = true;
            // GameObject.Find("ProcessAudio").GetComponent<MusicFadeOut>().Run();
            MusicFadeOut.Run("ProcessAudio");
            StartCoroutine(DestroyAll());
        }
    }

    IEnumerator DestroyDoor()
    {
        yield return new WaitForSeconds(4.0f);
        GameObject.Find("DoorOpen").SetActive(false);
        GameObject.Find("DoorClose").SetActive(false);
    }

    IEnumerator DestroyAll()
    {
        yield return new WaitForSeconds(2.0f);
        DontDestroy.DestroyAll();
    }
}
