﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration : MonoBehaviour
{

     public List<AudioClip> narration_list = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        narration_list.Add((AudioClip)Resources.Load("Sounds/Narration/walk"));
        narration_list.Add((AudioClip)Resources.Load("Sounds/Narration/across"));
        narration_list.Add((AudioClip)Resources.Load("Sounds/Narration/around"));
        narration_list.Add((AudioClip)Resources.Load("Sounds/Narration/over"));
        narration_list.Add((AudioClip)Resources.Load("Sounds/Narration/past"));
        narration_list.Add((AudioClip)Resources.Load("Sounds/Narration/through"));
        narration_list.Add((AudioClip)Resources.Load("Sounds/Narration/under"));
        narration_list.Add((AudioClip)Resources.Load("Sounds/Narration/dinner"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}