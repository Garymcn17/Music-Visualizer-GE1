using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour {

    public float radius = 50;
    public float scale = 10;
    List<GameObject> elements = new List<GameObject>();
    List<GameObject> elements1 = new List<GameObject>();
    List<GameObject> elements2 = new List<GameObject>();
    List<GameObject> elements3 = new List<GameObject>();
    List<GameObject> elements4 = new List<GameObject>();
    List<GameObject> elements5 = new List<GameObject>();
    List<GameObject> elements6 = new List<GameObject>();
    Material material;

    void Start()
    {
        CreatePyramid();
    }

    //public Transform target;
    public float speed = 1;


    public GameObject sphere1;

    public int pos;
    // Update is called once per frame
    void Update()
    {
        //Material matte = GetComponent<Renderer>().material;

        Vector3 target;
        float step = speed * Time.deltaTime;
        for (int i = 0; i < elements.Count; i++)
        {
            Vector3 ls = elements[i].transform.localScale;
            ls.y = Mathf.Lerp(ls.y, 4 + (AudioScript.bands[i] * (scale*2)), Time.deltaTime * 3.0f);
            //Color color = new Color(AudioScript.audioBandBuffer[1], AudioScript.audioBandBuffer[1], AudioScript.audioBandBuffer[1]);
            //matte.SetColor("_EmissionColor", Color.white);
            elements[i].transform.localScale = ls;
            elements[i].transform.RotateAround(elements[i].transform.position, elements[i].transform.up, 50 * Time.deltaTime);

            //Vector3 ls1 = elements1[i].transform.localScale;
            //ls1.z = Mathf.Lerp(ls1.z, 1 + (AudioScript.bands[i] * scale), Time.deltaTime * 3.0f);
            //elements1[i].transform.localScale = ls1;
            //elements1[i].transform.RotateAround(elements[i].transform.position, - elements[i].transform.right, 50 * Time.deltaTime);

            //Vector3 ls3 = elements2[i].transform.localScale;
            //ls3.x = Mathf.Lerp(ls3.x, 1 + (AudioScript.bands[i] * scale), Time.deltaTime * 3.0f);
            //elements2[i].transform.localScale = ls3;
            //elements2[i].transform.RotateAround(elements[i].transform.position, elements[i].transform.right, 50 * Time.deltaTime);

            Vector3 ls2 = elements3[i].transform.localScale;
            ls2.y = Mathf.Lerp(ls2.y, 1 + (AudioScript.bands[i] * (scale *2)), Time.deltaTime * 3.0f);
            elements3[i].transform.localScale = ls2;
            elements3[i].transform.RotateAround(elements[i].transform.position,- elements[i].transform.up, 50 * Time.deltaTime);

            /*
            if (AudioScript.bands[i] * scale > 4)
            {
                //Vector3 target = new Vector3(Random.Range(0, 100.0f), 0, Random.Range(0, 100.0f));
                target = new Vector3(20, 0, 20);
                //Vector3 ls1 = elements1[i].transform.localPosition;
                //ls1 = Vector3.MoveTowards(transform.localPosition, target, step);
                //pos = elements1[i];
            }
            */

        }
        int j = 0;
        for (int i = 0; i < elements4.Count; i++)

        {
            if (j == 9)
            {
                j = 0;
            }
            Vector3 ls = elements4[i].transform.localScale;
            Vector3 ls1 = elements5[i].transform.localScale;
            Vector3 ls2 = elements6[i].transform.localScale;
            //ls.z = Mathf.Lerp(ls.z, 1 + (AudioScript.bands[i] * scale), Time.deltaTime * 3.0f);
            //ls.x = Mathf.Lerp(ls.x, 1 + (AudioScript.bands[i] * scale), Time.deltaTime * 3.0f);
            ls.y = Mathf.Lerp(ls.y, 1 + (AudioScript.bands[j] * 50), Time.deltaTime * 3.0f);
            ls1.z = Mathf.Lerp(ls1.z, 1 + (AudioScript.bands[j] * 30), Time.deltaTime * 4.0f);
            ls2.z = Mathf.Lerp(ls2.z, 1 + (AudioScript.bands[j] * 30), Time.deltaTime * 4.0f);
            elements4[i].transform.localScale = ls;
            elements5[i].transform.localScale = ls1;
            elements6[i].transform.localScale = ls2;
            j++;
        }
        
    }

    public GameObject cube1;
    public int pyraSize = 10;
    public float scale1 = 1;
    public float scale2 = 1;
    public float height = 0;
    public float width = 1;
    public float locationX = 2.25f;
    public float locationZ = 2.5f;
    float test = 0f;

    void CreatePyramid()
    {
        float gradient = 1.2f;
        float theta = (Mathf.PI * 2.0f) / (float)AudioScript.bands.Length;
        // Pyramid of cubes
        for (int z = 0; z < 9; z++)
        {
            //******************************************************************************************* Pyramid of cubes
            GameObject cube = Instantiate(cube1, Vector3.zero, cube1.transform.rotation) as GameObject;
            cube.transform.parent = transform;
            cube.transform.localPosition = new Vector3(2.25f, 1 + height, 2.5f);
            cube.transform.localScale += new Vector3((9 - width) *3, 2, (9 - width) *3);
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                1
                , .01f + gradient
                , .8f
                );
            elements.Add(cube);
            scale2 += .1f;
            scale2 = 1;
            height += .2f;
            width++;

            /*
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
            */
            //******************************************************************************************* Circle of Spheres3
            Vector3 p2 = new Vector3(
                (Mathf.Sin(theta * z) * (radius-1.2f)) + locationX
                , 5f
                , (Mathf.Cos(theta * z) * (radius-1.2f)) + locationZ
                );
            p2 = transform.TransformPoint(p2);
            Quaternion q2 = Quaternion.AngleAxis(theta * z * Mathf.Rad2Deg, Vector3.up);
            q2 = transform.rotation * q2;

            GameObject sphere3 = Instantiate(sphere1, Vector3.zero, sphere1.transform.rotation) as GameObject;
            sphere3.transform.SetPositionAndRotation(p2, q2);
            sphere3.transform.localScale += new Vector3(0, -.5f, 0);
            sphere3.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                1
                , .01f + gradient
                , .8f
                );
            elements3.Add(sphere3);
            gradient -= .15f;
 
        }

        
        // 20 x 20 square of cubes
        for (int x = 0; x < pyraSize; x++)
        {
            for (int z = 0; z < pyraSize; z++)
            {
                GameObject cube = Instantiate(cube1, Vector3.zero, cube1.transform.rotation) as GameObject;
                cube.transform.parent = transform;
                cube.transform.localScale += new Vector3(3, 1, 3);
                cube.transform.localPosition = new Vector3( -3.5f + scale1, -2.2f, -3.25f + scale2);
                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                    1
                    , .01f + test
                    , .8f 
                    );
                elements4.Add(cube);
                scale2 += .5f;
            }
            scale2 = 1;
            scale1 += .5f;

            test += .1f;
        }
        scale1 = 1;
        scale2 = 1;

        //test = .6f;
        // 20 x 20 square of cubes
        for (int x = 0; x < pyraSize; x++)
        {
            for (int z = 0; z < pyraSize; z++)
            {
                GameObject cube = Instantiate(cube1, Vector3.zero, cube1.transform.rotation) as GameObject;
                cube.transform.parent = transform;
                cube.transform.localScale += new Vector3(3, 3, 1);
                cube.transform.localPosition = new Vector3(-3.5f + scale1, -2.75f + scale2, -2.75f);
                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                    1
                    , .01f + test
                    , .8f
                    );
                elements5.Add(cube);

                GameObject cube2 = Instantiate(cube1, Vector3.zero, cube1.transform.rotation) as GameObject;
                cube2.transform.parent = transform;
                cube2.transform.localScale += new Vector3(3, 3, 1);
                cube2.transform.localPosition = new Vector3(-3.5f + scale1, -2.75f + scale2, 7.75f);
                cube2.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                    1
                    , .01f + test
                    , .8f
                    );
                elements6.Add(cube2);
                scale2 += .5f;

            }
            scale2 = 1;
            scale1 += .5f;
            if(test >= 1f)
            {
                test = 0;
            }

            test += .1f;
        }

        //Weird pyramid thing
        /*
        for (int x = 0; x < 8; x++)
        {
            for (int z = 0; z < 8; z++)
            {
                GameObject cube = Instantiate(cube1, Vector3.zero, cube1.transform.rotation) as GameObject;
                cube.transform.parent = transform;
                cube.transform.localPosition = new Vector3(0, 0 + height, 0 + scale2);
                cube.transform.localScale += new Vector3(8 - width, 0, 0);
                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                    z / (float)AudioScript.bands.Length
                    , 1
                    , 1
                    );
                elements.Add(cube);
                scale2 += .1f;
            }
            scale2 = 1;
            height += .1f;
            width++;
        }
        */

    }

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
            /*
            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylinder.transform.SetPositionAndRotation(p, q);
            cube.transform.parent = this.transform;
            cylinder.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                i / (float)AudioScript.bands.Length
                , 1
                , 1
                );
            elements1.Add(cylinder);
            */
        }
    }
}


