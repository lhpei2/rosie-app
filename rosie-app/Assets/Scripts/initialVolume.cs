using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialVolume : MonoBehaviour
{
    public float init_volume;
    // Start is called before the first frame update
    void Awake()
    {
        init_volume = transform.GetComponent<AudioSource>().volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
