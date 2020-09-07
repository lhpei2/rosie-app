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
    float horz_ang=0f;
    float vert_ang=0f;
    public bool allowed_to_move=false;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 path_pos=path.path.GetPointAtDistance(0f, EndOfPathInstruction.Loop);
        path_pos=transform.parent.transform.InverseTransformPoint(path_pos);
        path_pos.y+=0.015f;
        transform.localPosition=path_pos;
        start_y=transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        float spd=Time.deltaTime*moveSpd;
        if (allowed_to_move)
        {
            if (Input.touchCount==2)
            {
                dist=0;      
            }
            else if (Input.touchCount==1)
            {
                dist+=spd;
            }
        }

        //Vector3 path_pos=path.path.GetPointAtDistance(dist, EndOfPathInstruction.Stop);
        //Vector3 path_pos2=path.path.GetPointAtDistance((dist+0.01f), EndOfPathInstruction.Stop);
        Vector3 path_pos=path.path.GetPointAtDistance(dist/path.transform.localScale.x, EndOfPathInstruction.Stop);
        Vector3 path_pos2=path.path.GetPointAtDistance((dist+0.01f)/path.transform.localScale.x, EndOfPathInstruction.Stop);
        path_pos=transform.parent.transform.InverseTransformPoint(path_pos);
        path_pos2=transform.parent.transform.InverseTransformPoint(path_pos2);

        

        Vector3 temp_pos=path_pos2-path_pos;
        float temp_y=temp_pos.y;
        temp_pos.y=0f;
        float path_ang=Mathf.Atan2(-temp_pos.z, temp_pos.x) * Mathf.Rad2Deg;
        if (dist/path.transform.localScale.x<path.path.length)
        {
            horz_ang=path_ang;
            vert_ang=Mathf.Atan2(temp_y,temp_pos.magnitude) * Mathf.Rad2Deg;
        }
      
        transform.localRotation=Quaternion.Euler(0f,horz_ang, vert_ang+10f/2*Mathf.Sin(Time.time*3f));
        
        if (allowed_to_move && Input.touchCount==1)
        {
            Debug.Log(dist+" "+path_pos*1000);
        }

        float a=0.005f;
        path_pos.y+=start_y+a*Mathf.Abs(Mathf.Sin(Time.time*3f));
        transform.localPosition=path_pos;
    }
}
