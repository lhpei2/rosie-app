using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBackface : MonoBehaviour
{
    GameObject backface;
    // Start is called before the first frame update
    void Start()
    {
        backface=Instantiate(Resources.Load("Backface", typeof(GameObject))) as GameObject;
        backface.GetComponent<Renderer>().material=GetComponent<Renderer>().material;
        backface.transform.parent=transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        backface.transform.localPosition=transform.localPosition;
        backface.transform.localRotation=transform.localRotation;
        Vector3 scl=transform.localScale;
        scl.z*=-1;
        backface.transform.localScale=scl;
    }
}
