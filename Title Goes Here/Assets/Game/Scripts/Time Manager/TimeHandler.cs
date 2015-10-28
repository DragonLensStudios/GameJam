using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public Text textTime;
    public Text textTime2;
    public Text dayText;
    public bool timepassed;

    public TimeContainer GameTime = new TimeContainer(timescale:60);
    public TimeContainer RealTime = new TimeContainer();
    public TimeContainer testaction2 = new TimeContainer(hour:3,minute:0, timescale: 60);
    // Update is called once per frame
    void Update()
    {
        if (testaction2.CheckTime(hour: 1,minute: 0, second: 0))
        {
            Debug.Log("This works!");
        }
        else
        {
            testaction2.ReverseTime();
        }

        SetRealTime();
        GameTime.StartTime();
        textTime.text = GameTime.GetTimeString();
        textTime2.text = testaction2.GetTimeString();

        if (GameTime.CheckTime(year: 1, month: 1, day: 26))
        {
            textTime2.text = "Year 1 Month 1 Day 26 CHECKED!!";
        }

        if (GameTime.CheckTime(year: 1, month: 1, day: 25))
        {
            textTime2.text = "Year 1 Month 1 Day 25 CHECKED!!";
        }

        if (GameTime.CheckExactTime(year:1, month: 12, week: 1, day:25, hour:1, minute:0, second:0))
        {
            textTime2.text = "Minute 10 Second 0 CHECKED!!";
        }

        if (GameTime.CheckTime(hour: 2))
        {
            Debug.Log("Hour 2!");
        }

    }

    public void SetRealTime()
    {
        var weekcheck = (RealTime.Day / 7) + 1;
        RealTime.Second = System.DateTime.Now.Second;
        RealTime.Year = System.DateTime.Now.Year;
        RealTime.Month = System.DateTime.Now.Month;
        RealTime.CurrentMonth = (Months)System.DateTime.Now.Month;
        RealTime.Day = System.DateTime.Now.Day;
        RealTime.CurrentDay = (Days)System.DateTime.Now.DayOfWeek;
        RealTime.Minute = System.DateTime.Now.Minute;
        RealTime.Week = weekcheck;
    }

}
