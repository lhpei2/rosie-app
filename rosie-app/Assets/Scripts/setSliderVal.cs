using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setSliderVal : MonoBehaviour
{
    //Sets the slider values in settings menu according to the values saved

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
}
