using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControl : MonoBehaviour
{
    Vector3 pos = Vector3.zero;

    public GameObject prefab;
    public List<GameObject> objects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var hitObj = GameObject.Find("Hit");
        if (hitObj.transform.position.z > pos.z)
        {
            Add();
        }
    }

    public void Add()
    {
        print("LineControl.Add");
        pos += Vector3.forward * 100.0f;
        var newObj = Instantiate(prefab, pos, Quaternion.identity);
        objects.Add(newObj);
        foreach (var obj in objects)
        {
            if (pos.z - obj.transform.position.z >= 150f)
            {
                Destroy(obj);
                objects.Remove(obj);
            }
        }
    }
}
