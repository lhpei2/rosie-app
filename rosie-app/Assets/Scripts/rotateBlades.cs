using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBlades : MonoBehaviour
{
    //Animation for windmill blades in "past the mill" scene

    void Update()
    {
        //Rotate blades indefinitely
        transform.localRotation=Quaternion.Euler(Time.time*10f, 90f, 90f);
    }
}
