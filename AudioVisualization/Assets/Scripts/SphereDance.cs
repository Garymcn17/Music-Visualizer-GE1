using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDance : MonoBehaviour {

    public GameObject sphere1;
    List<GameObject> elements1 = new List<GameObject>();
    List<GameObject> elements2 = new List<GameObject>();
    
    float height = -4f;
    float locationX = 12f;
    float locationZ = 2.5f;
    public float radius = 3;
    public float scale = 10;

    // Use this for initialization
    void Start () {
        createSphere();
    }

    // Update is called once per frame
    void Update () {


        for (int i = 0; i < elements1.Count; i++)
        {
            //Changing a sphere on the y axis to make it look like a cylinder
            Vector3 ls1 = elements1[i].transform.localScale;
            ls1.y = Mathf.Lerp(ls1.y, 1 + (AudioScript.bands[i] * scale), Time.deltaTime * 3.0f);
            elements1[i].transform.localScale = ls1;
            //Rotating the element around its own position and right vector.
            elements1[i].transform.RotateAround(elements1[i].transform.position, elements1[i].transform.right, 50 * Time.deltaTime);

            //Changing a sphere on both the z and x axis to make a disk shape.
            Vector3 ls2 = elements2[i].transform.localScale;
            ls2.z = Mathf.Lerp(ls2.z, 1 + (AudioScript.bands[i] * scale), Time.deltaTime * 3.0f);
            elements2[i].transform.localScale = ls2;
            elements2[i].transform.RotateAround(elements2[i].transform.position, elements2[i].transform.right, 50 * Time.deltaTime);

            Vector3 ls3 = elements2[i].transform.localScale;
            ls3.x = Mathf.Lerp(ls3.x, 1 + (AudioScript.bands[i] * scale), Time.deltaTime * 3.0f);
            elements2[i].transform.localScale = ls3;
            elements2[i].transform.RotateAround(elements2[i].transform.position, elements2[i].transform.right, 50 * Time.deltaTime);

        }
        
    }
    
    float gradient1 = 1.1f;
    void createSphere ()
    {
        float gradient = .1f;
        for (int z = 0; z < 9; z++)
        {
            
            float theta = (Mathf.PI * 2.0f) / (float)AudioScript.bands.Length;

            //******************************************************************************************* Circle of Spheres1
            Vector3 p = new Vector3(
                 (Mathf.Sin(theta * z) * radius) + locationX
                , height
                , (Mathf.Cos(theta * z) * radius) + 1
                );
            p = transform.TransformPoint(p);
            Quaternion q = Quaternion.AngleAxis(theta * z * Mathf.Rad2Deg, Vector3.up);
            q = transform.rotation * q;
            GameObject sphere2 = Instantiate(sphere1, Vector3.zero, sphere1.transform.rotation) as GameObject;
            sphere2.transform.SetPositionAndRotation(p, q);
            sphere2.transform.localScale += new Vector3(0, 0, 0);
            sphere2.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                1
                , .01f + gradient
                , .8f
                );
            elements1.Add(sphere2);
            gradient += .15f;

            //******************************************************************************************* Circle of Spheres2
            Vector3 p1 = new Vector3(
                (Mathf.Sin(theta * z) * radius) + locationX 
                , height
                , (Mathf.Cos(theta * z) * radius) + 1
                );
            p1 = transform.TransformPoint(p1);
            Quaternion q1 = Quaternion.AngleAxis(theta * z * Mathf.Rad2Deg, Vector3.up);
            q1 = transform.rotation * q1;
            GameObject sphere3 = Instantiate(sphere1, Vector3.zero, sphere1.transform.rotation) as GameObject;
            sphere3.transform.SetPositionAndRotation(p1, q1);
            sphere3.transform.localScale += new Vector3(0, 0, 0);
            sphere3.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                1
                , gradient1
                , .8f
                );
            //sphere3.GetComponent<Renderer>().material.color = Color.HSVToRGB(
            //        z / (float)AudioScript.bands.Length
            //        , 1
            //        , 1
            //        );
            elements2.Add(sphere3);
            gradient1 -= .15f;
        }
    }
}
