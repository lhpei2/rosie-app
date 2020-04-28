using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementRosie : MonoBehaviour
{
    float start_y;
    // Start is called before the first frame update
    void Start()
    {
        start_y=transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = transform.localRotation;
        rot.z=Mathf.Deg2Rad*10f/2*Mathf.Sin(Time.time*3f);
        transform.localRotation=rot;

        Vector3 pos = transform.localPosition;
        float a=0.005f;
        pos.y = start_y+a*Mathf.Abs(Mathf.Sin(Time.time*3f));
        transform.localPosition=pos;
    }
}
