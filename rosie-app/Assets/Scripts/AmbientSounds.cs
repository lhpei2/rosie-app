using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    //Stores list of ambient sounds for each scene

    public List<AudioClip> ambience_list = new List<AudioClip>();

    void Start()
    {
        ambience_list.Add((AudioClip)Resources.Load("Sounds/Ambient/bees_buzzing"));
        ambience_list.Add((AudioClip)Resources.Load("Sounds/Ambient/windy_creak"));
        ambience_list.Add((AudioClip)Resources.Load("Sounds/Ambient/goat_mouse"));
        ambience_list.Add((AudioClip)Resources.Load("Sounds/Ambient/pond_sounds"));
    }
}
