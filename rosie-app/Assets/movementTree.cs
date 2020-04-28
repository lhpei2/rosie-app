using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTree : MonoBehaviour
{
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset=Random.Range(0f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = transform.localRotation;
        rot.z=Mathf.Deg2Rad*2f/2*Mathf.Sin(Time.time+offset);
        transform.localRotation=rot;
    }
}
