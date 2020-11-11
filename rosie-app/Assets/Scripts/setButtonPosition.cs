using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setButtonPosition : MonoBehaviour
{
    //Sets the position of the menu and scene action buttons in-game according to the value in settings

    void OnEnable()
    {
        mainController mc = GameObject.Find("Controller").GetComponent<mainController>();
        Vector2 vec = new Vector2(0f, 1f-0.5f*mc.settingsData.buttonPosition);
        Debug.Log(mc.settingsData.buttonPosition);
        vec.x = transform.name == "scenePlayButton" ? 1f : 0f; //Differentiate between x-alignment for play button and menu button

        RectTransform rt = transform.GetComponent<RectTransform>();
        rt.anchorMin = vec;
        rt.anchorMax = vec;
        rt.pivot = new Vector2(0.5f,0.5f);

        Vector2 pos = rt.anchoredPosition;
        pos.y = (mc.settingsData.buttonPosition-1f)*200f;
        rt.anchoredPosition = pos;
    }
}
