using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public AudioClip Day1song;
    public AudioSource MusicManager; 

    public Text GameTimeText;
    public Text GameTimeLimitText;

    public Text RealTimeCounterText;

    public Text TotalScoreText;
    public Text AudioTimerText;
    public Text EngineTimerText;
    public Text GameplayTimerText;
    public Text GraphicsTimerText;
    public Text StoryTimerText;
    public Text ProcrastinationTimerText;
    public Text CurrentTaskText;
    public Text FatigueText;

    public int incrementedFrame;
    public int randomtime;
    public bool randomengaged;

    public GameState CurrentGameState = GameState.PAUSED;

    public StarScoreSystem ScoreSystem;
    public TimeContainer GameTime = new TimeContainer(timescale:60);
    public TimeContainer GameTimeLimit = new TimeContainer(year:0, month: 0, day: 3, hour: 0 , minute: 1,timescale: 4.8f);
    public TimeContainer RealTime = new TimeContainer(minute:15);
    public TimeContainer ProcrastinationTime = new TimeContainer(timescale:60);

    public FatigueSystem fatigueSystem = new FatigueSystem();
//    public TimeContainer testaction2 = new TimeContainer(hour:3,minute:0, timescale: 60);


    void Start()
    {
        fatigueSystem.currentFatigue = 0;
        MusicManager.clip = Day1song;
        MusicManager.Play();
    }
    // Update is called once per frame
    void Update()
    {
        incrementedFrame++;
        RealTime.ReverseTime();
        GameTime.StartTime(TimeType.Minute);
        GameTimeLimit.ReverseTime(TimeType.Minute);

        //        if (CurrentGameState != GameState.PROCRASTINATION && randomengaged == false)
        //        {
        //            randomtime = Random.Range(10, 30) % 60;
        //            randomengaged = true;
        //        }
        //
        //        if (randomengaged && GameTime.CheckTime(minute:randomtime))
        //        {
        //            CurrentGameState = GameState.PROCRASTINATION;
        //            randomengaged = false;
        //        }

        if (CurrentGameState == GameState.PAUSED)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

//        if (GameTimeLimit.CheckTime(minute:0))
//        {
//            CurrentGameState = GameState.ENDGAME;
//        }

        switch (CurrentGameState)
        {
            case GameState.PAUSED:
                CurrentTaskText.text = "PAUSED!";
                break;
            case GameState.PROCRASTINATION:
                ProcrastinationTime.StartTime(TimeType.Minute);
                CurrentTaskText.text = "Procrastinating!";
                break;
            case GameState.WORK_ON_AUDIO:
                if (fatigueSystem.currentFatigue < fatigueSystem.maxFatigue)
                {


                    ScoreSystem.Audio.ProgressScore();
                    fatigueSystem.ProgressFatigue();
                    CurrentTaskText.text = "Working On Audio!";
                    if (ScoreSystem.Audio.Score < 5)
                    {
                        ScoreSystem.Audio.Time.StartTime(TimeType.Minute);
                    }
                }
                break;
            case GameState.WORK_ON_ENGINE:
                if (fatigueSystem.currentFatigue < fatigueSystem.maxFatigue)
                {
                    CurrentTaskText.text = "Working On Engine!";
                ScoreSystem.Engine.ProgressScore();
                fatigueSystem.ProgressFatigue();
                if (ScoreSystem.Engine.Score < 5)
                {
                    ScoreSystem.Engine.Time.StartTime(TimeType.Minute);
                }
          }
                break;
            case GameState.WORK_ON_GAMEPLAY:
                if (fatigueSystem.currentFatigue < fatigueSystem.maxFatigue)
                {
                    CurrentTaskText.text = "Working On Gameplay!";
                    ScoreSystem.Gameplay.ProgressScore();
                    fatigueSystem.ProgressFatigue();
                    if (ScoreSystem.Gameplay.Score < 5)
                    {
                        ScoreSystem.Gameplay.Time.StartTime(TimeType.Minute);
                    }
                }
                break;
            case GameState.WORK_ON_GRAPHICS:
                if (fatigueSystem.currentFatigue < fatigueSystem.maxFatigue)
                {
                    CurrentTaskText.text = "Working On Graphics!";
                ScoreSystem.Graphics.ProgressScore();
                fatigueSystem.ProgressFatigue();
                if (ScoreSystem.Graphics.Score < 5)
                {
                    ScoreSystem.Graphics.Time.StartTime(TimeType.Minute);
                }
              }
                break;
            case GameState.WORK_ON_STORY:
                if (fatigueSystem.currentFatigue < fatigueSystem.maxFatigue)
                {
                    CurrentTaskText.text = "Working On Story!";
                fatigueSystem.ProgressFatigue();
                ScoreSystem.Story.ProgressScore();
                if (ScoreSystem.Story.Score < 5)
                {
                    ScoreSystem.Story.Time.StartTime(TimeType.Minute);
                }
             }
                break;
            case GameState.SLEEP:
                fatigueSystem.SleepFatigue();
                break;
            case GameState.ENDGAME:
                CurrentTaskText.text = "GAME END!";
                break;
        }

        ScoreSystem.TotalScoreCalc();

        TotalScoreText.text = "Total Score: " + ScoreSystem.TotalScore;
        GameTimeText.text =   "Day " + GameTime.Day + " Game Time: "+ GameTime.TimeString_H_MM;
        AudioTimerText.text = "Audio Feature: " + ScoreSystem.Audio.Time.TimeString_H_MM + " Score: " + ScoreSystem.Audio.Score;
        EngineTimerText.text = "Engine Feature: " + ScoreSystem.Engine.Time.TimeString_H_MM + " Score: " + ScoreSystem.Engine.Score;
        GameplayTimerText.text = "Gameplay Feature: " + ScoreSystem.Gameplay.Time.TimeString_H_MM + " Score: " + ScoreSystem.Gameplay.Score;
        GraphicsTimerText.text = "Graphics Feature: " + ScoreSystem.Graphics.Time.TimeString_H_MM + " Score: " + ScoreSystem.Graphics.Score;
        StoryTimerText.text = "Story Feature: " + ScoreSystem.Story.Time.TimeString_H_MM + " Score: " + ScoreSystem.Story.Score;
        ProcrastinationTimerText.text = "Procrastination Timer: " + ProcrastinationTime.TimeString_H_MM;
        GameTimeLimitText.text = "DAYS LEFT: " + GameTimeLimit.Day + "  Time Left: " + GameTimeLimit.TimeString_H_MM;
        RealTimeCounterText.text = "REAL TIME: " + RealTime.TimeString_H_MM_SS;
        FatigueText.text = System.String.Format("Fatigue : {0:P} % ", fatigueSystem.getPercentage());
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
