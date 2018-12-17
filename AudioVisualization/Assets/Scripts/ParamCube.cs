using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {

    public int band;
    public float startScale, scaleMultiplier;
    public bool useBuffer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    /*
	void Update () {
        if(useBuffer == true)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioScript.bandBuffer[band] * scaleMultiplier) + startScale, transform.localScale.z);
        }

        if (useBuffer == false)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioScript.freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
        }

    }
    */
}
