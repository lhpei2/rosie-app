using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementFox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = transform.localRotation;
        rot.y=Mathf.Deg2Rad*5f/2*Mathf.Sin(Time.time*5f);
        transform.localRotation=rot;
    }
}
