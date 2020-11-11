using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementFox : MonoBehaviour
{
    //Animation for the fox

    float initial_rot;

    void Start()
    {
        //Set reference rotation
        initial_rot=transform.localRotation.y;
    }

    void Update()
    {
        //Rotate back and forth centred at reference rotation
        
        Quaternion rot = transform.localRotation;
        rot.y=initial_rot+Mathf.Deg2Rad*5f/2*Mathf.Sin(Time.time*5f);
        transform.localRotation=rot;
    }
}
