using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchMaterial : MonoBehaviour
{
    int material=0;
    Renderer rend;

    // Update is called once per frame

    void Start() 
    {
        rend = GetComponent<Renderer>();
        rend.receiveShadows=false;
        rend.material.SetInt("_useColour",0);
        rend.material.SetInt("_useNormals",0);
    }

    void Update()
    {

    }
}
