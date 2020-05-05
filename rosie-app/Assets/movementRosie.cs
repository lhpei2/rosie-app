using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementRosie : MonoBehaviour
{
    public Vector3 targetPosition;
    float start_y;
    float moveSpd=0.02f;
    float ang_y=0f;
    float temp_ang=0f;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition=transform.localPosition;
        start_y=transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.localPosition;
        if (pos.x!=targetPosition.x)
        {
            ang_y=(targetPosition.x-pos.x)>0? 0f: 180f; 
        }
        temp_ang=Mathf.Lerp(temp_ang,ang_y,Mathf.Clamp(Time.deltaTime*5f,0,1));
        transform.localRotation=Quaternion.Euler(0f, temp_ang, 10f/2*Mathf.Sin(Time.time*3f));
        
        float a=0.005f;
        pos.y = start_y+a*Mathf.Abs(Mathf.Sin(Time.time*3f));
        
        float spd=Time.deltaTime*moveSpd;

        if (Vector2.Distance(new Vector2(pos.x,pos.z),new Vector2(targetPosition.x,targetPosition.z))<spd)
        {
            pos.x=targetPosition.x;
            pos.z=targetPosition.z;
        }
        else
        {
            float ang=Mathf.Atan2(targetPosition.z-pos.z,targetPosition.x-pos.x);
            pos.x+=spd*Mathf.Cos(ang);
            pos.z+=spd*Mathf.Sin(ang);
        }

        transform.localPosition=pos;
        
    }
}
