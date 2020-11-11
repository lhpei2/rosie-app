using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rosieMainMenuMovement : MonoBehaviour
{
    //Handles animation of Rosie sprite on main menu

    float start_y;
    RectTransform rt;

    void Start()
    {
        //Get initial position as reference
        rt = transform.GetComponent<RectTransform>();
        start_y = rt.anchoredPosition.y;
    }

    void Update()
    {
        //Use sine waves to create hopping motion as well as bobbing back and forth
        Vector2 pos=rt.anchoredPosition;
        float a = 2f;
        pos.y = start_y+a*Mathf.Abs(Mathf.Sin(Time.time*3f));
        rt.anchoredPosition = pos;
        Quaternion rot =  transform.localRotation;
        rot.z = Mathf.Deg2Rad*5f/2*Mathf.Sin(Time.time*3f);
        transform.localRotation = rot;
    }
}
