using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoController : MonoBehaviour
{
    //Controls content in information popup

    GameObject text1, text2, text3, text4;
    Text button1, button2, button3;
    string[] button_text_list = {"About","How to Play","Parental Info","Spatial Skills"};
    string[] header_text_list = {"About Rosie","How to Play","Parental Information","Encouraging Spatial Skills"};
    Text header_text;
    List<GameObject> body_text_list = new List<GameObject>();
    List<Text> button_list = new List<Text>();
    int[] button_order = {1, 2 ,3};
    int current_text = 0;

    void Start()
    {
        //Set up data structures with elements inside info popup
        
        button1 = GameObject.Find("infoButtonText1").GetComponent<Text>();
        button2 = GameObject.Find("infoButtonText2").GetComponent<Text>();
        button3 = GameObject.Find("infoButtonText3").GetComponent<Text>();
        text1 = GameObject.Find("bodyText1");
        text2 = GameObject.Find("bodyText2");
        text3 = GameObject.Find("bodyText3");
        text4 = GameObject.Find("bodyText4");

        header_text = GameObject.Find("infoHeading").GetComponent<Text>();

        body_text_list.Add(text1);
        body_text_list.Add(text2);
        body_text_list.Add(text3);
        body_text_list.Add(text4);

        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);

        button_list.Add(button1);
        button_list.Add(button2);
        button_list.Add(button3);

        button1.text = button_text_list[button_order[0]];
        button2.text = button_text_list[button_order[1]];
        button3.text = button_text_list[button_order[2]];
    }

    public void buttonPressed1()
    {
        switchText(0);
    }

    public void buttonPressed2()
    {
        switchText(1);
    }

    public void buttonPressed3()
    {
        switchText(2);
    }

    void switchText(int num)
    {
        

        int button_num = button_order[num]; //Get the info tab
        button_order[num] = current_text; //Swap the button text

        //Hiding and revealing the corresponding body text objects
        GameObject current_obj = body_text_list[current_text]; 
        GameObject  next_obj = body_text_list[button_num];
        current_obj.SetActive(false);
        next_obj.SetActive(true);

        //Sets header text according to given button index
        Text temp = button_list[num];
        temp.text = button_text_list[current_text];
        button_list[num] = temp;
        current_text = button_num;
        header_text.text = header_text_list[button_num];
    }

    public void resetInfo()
    {
        //Reset button order and default body text/header

        GameObject current_obj = body_text_list[current_text];
        GameObject  next_obj = body_text_list[0];
        header_text.text = header_text_list[0];
        current_obj.SetActive(false);
        next_obj.SetActive(true);
        int[] new_arr = {1, 2 ,3};
        button_order = new_arr;
        button1.text = button_text_list[button_order[0]];
        button2.text = button_text_list[button_order[1]];
        button3.text = button_text_list[button_order[2]];
        current_text = 0;
    }
}
