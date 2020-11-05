using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseWiggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = transform.localRotation;
        rot.z = 0.05f*Mathf.Sin(Time.time*2f);
        transform.localRotation = rot;
    }
}
