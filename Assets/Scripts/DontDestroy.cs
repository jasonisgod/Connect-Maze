using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    static List<GameObject> objs = new List<GameObject>();

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        objs.Add(this.gameObject);
    }

    public static void DestroyAll()
    {
        foreach (var obj in objs)
        {
            Destroy(obj);
        }
    }
}
