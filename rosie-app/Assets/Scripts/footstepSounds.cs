using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepSounds : MonoBehaviour
{
    //Stores list of Rosie's footstep sounds

    public List<AudioClip> footstep_list = new List<AudioClip>();

    void Start()
    {
        footstep_list.Add((AudioClip)Resources.Load("Sounds/Footsteps/leaves02"));
        footstep_list.Add((AudioClip)Resources.Load("Sounds/Footsteps/wood03"));
    }
}
