using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class movementRosie : MonoBehaviour
{
    public PathCreator path;
    float start_y;
    float moveSpd=0.02f;
    float dist=0f;
    float ang_y=0f;
    float temp_ang=0f;
    public bool allowed_to_move=false;

    // Start is called before the first frame update
    void Start()
    {
        start_y=transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.localPosition;
        temp_ang=Mathf.Lerp(temp_ang,ang_y,Mathf.Clamp(Time.deltaTime*5f,0,1));
        transform.localRotation=Quaternion.Euler(0f, temp_ang, 10f/2*Mathf.Sin(Time.time*3f));
        
        float a=0.005f;
        pos.y = start_y+a*Mathf.Abs(Mathf.Sin(Time.time*3f));
        
        //Debug.Log();
        if (allowed_to_move)
        {
            if (Input.touchCount==2)
            {
                dist=0;      
            }
            else if (Input.touchCount==1)
            {
                float spd=Time.deltaTime*moveSpd;
                dist+=spd;
            }
        }

        Vector3 path_pos=path.path.GetPointAtDistance(dist, EndOfPathInstruction.Stop);
        path_pos=transform.parent.transform.InverseTransformPoint(path_pos);
        pos.x=path_pos.x;
        pos.z=path_pos.z;

        transform.localPosition=pos;
    }
}
