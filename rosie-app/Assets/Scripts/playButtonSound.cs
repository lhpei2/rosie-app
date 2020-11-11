using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButtonSound : MonoBehaviour
{
    //Handles playing a sound when a button is pressed

    public AudioClip audioClip;
    float init_vol = 1f;
    AudioSource audioSource;
    mainController mc;

    void Start()
    {
        mc = GameObject.Find("Controller").GetComponent<mainController>();
        audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    public void playSound()
    {
        audioSource.PlayOneShot(audioClip, 1f);
    }
}
