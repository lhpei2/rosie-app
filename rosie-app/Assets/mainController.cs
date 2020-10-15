using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainController : MonoBehaviour
{

    public string current_page;
    public bool page_active = false;
    Sprite play_button, play_button_grey, pause_button, pause_button_grey, replay_button, replay_button_grey;
    Image button;
    GameObject narration_bank;
    float flicker_time=0f;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("scenePlayButton").GetComponent<Image>();
        play_button = Resources.Load<Sprite>("UI/button_play");
        play_button_grey = Resources.Load<Sprite>("UI/button_play_grey");
        pause_button = Resources.Load<Sprite>("UI/button_pause");
        pause_button_grey = Resources.Load<Sprite>("UI/button_pause_grey");
        replay_button = Resources.Load<Sprite>("UI/button_replay");
        replay_button_grey = Resources.Load<Sprite>("UI/button_replay_grey");
        current_page = "";
        narration_bank=GameObject.Find("Narration");
    }

    // Update is called once per frame
    void Update()
    {   
        flicker_time=page_active? 0f : flicker_time+Time.deltaTime;
        GameObject.Find("focusOnPage").GetComponent<Image>().enabled=Mathf.Sin(flicker_time*5f)<0f;

        movementRosie rosie = GameObject.Find(current_page).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<movementRosie>();
        if (rosie.paused)
        {
            button.sprite = page_active ? play_button : play_button_grey;
        }
        else
        {
            if (rosie.path_ended)
            {
                button.sprite = page_active ? replay_button : replay_button_grey;
            }
            else
            {
                button.sprite = page_active ? pause_button : pause_button_grey;
            }
        }
    }

    public void ButtonPressed() 
    {
        movementRosie rosie = GameObject.Find(current_page).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<movementRosie>();
        if (page_active) 
        {
            if (rosie.paused)
            {
                if (rosie.dist==0)
                {
                    playNarration();
                }
                rosie.paused = false;
            }
            else
            {
                if (rosie.path_ended)
                {
                    playNarration();
                    rosie.dist = 0;
                    rosie.path_ended = false;
                }   
                else
                {
                     rosie.paused = true;
                }
            }
        }
    }

    void playNarration()
    {
        int narration_num=-1;

        switch(current_page) 
        {
            case "scene0":
                narration_num=0;
                break;
            
            case "scene1":
                narration_num=1;
                break;

            case "scene2":
                narration_num=2;
                break;

            case "scene3":
                narration_num=3;
                break;

            case "scene4":
                narration_num=4;
                break;

            case "scene5":
                narration_num=5;
                break;

            case "scene6":
                narration_num=6;
                break;

            case "scene7":
                narration_num=7;
                break;
        }

        if (narration_num>-1)
        {
            narration_bank.GetComponent<AudioSource>().clip=narration_bank.GetComponent<Narration>().narration_list[narration_num];
            narration_bank.GetComponent<AudioSource>().Play();
        }
    }
}
