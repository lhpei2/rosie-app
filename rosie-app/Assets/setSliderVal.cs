using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setSliderVal : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        mainController mc = GameObject.Find("Controller").GetComponent<mainController>();
        
        float val = 1f;
        switch(transform.name)
        {
            case "musicVolumeSlider":
                val = mc.settingsData.musicSliderVal;
                break;

            case "SFXVolumeSlider":
                val = mc.settingsData.SFXSliderVal;
                break;

            case "narrationVolumeSlider":
                val = mc.settingsData.narrationSliderVal;
                break;
        }
        
        transform.GetComponent<Slider>().value = val;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
