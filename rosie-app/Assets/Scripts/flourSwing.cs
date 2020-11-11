using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flourSwing : MonoBehaviour
{
    //Animation for flour bag in "past the mill" scene

    void Update()
    {
        //Swing side to side using sine wave
        Quaternion rot = transform.localRotation;
        rot.z = 0.04f*Mathf.Sin(Time.time);
        transform.localRotation = rot;
    }
}
