using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private Object holoTimer;
    private TextMesh textMesh;

    void Start()
    {
        Debug.Log("test");
        GameObject timer = GameObject.Find("TimeText");
        holoTimer = timer.GetComponent<HoloTimer>();

        GameObject startTextObj = GameObject.Find("StartText");

        textMesh = startTextObj.GetComponent<TextMesh>();

    }

    void OnSelect()
    {
        Debug.Log("abc");
        HoloTimer timer = (HoloTimer)holoTimer;
        if (timer.isTimerActive())
        {
            timer.StopTimer();
            textMesh.text = "Start";
        }
        else
        {
            timer.StartTimer();
            textMesh.text = "Stop";
        }
    }
}