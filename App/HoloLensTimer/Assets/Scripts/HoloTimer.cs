using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloTimer : MonoBehaviour {
    private int previousTime = 0;
    private bool countDown = false;
    private int timeSec = 00;        // Time seconds
    private int timeMin = 5;        // Time minutes
    private string inputText = "";    // The time text represented: 0011, 00 = minutes, 11 = seconds
    private string displayText = "";  // The time text that will be displayed
    private int inputTextIndex = 0;
    const int MAX_INPUT_LENGTH = 4;

    // Use this for initialization
    void Start () {
        GetComponent<TextMesh>().text = this.GetTime();
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
        return this.timeMin.ToString() + ":" + this.timeSec.ToString();
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
        DrawTime();
    }

    // Must submit a time with a length of at least 4 characters.
    public void SetTimer(string time)
    {

        
        if (time.Length >= MAX_INPUT_LENGTH)
        {
            this.countDown = false; // Stops it from counting down when changing the value.

            int minutes = int.Parse(time.Substring(0, 2));
            int seconds = int.Parse(time.Substring(2, 2));
            this.timeMin = minutes;
            this.timeSec = seconds;
            DrawTime();
        } else
        {
            Debug.Log("Time not Long enough");
        }
        
    }

    private void HandleText()
    {
        foreach (char c in Input.inputString)
        {
            char digit = '@';
            if (char.IsDigit(c))
            {
                digit = c;
            };



            if (digit != '@')
            {
                this.inputText += digit;

                this.SetTimer(inputText);

                // InputTextIndex handler
                
                if (this.inputTextIndex > MAX_INPUT_LENGTH)
                {

                    //this.inputText.Insert(inputTextIndex, int.Parse());
                    this.inputText.Remove(inputTextIndex, 1);
                    

                    this.inputTextIndex += 1;
                }


            }
            //if (c == "\b"[0])
            //    if (this.inputText.Length != 0)
            //        this.inputText = this.inputText.Substring(0, this.inputText.Length - 1);

            //    else
            //    if (c == "\n"[0] || c == "\r"[0])
            //        print("User entered their name: " + gt.text);
            //    else
            //        gt.text += c;
        }
    }
}
