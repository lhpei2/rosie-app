using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlRosie : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetSphere;
    public GameObject imageTarget;
    public GameObject rosie;
    public GameObject ground;
    
    Collider coll;

    void Start()
    {
        coll=ground.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
