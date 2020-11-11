using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class mainController : MonoBehaviour
{

    public string current_page;
    public bool page_active = false;
    Sprite play_button, play_button_grey, pause_button, pause_button_grey, replay_button, replay_button_grey;
    Image button;
    GameObject narration_bank, ar_camera, main_camera, scene_parent, main_menu_parent, info_popup, settings_popup;
    float flicker_time=0f;
    bool in_main_menu=true;
    bool popup_open=false;
    public SettingsData settingsData;

    //Read existing settings file if one exists, else use default settings

    private void Awake() {
       if (File.Exists(Application.persistentDataPath+"/saveData.json"))
        {
            string saveString = File.ReadAllText(Application.persistentDataPath+"/saveData.json");
            settingsData = JsonUtility.FromJson<SettingsData>(saveString);
        }
        else
        {
            settingsData = new SettingsData 
            {
                musicSliderVal = 1f,
                SFXSliderVal = 1f,
                narrationSliderVal = 1f,
                buttonPosition = 0
            };
        } 
    }

    void Start()
    {
        //Getting references to all necessary objects as they will be enabled/disabled dynamically

        play_button = Resources.Load<Sprite>("UI/button_play");
        play_button_grey = Resources.Load<Sprite>("UI/button_play_grey");
        pause_button = Resources.Load<Sprite>("UI/button_pause");
        pause_button_grey = Resources.Load<Sprite>("UI/button_pause_grey");
        replay_button = Resources.Load<Sprite>("UI/button_replay");
        replay_button_grey = Resources.Load<Sprite>("UI/button_replay_grey");

        button = GameObject.Find("scenePlayButton").GetComponent<Image>();

        scene_parent = GameObject.Find("CanvasScene");
        scene_parent.SetActive(false);

        main_menu_parent = GameObject.Find("CanvasMainMenu");
        main_camera = GameObject.Find("Main Camera");

        ar_camera = GameObject.Find("ARCamera");
        ar_camera.SetActive(false);

        info_popup = GameObject.Find("informationPopup");
        info_popup.gameObject.SetActive(false);

        settings_popup = GameObject.Find("settingsPopup");
        settings_popup.gameObject.SetActive(false);
        
        current_page = "";
        narration_bank=GameObject.Find("Narration");

        //Setting audio volume values according to settings

        _setMusicVolume(settingsData.musicSliderVal);
        _setSFXVolume(settingsData.SFXSliderVal);
        _setNarrationVolume(settingsData.narrationSliderVal);
    }

    void Update()
    {
        if (!in_main_menu)
        {   
            //Display flickering page icon if not in the menu and a page is not found

            flicker_time=page_active? 0f : flicker_time+Time.deltaTime;
            GameObject.Find("focusOnPage").GetComponent<Image>().enabled=Mathf.Sin(flicker_time*5f)<0f;

            if (current_page!="")
            {
                //If on a page, set the scene action button icon depending on where Rosie is along the path, and grey out the icon if the page is not in view

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
        }
    }

    public void ButtonPressed() 
    {
        //When the action button scene is pressed, pause, play or reset Rosie according to where she is along the path        

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

    public void openMainMenu()
    {
        //Turns off AR camera and turns on main camera in preparation to display main menu elements when menu button is pressed

        in_main_menu=true;
        main_menu_parent.SetActive(true);
        scene_parent.SetActive(false);
        ar_camera.SetActive(false);
        main_camera.SetActive(true);
        current_page="";
    }

    public void closeMainMenu()
    {   
        //If play pressed, turn off main camera and turn on AR camera and hide main menu elements

        if (!popup_open)
        {
            in_main_menu=false;
            main_menu_parent.SetActive(false);
            scene_parent.SetActive(true);
            ar_camera.SetActive(true);
            main_camera.SetActive(false);
        }
    }

    public void openInfoPopup()
    {
        if (!popup_open)
        {
            info_popup.gameObject.SetActive(true);
            popup_open=true;
        }
    }

    public void closeInfoPopup()
    {
        info_popup.gameObject.SetActive(false);
        popup_open=false;
    }

    public void openSettingsPopup()
    {
        if (!popup_open)
        {
            settings_popup.gameObject.SetActive(true);
            popup_open=true;
        }
    }

    public void closeSettingsPopup()
    {
        settings_popup.gameObject.SetActive(false);
        string json = JsonUtility.ToJson(settingsData);
        File.WriteAllText(Application.persistentDataPath+"/saveData.json", json);
        popup_open=false;
    }

    public void setButtonPosition()
    {
        int val = GameObject.Find("ButtonPositionDropdown").GetComponent<Dropdown>().value;
        Debug.Log(val);
        settingsData.buttonPosition = val;
    }

    public void setMusicVolume()
    {
        float slider_val = GameObject.Find("musicVolumeSlider").GetComponent<Slider>().value;
        settingsData.musicSliderVal = slider_val;
        _setMusicVolume(slider_val);
    }

    private void _setMusicVolume(float val)
    {
        GameObject go = GameObject.Find("Music");
        float init_volume = go.GetComponent<initialVolume>().init_volume;
        go.GetComponent<AudioSource>().volume = init_volume*val;
    }

    public void setSFXVolume()
    {
        float slider_val = GameObject.Find("SFXVolumeSlider").GetComponent<Slider>().value;
        settingsData.SFXSliderVal = slider_val;
        _setSFXVolume(slider_val);
    }

    private void _setSFXVolume(float val)
    {
        GameObject go = GameObject.Find("SoundBank");
        float init_volume = go.GetComponent<initialVolume>().init_volume;
        go.GetComponent<AudioSource>().volume = init_volume*val;

        go = GameObject.Find("Ambience");
        init_volume = go.GetComponent<initialVolume>().init_volume;
        go.GetComponent<AudioSource>().volume = init_volume*val;

        go = GameObject.Find("SFX");
        init_volume = go.GetComponent<initialVolume>().init_volume;
        go.GetComponent<AudioSource>().volume = init_volume*val;
    }

    public void setNarrationVolume()
    {
        float slider_val = GameObject.Find("narrationVolumeSlider").GetComponent<Slider>().value;
        settingsData.narrationSliderVal = slider_val;
        _setNarrationVolume(slider_val);
    }

    private void _setNarrationVolume(float val)
    {
        float init_volume = narration_bank.GetComponent<initialVolume>().init_volume;
        narration_bank.GetComponent<AudioSource>().volume = init_volume*val;
    }

    void playNarration()
    {
        int narration_num=-1;

        //Pick correct narration track for scene

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

        //Play narration for scene

        if (narration_num>-1)
        {
            narration_bank.GetComponent<AudioSource>().clip=narration_bank.GetComponent<Narration>().narration_list[narration_num];
            narration_bank.GetComponent<AudioSource>().Play();
        }
    }
}

[System.Serializable]
public class SettingsData
{
    public float musicSliderVal;
    public float SFXSliderVal;
    public float narrationSliderVal;
    public int buttonPosition;
}
