using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    public List<AudioClip> ambience_list = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        ambience_list.Add((AudioClip)Resources.Load("Sounds/bees_buzzing"));
        ambience_list.Add((AudioClip)Resources.Load("Sounds/windy_creak"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
