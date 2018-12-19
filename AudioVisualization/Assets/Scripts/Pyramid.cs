using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour {

    public float radius = 2;
    public float scale = 10;
    List<GameObject> elements = new List<GameObject>();
    List<GameObject> elements1 = new List<GameObject>();
    List<GameObject> elements3 = new List<GameObject>();
    List<GameObject> elements4 = new List<GameObject>();
    List<GameObject> elements5 = new List<GameObject>();
    List<GameObject> elements6 = new List<GameObject>();
    public GameObject sphere1;
    public float sideScale;
    void Start()
    {
        CreatePyramid();
    }

    // Update is called once per frame
    void Update()
    {
        //For rotating lerping the Spinning Cylinders above the Hour glass.
        for (int i = 0; i < elements.Count / 2; i++)
        {
            Vector3 ls2 = elements3[i].transform.localScale;
            ls2.y = Mathf.Lerp(ls2.y, 1 + (AudioScript.bands[i] * (scale)), Time.deltaTime * 3.0f);
            elements3[i].transform.localScale = ls2;
            elements3[i].transform.RotateAround(elements[i].transform.position, -elements[i].transform.up, 50 * Time.deltaTime);
        }

        int middle = 0;

        //For rotating and lerping the Hour Glass
        for (int i = 0; i < elements.Count; i++)
        {
            if (middle == 9)
            {
                middle = 0;
            }
            Vector3 ls3 = elements[i].transform.localScale;


            if (i > 9 && i < 19)
            {
                //Lerping the 10th to 18th layer of the Hour glass in the opposite direction
                ls3.y = Mathf.Lerp(ls3.y, -(4 + (AudioScript.bands[middle] * (scale))), Time.deltaTime * 3.0f);
                elements[i].transform.localScale = ls3;
                elements[i].transform.RotateAround(elements[i].transform.position, elements[i].transform.up, 50 * Time.deltaTime);
            }
            else
            {
                //Lerping the first 9 layers of the Hour glass in the upwards.
                ls3.y = Mathf.Lerp(ls3.y, 4 + (AudioScript.bands[middle] * (scale)), Time.deltaTime * 3.0f);
                elements[i].transform.localScale = ls3;
                elements[i].transform.RotateAround(elements[i].transform.position, elements[i].transform.up, 50 * Time.deltaTime);
            }
            middle++;
        }



        int j = 0;
        //Updating the floor and both walls of cubes here
        for (int i = 0; i < elements4.Count; i++)
        {
            //resetting j after 9 so you can assign frequency bands to more than 9 components
            if (j == 9)
            {
                j = 0;
            }
            Vector3 ls = elements4[i].transform.localScale;
            Vector3 ls1 = elements5[i].transform.localScale;
            Vector3 ls2 = elements6[i].transform.localScale;

            ls.y = Mathf.Lerp(ls.y, 1 + (AudioScript.bands[j] * (50 * sideScale)), Time.deltaTime * 3.0f);
            ls1.z = Mathf.Lerp(ls1.z, 1 + (AudioScript.bands[j] * (30 * sideScale)), Time.deltaTime * 4.0f);
            ls2.z = Mathf.Lerp(ls2.z, 1 + (AudioScript.bands[j] * (30 * sideScale)), Time.deltaTime * 4.0f);

            elements4[i].transform.localScale = ls;
            elements5[i].transform.localScale = ls1;
            elements6[i].transform.localScale = ls2;
            j++;
        }

    }

    public GameObject cube1;
    public int pyraSize = 20;
    float pos1 = 1;
    float pos2 = 1;
    float height = 0;
    float width = 1;
    readonly float locationX = 2.25f;
    readonly float locationZ = 2.5f;
    int pyraScale = 3;
    float test = 0f;
    

    void CreatePyramid()
    {
        Cylinders();
        Floor();
        Walls();
        HourGlass();
    }

    void Cylinders()
    {
       
            //******************************************************************************************* Creating Spinning Cylinders
            float theta = (Mathf.PI * 2.0f) / (float)AudioScript.bands.Length;
            float gradient = 0f;
            for (int x = 0; x < 9; x++)
            {
                Vector3 p2 = new Vector3(
                (Mathf.Sin(theta * x) * (radius - 1.2f)) + locationX
                , 7f
                , (Mathf.Cos(theta * x) * (radius - 1.2f)) + locationZ
                );
                p2 = transform.TransformPoint(p2);
                Quaternion q2 = Quaternion.AngleAxis(theta * x * Mathf.Rad2Deg, Vector3.up);
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
                gradient += .15f;
            }
        
    }

    void HourGlass()
    {
        float gradient = 0f;
        //Creating Pyramid / Hour Glass of cubes
        for (int z = 0; z < 18; z++)
        {
            //******************************************************************************************* Pyramid of cubes
            GameObject cube = Instantiate(cube1, Vector3.zero, cube1.transform.rotation) as GameObject;
            cube.transform.parent = transform;
            cube.transform.localPosition = new Vector3(2.25f, 1 + height, 2.5f);
            cube.transform.localScale += new Vector3((9 - width) * pyraScale, 2, (9 - width) * pyraScale);
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                1
                , .01f + gradient
                , .6f
                );
            elements.Add(cube);
            height += .2f;
            width++;
            gradient += 0.075f;

        }
    }

    void Floor()
    {
        // 20 x 20 square of cubes
        for (int x = 0; x < pyraSize; x++)
        {
            for (int z = 0; z < pyraSize; z++)
            {
                GameObject cube = Instantiate(cube1, Vector3.zero, cube1.transform.rotation) as GameObject;
                cube.transform.parent = transform;
                cube.transform.localScale += new Vector3(3, 10, 3);
                cube.transform.localPosition = new Vector3(-3.5f + pos1, -2.2f, -3.25f + pos2);
                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                    1
                    , .01f + test
                    , .8f
                    );
                elements4.Add(cube);
                pos2 += .5f;
            }
            pos2 = 1;
            pos1 += .5f;

            test += .1f;
        }
        pos1 = 1;
        pos2 = 1;

        test = .6f;
    }

    void Walls()
    {

        // 20 x 20 square of cubes
        for (int x = 0; x < pyraSize; x++)
        {
            for (int z = 0; z < pyraSize; z++)
            {
                GameObject cube = Instantiate(cube1, Vector3.zero, cube1.transform.rotation) as GameObject;
                cube.transform.parent = transform;
                cube.transform.localScale += new Vector3(3, 3, 1);
                cube.transform.localPosition = new Vector3(-3.5f + pos1, -2.75f + pos2, -2.75f);
                cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                    1
                    , .01f + test
                    , .8f
                    );
                elements5.Add(cube);

                GameObject cube2 = Instantiate(cube1, Vector3.zero, cube1.transform.rotation) as GameObject;
                cube2.transform.parent = transform;
                cube2.transform.localScale += new Vector3(3, 3, 1);
                cube2.transform.localPosition = new Vector3(-3.5f + pos1, -2.75f + pos2, 7.75f);
                cube2.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                    1
                    , .01f + test
                    , .8f
                    );
                elements6.Add(cube2);
                pos2 += .5f;

            }
            pos2 = 1;
            pos1 += .5f;
            if (test >= 1f)
            {
                test = .5f;
            }

            test += .1f;
        }
    }
}


