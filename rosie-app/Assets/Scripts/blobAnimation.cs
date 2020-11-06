using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scl = transform.localScale;
        scl.x = 0.1f+0.005f*Mathf.Sin(Time.time*2f);
        scl.y = scl.x;
        transform.localScale = scl;

        Quaternion rot = transform.localRotation;
        rot.z = 0.05f*Mathf.Sin(Time.time*2f);
        transform.localRotation = rot;
    }
}
