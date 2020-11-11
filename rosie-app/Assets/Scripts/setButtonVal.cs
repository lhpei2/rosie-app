using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setButtonVal : MonoBehaviour
{
    //Sets the value of the button position setting to the value in settings upon initialization

    void Start()
    {
        mainController mc = GameObject.Find("Controller").GetComponent<mainController>();
        transform.GetComponent<Dropdown>().value = mc.settingsData.buttonPosition;
    }
}
