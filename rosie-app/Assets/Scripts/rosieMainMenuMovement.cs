using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rosieMainMenuMovement : MonoBehaviour
{
    float start_y;
    RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = transform.GetComponent<RectTransform>();
        start_y = rt.anchoredPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos=rt.anchoredPosition;
        float a = 2f;
        pos.y = start_y+a*Mathf.Abs(Mathf.Sin(Time.time*3f));
        rt.anchoredPosition = pos;
        Quaternion rot =  transform.localRotation;
        rot.z = Mathf.Deg2Rad*5f/2*Mathf.Sin(Time.time*3f);
        transform.localRotation = rot;
    }
}
