using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setButtonPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        mainController mc = GameObject.Find("Controller").GetComponent<mainController>();
        Vector2 vec = new Vector2(0f, 1f-0.5f*mc.settingsData.buttonPosition);
        Debug.Log(mc.settingsData.buttonPosition);
        vec.x = transform.name == "scenePlayButton" ? 1f : 0f;

        RectTransform rt = transform.GetComponent<RectTransform>();
        rt.anchorMin = vec;
        rt.anchorMax = vec;
        rt.pivot = new Vector2(0.5f,0.5f);

        Vector2 pos = rt.anchoredPosition;
        pos.y = (mc.settingsData.buttonPosition-1f)*200f;
        rt.anchoredPosition = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
