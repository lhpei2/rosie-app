using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseWiggle : MonoBehaviour
{
    //Animation for the mice in the "over the haystack" scene

    void Update()
    {
        //Rotate side to side using sine wave

        Quaternion rot = transform.localRotation;
        rot.z = 0.05f*Mathf.Sin(Time.time*2f);
        transform.localRotation = rot;
    }
}
