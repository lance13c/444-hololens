using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeButton : MonoBehaviour {

    private Object holoTimer;

    UnityEngine.TouchScreenKeyboard keyboard;
    public static string keyboardText = "";

    void Start()
    {
        Debug.Log("test");
        GameObject timer = GameObject.Find("TimeText");
        holoTimer = timer.GetComponent<HoloTimer>();
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);

    }

    private void Update()
    {
        if (TouchScreenKeyboard.visible == false && keyboard != null)
        {
            if (keyboard.done == true)
            {
                keyboardText = keyboard.text;
                keyboard = null;
            }
        }
    }

    void OnSelect()
    {
        HoloTimer timer = (HoloTimer)holoTimer;
        timer.SetTimer(keyboardText.PadLeft(4));
        keyboardText = "";
    }
}
