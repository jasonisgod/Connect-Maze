using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("TitleBlock1").GetComponent<LinearMove>().enabled = false;
        GameObject.Find("TitleBlock2").GetComponent<LinearMove>().enabled = false;
        // GameObject.Find("BGM").GetComponent<MusicFadeOut>().Run();
        MusicFadeOut.Run("BGM");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
