using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public Text GameTimeText;
    public Text GameTimeLimitText;

    public Text TotalScoreText;
    public Text AudioTimerText;
    public Text EngineTimerText;
    public Text GameplayTimerText;
    public Text GraphicsTimerText;
    public Text StoryTimerText;
    public Text ProcrastinationTimerText;
    public Text CurrentTaskText;

    public int randomtime;
    public bool randomengaged;

    public GameState CurrentGameState = GameState.PAUSED;
    

//    public Text textTime;
//    public Text textTime2;
//    public Text dayText;
//    public bool timepassed;

    public StarScoreSystem ScoreSystem;

    public TimeContainer GameTime = new TimeContainer(timescale:60);
    public TimeContainer GameTimeLimit = new TimeContainer(day: 2, hour: 23, minute: 59,timescale:60);
    public TimeContainer RealTime = new TimeContainer();
    public TimeContainer ProcrastinationTime = new TimeContainer(timescale:60);
//    public TimeContainer testaction2 = new TimeContainer(hour:3,minute:0, timescale: 60);

    // Update is called once per frame
    void Update()
    {
        SetRealTime();
        GameTime.StartTime();
        GameTimeLimit.ReverseTime();

        if (CurrentGameState != GameState.PROCRASTINATION && randomengaged == false)
        {
            randomtime = Random.Range(10, 30) % 60;
            randomengaged = true;
        }

        if (randomengaged && GameTime.CheckTime(minute:randomtime))
        {
            CurrentGameState = GameState.PROCRASTINATION;
            randomengaged = false;
        }

        switch (CurrentGameState)
        {
            case GameState.PAUSED:
                Time.timeScale = 0;
                CurrentTaskText.text = "PAUSED!";
                break;
            case GameState.PROCRASTINATION:
                Time.timeScale = 1;
                ProcrastinationTime.StartTime();
                CurrentTaskText.text = "Procrastinating!";
                break;
            case GameState.WORK_ON_AUDIO:
                Time.timeScale = 1;
                ScoreSystem.Audio.ProgressScore();
                CurrentTaskText.text = "Working On Audio!";
                if (ScoreSystem.Audio.Score < 5)
                {
                    ScoreSystem.Audio.Time.StartTime();
                }
                break;
            case GameState.WORK_ON_ENGINE:
                Time.timeScale = 1;
                CurrentTaskText.text = "Working On Engine!";
                ScoreSystem.Engine.ProgressScore();
                if (ScoreSystem.Engine.Score < 5)
                {
                    ScoreSystem.Engine.Time.StartTime();
                }
                break;
            case GameState.WORK_ON_GAMEPLAY:
                Time.timeScale = 1;
                CurrentTaskText.text = "Working On Gameplay!";
                ScoreSystem.Gameplay.ProgressScore();
                if (ScoreSystem.Gameplay.Score < 5)
                {
                    ScoreSystem.Gameplay.Time.StartTime();
                }
                break;
            case GameState.WORK_ON_GRAPHICS:
                Time.timeScale = 1;
                CurrentTaskText.text = "Working On Graphics!";
                ScoreSystem.Graphics.ProgressScore();
                if (ScoreSystem.Graphics.Score < 5)
                {
                    ScoreSystem.Graphics.Time.StartTime();
                }
                break;
            case GameState.WORK_ON_STORY:
                Time.timeScale = 1;
                CurrentTaskText.text = "Working On Story!";
                ScoreSystem.Story.ProgressScore();
                if (ScoreSystem.Story.Score < 5)
                {
                    ScoreSystem.Story.Time.StartTime();
                }
                break;
        }

        ScoreSystem.TotalScoreCalc();

        //        if (ScoreSystem.Audio.Score < 5)
        //        {
        //            ScoreSystem.Audio.Time.StartTime();
        //            if (ScoreSystem.Audio.ProgressScore())
        //            {
        ////                textTime2.text = "Audio SCORE INCREASED! : " + ScoreSystem.Audio.Score;
        //            }
        //        }

        TotalScoreText.text = "Total Score: " + ScoreSystem.TotalScore;

        GameTimeText.text = "Game Time: " + GameTime.GetTimeString();
        AudioTimerText.text = "Audio Feature: " + ScoreSystem.Audio.Time.GetTimeString() + " Score: " + ScoreSystem.Audio.Score;
        EngineTimerText.text = "Engine Feature: " + ScoreSystem.Engine.Time.GetTimeString() + " Score: " + ScoreSystem.Engine.Score;
        GameplayTimerText.text = "Gameplay Feature: " + ScoreSystem.Gameplay.Time.GetTimeString() + " Score: " + ScoreSystem.Gameplay.Score;
        GraphicsTimerText.text = "Graphics Feature: " + ScoreSystem.Graphics.Time.GetTimeString() + " Score: " + ScoreSystem.Graphics.Score;
        StoryTimerText.text = "Story Feature: " + ScoreSystem.Story.Time.GetTimeString() + " Score: " + ScoreSystem.Story.Score;
        ProcrastinationTimerText.text = "Procrastination Timer: " + ProcrastinationTime.GetTimeString();
        GameTimeLimitText.text = "DAYS LEFT: " + GameTimeLimit.Day + "  Time Left: " + GameTimeLimit.GetTimeString();


        //        if (testaction2.CheckTime(hour: 1,minute: 0, second: 0))
        //        {
        //            Debug.Log("This works!");
        //        }
        //        else
        //        {
        //            testaction2.ReverseTime();
        //        }


        //        textTime.text = GameTime.GetTimeString();
        //        textTime2.text = testaction2.GetTimeString();
        //
        //        if (GameTime.CheckTime(year: 1, month: 1, day: 26))
        //        {
        //            textTime2.text = "Year 1 Month 1 Day 26 CHECKED!!";
        //        }
        //
        //        if (GameTime.CheckTime(year: 1, month: 1, day: 25))
        //        {
        //            textTime2.text = "Year 1 Month 1 Day 25 CHECKED!!";
        //        }
        //
        //        if (GameTime.CheckExactTime(year:1, month: 12, week: 1, day:25, hour:1, minute:0, second:0))
        //        {
        //            textTime2.text = "Minute 10 Second 0 CHECKED!!";
        //        }
        //
        //        if (GameTime.CheckTime(hour: 2))
        //        {
        //            Debug.Log("Hour 2!");
        //        }
    }

    public void SetGameState(int gamestateindex)
    {
        CurrentGameState = (GameState) gamestateindex;
    }

    public void SetRealTime()
    {
        var weekcheck = (RealTime.Day/7) + 1;
        RealTime.Second = System.DateTime.Now.Second;
        RealTime.Year = System.DateTime.Now.Year;
        RealTime.Month = System.DateTime.Now.Month;
        RealTime.CurrentMonth = (Months) System.DateTime.Now.Month;
        RealTime.Day = System.DateTime.Now.Day;
        RealTime.Hour = System.DateTime.Now.Hour;
        RealTime.CurrentDay = (Days) System.DateTime.Now.DayOfWeek;
        RealTime.Minute = System.DateTime.Now.Minute;
        RealTime.Week = weekcheck;
    }
}
