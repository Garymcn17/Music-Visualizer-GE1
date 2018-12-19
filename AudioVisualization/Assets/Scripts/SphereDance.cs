using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDance : MonoBehaviour {

    public GameObject sphere1;
    List<GameObject> elements1 = new List<GameObject>();
    List<GameObject> elements2 = new List<GameObject>();

    public GameObject cube1;
    public int pyraSize = 20;
    float scale1 = 1;
    float scale2 = 1;
    float height = 0;
    float width = 1;
    float locationX = 2.25f;
    float locationZ = 2.5f;
    float test = 0f;
    public float radius = 50;
    public float scale = 10;

    // Use this for initialization
    void Start () {
        createSphere();
    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < elements1.Count / 2; i++)
        {
            Vector3 ls1 = elements1[i].transform.localScale;
            ls1.z = Mathf.Lerp(ls1.z, 1 + (AudioScript.bands[i] * scale), Time.deltaTime * 3.0f);
            elements1[i].transform.localScale = ls1;
            elements1[i].transform.RotateAround(elements1[i].transform.position, -elements1[i].transform.right, 50 * Time.deltaTime);

            Vector3 ls3 = elements2[i].transform.localScale;
            ls3.x = Mathf.Lerp(ls3.x, 1 + (AudioScript.bands[i] * scale), Time.deltaTime * 3.0f);
            elements2[i].transform.localScale = ls3;
            elements2[i].transform.RotateAround(elements1[i].transform.position, elements1[i].transform.right, 50 * Time.deltaTime);
        }
    }

    void createSphere ()
    {
        for (int z = 0; z < 9; z++)
        {
            float gradient = 0f;
            float theta = (Mathf.PI * 2.0f) / (float)AudioScript.bands.Length;

            //******************************************************************************************* Circle of Spheres
            Vector3 p = new Vector3(
                 (Mathf.Sin(theta * z) * 2f) + locationX
                , .5f
                , (Mathf.Cos(theta * z) * 2f) + locationZ
                );
            p = transform.TransformPoint(p);
            Quaternion q = Quaternion.AngleAxis(theta * z * Mathf.Rad2Deg, Vector3.up);
            q = transform.rotation * q;
            GameObject sphere = Instantiate(sphere1, Vector3.zero, sphere1.transform.rotation) as GameObject;
            sphere.transform.SetPositionAndRotation(p, q);
            sphere.transform.localScale += new Vector3(0, 0, 0);
            sphere.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                1
                , .01f + gradient
                , .8f
                );
            elements1.Add(sphere);
            //******************************************************************************************* Circle of Spheres2
            Vector3 p1 = new Vector3(
                (Mathf.Sin(theta * z) * radius) + locationX
                , .5f
                , (Mathf.Cos(theta * z) * radius) + locationZ
                );
            p1 = transform.TransformPoint(p1);
            Quaternion q1 = Quaternion.AngleAxis(theta * z * Mathf.Rad2Deg, Vector3.up);
            q1 = transform.rotation * q1;
            GameObject sphere2 = Instantiate(sphere1, Vector3.zero, sphere1.transform.rotation) as GameObject;
            sphere2.transform.SetPositionAndRotation(p1, q1);
            sphere2.transform.localScale += new Vector3(0, 0, 0);
            sphere2.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                1
                , .01f + gradient
                , .8f
                );
            elements2.Add(sphere2);
        }
    }
}
