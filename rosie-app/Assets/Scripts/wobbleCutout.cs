using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wobbleCutout : MonoBehaviour
{
    //Handles the ebbing and flowing animation for the ground plane in each scene by varying the alpha cutoff

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        rend.material.SetFloat("_Cutoff", 0.5f+0.1f*Mathf.Sin(Time.time*2f));
    }
}
