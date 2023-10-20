using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineArea : MonoBehaviour
{
    int total = 5000;
    float radiusMin = 2.0f;
    float radiusMax = 10.0f;
    float scaleMin = -0.5f;
    float scaleMax = 0.5f;
    float depthMin = -50.0f;
    float depthMax = 50.0f;

    public GameObject lineObj;
    public GameObject parentObj;
    public List<Material> materials;

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < total; i++)
        {
            var angle = Random.Range(0f, 2 * 3.14159f);
            var radius = Random.Range(radiusMin, radiusMax);
            var depth = Random.Range(depthMin, depthMax);
            var scale = Random.Range(scaleMin, scaleMax);
            var pos = new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), depth);
            pos += parentObj.transform.position;
            var obj = Instantiate(lineObj, pos, Quaternion.identity);
            obj.transform.localScale += Vector3.forward * scale;
            obj.transform.parent = parentObj.transform;
            var material = materials[Random.Range(0, materials.Count)];
            var childObj = obj.transform.GetChild(0).gameObject;
            childObj.GetComponent<MeshRenderer>().material = material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
