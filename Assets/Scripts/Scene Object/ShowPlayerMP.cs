using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ShowPlayerMP : MonoBehaviour
{
   

    private int MP = 100;
    private Vector3 P2_position;
    private GameObject P1RankUI;
    private GameObject P2RankUI;
    private Text myText;
    private Text LackMPText;
    private Color TextColor;
    private int i; //to control the speed of adding MP
   

    // Start is called before the first frame update
    void Start()
    {
        myText = (GameObject.Find("MP_text")).GetComponent<Text>();
        LackMPText = (GameObject.Find("lackMP")).GetComponent<Text>();
        i = 0;
        TextColor = LackMPText.color;
    }

    // Update is called once per frame
    void Update()
    {
        //get current MP
        int.TryParse(myText.text, out MP);

        //add MP
        i++; //to control the speed of adding MP
        if ( MP < 100 && i >= 3)
        {
            MP++;
            i = 0;
        }

        ////////////////////spell magic/////////////////
        //magic 1
       
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (MP >= 30)
            {
                MP -= 30;
                Debug.Log("法術1");

            }
            else
            {
                TextColor.a = 1;
                LackMPText.color = TextColor;
            }
        }

        //magic 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (MP >= 30)
            {
                MP -= 30;
                Debug.Log("法術2");

            }
            else
            {
                Debug.Log("MP不足");
                TextColor.a = 1;
                LackMPText.color = TextColor;
            }

        }

        //magic 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (MP >= 25)
            {
                MP -= 25;
                Debug.Log("法術3");

            }
            else
            {
                Debug.Log("MP不足");
                TextColor.a = 1;
                LackMPText.color = TextColor;
            }

        }

        //magic 4
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (MP >= 75)
            {
                MP -= 75;
                Debug.Log("法術4");

            }
            else
            {
                Debug.Log("MP不足");
                TextColor.a = 1;
                LackMPText.color = TextColor;
            }

        }

        TextColor = LackMPText.color;
        if( TextColor.a > 0)
        {
            TextColor.a -= 0.01f;
            LackMPText.color = TextColor;
        }


        myText.text  = MP.ToString();
    }
}
