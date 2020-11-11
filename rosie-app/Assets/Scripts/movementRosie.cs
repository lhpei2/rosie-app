using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class movementRosie : MonoBehaviour
{
    //Handles Rosie movement and animation across all scenes

    public PathCreator path;
    float start_y;
    float moveSpd=0.02f;
    public float dist=0f;
    float ang_y=0f;
    float horz_ang=0f;
    float vert_ang=0f;
    public bool allowed_to_move=false;
    public bool paused=true;
    public bool path_ended=false;
    float time_since_footstep=1f;
    GameObject sound_bank;
    int terrain_type;

    void Start()
    {
        //Setting initial position to correct spot and save reference position for use in animation
        Vector3 path_pos=path.path.GetPointAtDistance(0f, EndOfPathInstruction.Loop);
        path_pos=transform.parent.transform.InverseTransformPoint(path_pos);
        path_pos.y+=0.015f;
        transform.localPosition=path_pos;
        start_y=transform.localPosition.y;
        sound_bank=GameObject.Find("SoundBank");
    }

    void Update()
    {
        //Use delta time to scale movement such that it is independent of frame rate
        
        float spd=Time.deltaTime*moveSpd;

        if (allowed_to_move && !paused)
        {
            dist += spd;
        }

        //Get path position on two positions along path which will be used to calculate Rosie's direction

        Vector3 path_pos=path.path.GetPointAtDistance(dist/path.transform.localScale.x, EndOfPathInstruction.Stop);
        Vector3 path_pos2=path.path.GetPointAtDistance((dist+0.01f)/path.transform.localScale.x, EndOfPathInstruction.Stop);
        path_pos=transform.parent.transform.InverseTransformPoint(path_pos);
        path_pos2=transform.parent.transform.InverseTransformPoint(path_pos2);

        //Calculating vertical angle for Rosie based on path
        Vector3 temp_pos=path_pos2-path_pos;
        float temp_y=temp_pos.y;
        temp_pos.y=0f;
        float path_ang=Mathf.Atan2(-temp_pos.z, temp_pos.x) * Mathf.Rad2Deg;
        if (dist/path.transform.localScale.x<path.path.length)
        {
            horz_ang=path_ang;
            vert_ang=Mathf.Atan2(temp_y,temp_pos.magnitude) * Mathf.Rad2Deg;
        }
        else
        {
            path_ended=true;
        }
      
        //Rotate Rosie taking into account both pitch and yaw
        transform.localRotation=Quaternion.Euler(0f,horz_ang, vert_ang+10f/2*Mathf.Sin(Time.time*3f));

        //Add hopping animation on top of world position
        float a=0.005f;
        path_pos.y+=start_y+a*Mathf.Abs(Mathf.Sin(Time.time*3f));
        time_since_footstep+=Time.deltaTime;

        float dist_travelled=path.path.GetTimeAtDistance(dist/path.transform.localScale.x, EndOfPathInstruction.Stop);
        string scene=GameObject.Find("Controller").GetComponent<mainController>().current_page;

        //Getting correct footstep sound for each scene depending on distance along path

        switch(scene) 
        {
            case "scene0":
                if (dist_travelled<0.6) {terrain_type=1;}
                else {terrain_type=0;}
                break;
            
            case "scene1":
                terrain_type=0;
                break;

            case "scene2":
                terrain_type=0;
                break;

            case "scene3":
                terrain_type=0;
                break;

            case "scene4":
                terrain_type=0;
                break;

            case "scene5":
                terrain_type=0;
                break;

            case "scene6":
                terrain_type=0;
                break;

            case "scene7":
                if (dist_travelled<0.1) {terrain_type=0;}
                else {terrain_type=1;}
                break;
        }

        //Play footstep sounds when landing on ground each hop while walking (but not while stationary)
        if (allowed_to_move && !paused && !path_ended && time_since_footstep>0.5f && Mathf.Abs(Mathf.Sin(Time.time*3f))<0.1)
        {
            time_since_footstep=0f;
            if (terrain_type>-1)
            {
                sound_bank.GetComponent<AudioSource>().clip=sound_bank.GetComponent<footstepSounds>().footstep_list[terrain_type];
                sound_bank.GetComponent<AudioSource>().pitch=Random.Range(0.8f,1.2f);
                sound_bank.GetComponent<AudioSource>().Play();
            }
        }

        //Update final Rosie position
        transform.localPosition=path_pos;
    }
}
