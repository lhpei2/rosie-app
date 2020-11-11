using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class blobAnimation : MonoBehaviour
{
    //Animation for AR markers

    void Update()
    {
        //Scale up and down using sine wave
        Vector3 scl = transform.localScale;
        scl.x = 0.1f+0.005f*Mathf.Sin(Time.time*2f);
        scl.y = scl.x;
        transform.localScale = scl;

        //Rotate side to side using sine wave
        Quaternion rot = transform.localRotation;
        rot.z = 0.05f*Mathf.Sin(Time.time*2f);
        transform.localRotation = rot;
    }
}
