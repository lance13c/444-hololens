using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    private Object holoTimer;

    void Start()
    {
        Debug.Log("test");
        GameObject timer = GameObject.Find("TimeText");
        holoTimer = timer.GetComponent<HoloTimer>();

    }

    void OnSelect()
    {
        Debug.Log("abc");
        HoloTimer timer = (HoloTimer)holoTimer;
        timer.ResetTime();
    }
}
