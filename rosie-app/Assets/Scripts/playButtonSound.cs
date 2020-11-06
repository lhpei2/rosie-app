using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButtonSound : MonoBehaviour
{
    public AudioClip audioClip;
    float init_vol = 1f;
    AudioSource audioSource;
    mainController mc;
    // Start is called before the first frame update
    void Start()
    {
        mc = GameObject.Find("Controller").GetComponent<mainController>();
        audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    public void playSound()
    {
        Debug.Log("QWEG");
        audioSource.PlayOneShot(audioClip, 1f);
    }
}
