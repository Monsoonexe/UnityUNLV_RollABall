//Author: Richard Osborn
//Date 10/1/18
//Description:
//  if there is a level countdown timer, the time will count down every frame and send a message when it hits 0
// if no time limit, time will count up and display how long it took to complete level.

using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

    private Text timerText;
    public float timeToCompleteLevel;
    public float timer;
    public float levelStartDelay = 1.0f;//1 second level delay
    public bool countdown;//if true, time will count down and level will fail upon 0.  false, timer acts as stopwatch
    public string countdownText;
    public string stopwatchText;

	// Use this for initialization
	void Start () {
        timerText = this.gameObject.GetComponent<Text>();//find the Text component attached to this GO
        //determine timer mode and initialize time
        if (countdown)//countdown mode
        {
            timer = timeToCompleteLevel;
        }
        else//stopwatch mode
        {
            timer = 0;            
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        //level start delay
        //don't start counting down timer until (level 1 Begin! is shown, animations, etc etc)
        if(Time.timeSinceLevelLoad < levelStartDelay)
        { 
            return;
        }
        if (countdown)//countdown mode
        {
            timer -= Time.deltaTime;//every frame, subtract the time since last frame from timer 
            UpdateTimerText(countdownText, (int)timer);//update UI
        }
        else//stopwatch mode
        {
            timer += Time.deltaTime;//every frame, add the amount of time passed since last frame executed to the timer
            UpdateTimerText(stopwatchText, (int)timer);//update UI

        }

    }

    private void UpdateTimerText(string suffix, int totalSeconds)
        //this function formats the time into 00:00 format
    {
        int minutes = (int)totalSeconds / 60;
        int seconds = totalSeconds - (minutes * 60);

        string minutesString = "";
        string secondsString = "";

        if(seconds < 10)// append a leading 0 if < 10
        {// 03:05
            secondsString += "0";
        }
        secondsString += seconds.ToString();

        if (minutes < 10)// append a leading 0 if < 10
        {// 03:05
            minutesString += "0";
        }
        minutesString += minutes.ToString();

        timerText.text = suffix + ":  " + minutesString + ":" + secondsString;
        
    }
}
