using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class reversePath : MonoBehaviour
{

    public PathCreator path;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] points_list = new Vector3[20];
        for(int i = 20; i>0; i--) {
           points_list[20-i] = path.path.GetPointAtTime(i/20f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
