using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setButtonVal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        mainController mc = GameObject.Find("Controller").GetComponent<mainController>();
        transform.GetComponent<Dropdown>().value = mc.settingsData.buttonPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
