using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepSounds : MonoBehaviour
{
    public List<AudioClip> footstep_list = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        footstep_list.Add((AudioClip)Resources.Load("Sounds/leaves02"));
        footstep_list.Add((AudioClip)Resources.Load("Sounds/wood03"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
