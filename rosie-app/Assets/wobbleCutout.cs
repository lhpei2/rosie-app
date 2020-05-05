using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wobbleCutout : MonoBehaviour
{
    // Start is called before the first frame update
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.SetFloat("_Cutoff", 0.5f+0.1f*Mathf.Sin(Time.time*2f));
    }
}
