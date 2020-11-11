using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTree : MonoBehaviour
{
    //Swaying animation for trees across all scenes

    float offset;

    void Start()
    {
        //Adding randomness to animation such that trees aren't synced in movement, and look more natural
        offset=Random.Range(0f, 6f);
    }

    void Update()
    {
        //Swaying using sine wave
        Quaternion rot = transform.localRotation;
        rot.z=Mathf.Deg2Rad*2f/2*Mathf.Sin(Time.time+offset);
        transform.localRotation=rot;
    }
}
