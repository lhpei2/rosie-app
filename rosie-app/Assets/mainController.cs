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
    }

    // Update is called once per frame
    void Update()
    {   
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
                rosie.paused = false;
            }
            else
            {
                if (rosie.path_ended)
                {
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
}
