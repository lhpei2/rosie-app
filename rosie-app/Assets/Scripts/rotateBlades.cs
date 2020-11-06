using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBlades : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation=Quaternion.Euler(Time.time*10f, 90f, 90f);
    }
}
