using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollBackground : MonoBehaviour
{
    //Handles scrolling background on main menu

    public float speed;

    void Update()
    {
        //Scrolling UVs such that the image loops seamlessly
        transform.GetComponent<RawImage>().uvRect = new Rect(speed*Time.time/100f, 0f, 1f, 1f);
    }
}
