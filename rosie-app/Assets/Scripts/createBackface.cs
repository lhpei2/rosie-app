using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBackface : MonoBehaviour
{
    //Creates artificial backface

    GameObject backface;

    void Start()
    {
        //Creates backface object and sets it material and parent to current object's material and parent
        backface=Instantiate(Resources.Load("Backface", typeof(GameObject))) as GameObject;
        backface.GetComponent<Renderer>().material=GetComponent<Renderer>().material;
        backface.transform.parent=transform.parent;
    }

    void Update()
    {
        //Update backface scale/rotation/position properties to match current object's properties
        backface.transform.localPosition=transform.localPosition;
        backface.transform.localRotation=transform.localRotation;
        Vector3 scl=transform.localScale;
        scl.z*=-1;
        backface.transform.localScale=scl;
    }
}
