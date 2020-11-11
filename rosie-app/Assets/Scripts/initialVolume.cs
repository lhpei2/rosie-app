using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialVolume : MonoBehaviour
{
    //Records initial volume for audio sources

    public float init_volume;

    void Awake()
    {
        init_volume = transform.GetComponent<AudioSource>().volume;
    }
}
