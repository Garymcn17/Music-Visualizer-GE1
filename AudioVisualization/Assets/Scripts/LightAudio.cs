using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAudio : MonoBehaviour {

    public int _band;
    public float min, max;
    Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        light.intensity = (AudioScript.audioBandBuffer[_band] * (max - min)) + min;
	}
}
