using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchMaterial : MonoBehaviour
{
    //Switches between different materials for the pond in the "around the pond" scene, used during development for testing

    int material=0;
    Renderer rend;

    void Start() 
    {
        rend = GetComponent<Renderer>();
        rend.receiveShadows=false;
        rend.material.SetInt("_useColour",0);
        rend.material.SetInt("_useNormals",0);
    }
}
