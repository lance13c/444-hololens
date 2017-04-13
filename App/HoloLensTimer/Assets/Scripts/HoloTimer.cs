using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloTimer : MonoBehaviour {
    private int previousTime = 0;
    private bool countDown = false;
    private bool gatherText = true;   // Boolean trigger to tell if text gathering should be allowed 
    private int timeSec = 00;         // Time seconds
    private int timeMin = 5;          // Time minutes
    private int defaultSec = 00;
    private int defaultMin = 5;
    private string inputText = "";    // The time text represented: 0011, 00 = minutes, 11 = seconds
    private string displayText = "";  // The time text that will be displayed

    UnityEngine.TouchScreenKeyboard keyboard;
    public static string keyboardText = "";


    private int inputTextIndex = 0;
    const int MAX_INPUT_LENGTH = 4;

    // Use this for initialization
    void Start () {
        GetComponent<TextMesh>().text = this.GetTime();

        //keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
    }
	
	// Update is called once per frame
	void Update () {
        int currentTime = (int)Time.time;   // Gets time in seconds

        // increments time by 1 second
        if (currentTime > this.previousTime)
        {
         this.previousTime = currentTime;
         this.decrementTime();
         //If countDown True -> decrement timer
        }


        // Text Insertion

        //this.HandleText(this.inputText);       // Gets text from keyboard
        //this.SetTimer("1234");

    }

    /*
     * Counts down if countDown variable is true.
     */
    void decrementTime()
    {
        if (this.countDown == true)
        {
            if (this.timeSec > 0)
            {
                this.timeSec--;
            } else if (this.timeMin > 0)
            {
                this.timeSec = 59;
                this.timeMin--;
            } else
            {
                // Timer at 0. Stop timer.
                this.countDown = false;
            }


            DrawTime();
        }
    }

    // Gets time in string format
    string GetTime()
    {
        return this.timeMin.ToString("D2") + ":" + this.timeSec.ToString("D2");
    }

    private void DrawTime()
    {
        GetComponent<TextMesh>().text = GetTime();
    }

    public void StartTimer()
    {
        this.countDown = true;
    }

    public void StopTimer()
    {
        this.countDown = false;
    }

    public bool isTimerActive()
    {
        return this.countDown;
    }

    public void ToggleTimer()
    {
        if (this.countDown)
        {
            this.countDown = false;
        } else
        {
            this.countDown = true;
        }
    }

    public void SetTimer(int min, int sec)
    {
        this.countDown = false; // Stops it from counting down when changing the value.

        this.timeMin = min;
        this.timeSec = sec;
        this.defaultMin = min;
        this.defaultSec = sec;
        DrawTime();
    }

    // Must submit a time with a length of at least 4 characters.
    public void SetTimer(string time)
    {
        // On click add to string that keeps displaying;
        
        //if (time.Length >= MAX_INPUT_LENGTH)
        //{
            this.countDown = false; // Stops it from counting down when changing the value.

            int minutes = int.Parse(time.Substring(0, 2));
            int seconds = int.Parse(time.Substring(2, 2));
            this.timeMin = minutes;
            this.timeSec = seconds;
            this.defaultMin = minutes;
            this.defaultSec = seconds;
            DrawTime();
        //} else
        //{
            Debug.Log("Time not Long enough");
        //}
        
    }

    // Resets the timer to the default time.
    public void ResetTime()
    {
        this.countDown = false;

        this.timeMin = this.defaultMin;
        this.timeSec = this.defaultSec;
        DrawTime();
    }

    // Adds and removes digits from inserted text
    private string HandleText(string text)
    {
        foreach (char c in Input.inputString)
        {
            Debug.Log("test");
            Debug.Log(c);
            char digit = '@';
            //if (char.IsDigit(c))
            if (c == "\n"[0] || c == "\r"[0])
            {
                digit = c;
                if (text.Length >= 4)
                {
                    text = "";
                }

                text += digit.ToString();
            };
            this.inputText = text.PadLeft(4);
            this.SetTimer(this.inputText);
        }
        return this.inputText;
    }
}
