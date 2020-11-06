using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupElastic : MonoBehaviour
{
    bool popped=false;
    float ease_val=0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.parent.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<movementRosie>().allowed_to_move)
        {
            ease_val+=Time.deltaTime/2f;
            Vector3 scl=transform.localScale;
            scl.y=EaseOutElastic(0f,1f,ease_val);
            transform.localScale=scl;
        }
        else
        {
            ease_val=0f;
        }
    }

    float EaseOutElastic(float start, float end, float value)
    {
        end -= start;

        float d = 1f;
        float p = d * .3f;
        float s;
        float a = 0;

        if (value == 0) return start;

        if ((value /= d) == 1) return start + end;

        if (a == 0f || a < Mathf.Abs(end))
        {
            a = end;
            s = p * 0.25f;
        }
        else
        {
            s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
        }

        return (a * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + end + start);
    }
}
