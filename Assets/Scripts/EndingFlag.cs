using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingFlag : MonoBehaviour
{
    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag && transform.position.z < 0)
        {
            flag = true;
            GameObject.Find("TitleBlock1").GetComponent<LinearMove>().enabled = true;
            GameObject.Find("TitleBlock2").GetComponent<LinearMove>().enabled = true;
            // GameObject.Find("ProcessAudio").GetComponent<MusicFadeOut>().Run();
            MusicFadeOut.Run("ProcessAudio");
            StartCoroutine(DestroyAll());
        }
    }

    IEnumerator DestroyAll()
    {
        yield return new WaitForSeconds(2.0f);
        DontDestroy.DestroyAll();
    }
}
