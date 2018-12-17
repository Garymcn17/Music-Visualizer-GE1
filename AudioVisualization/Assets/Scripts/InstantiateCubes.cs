using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{

    public float scale = 10;
    List<GameObject> elements = new List<GameObject>();
    List<GameObject> elements1 = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        CreateVisualisers();

    }

    public float radius = 50;

    void CreateVisualisers()
    {
        float theta = (Mathf.PI * 2.0f) / (float)AudioScript.bands.Length;
        for (int i = 0; i < AudioScript.bands.Length; i++)
        {
            Vector3 p = new Vector3(
                Mathf.Sin(theta * i) * radius
                , 0
                , Mathf.Cos(theta * i) * radius
                );
            p = transform.TransformPoint(p);
            Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
            q = transform.rotation * q;

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetPositionAndRotation(p, q);
            cube.transform.parent = this.transform;
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                i / (float)AudioScript.bands.Length
                , 1
                , 1
                );
            elements.Add(cube);

            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylinder.transform.SetPositionAndRotation(p, q);
            cube.transform.parent = this.transform;
            cylinder.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                i / (float)AudioScript.bands.Length
                , 1
                , 1
                );
            elements1.Add(cylinder);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            Vector3 ls = elements[i].transform.localScale;
            ls.y = Mathf.Lerp(ls.y, 1 + (AudioScript.bands[i] * scale), Time.deltaTime * 3.0f);
            elements[i].transform.localScale = ls;
        }

        for (int i = 0; i < elements1.Count; i++)
        {
            Vector3 ls = elements1[i].transform.localScale;
            ls.z = Mathf.Lerp(ls.z, 1 + (AudioScript.bands[i] * scale), Time.deltaTime * 3.0f);
            ls.x = Mathf.Lerp(ls.x, 1 + (AudioScript.bands[i] * scale), Time.deltaTime * 3.0f);
            elements1[i].transform.localScale = ls;
        }
    }
}
