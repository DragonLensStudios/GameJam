using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class Game: MonoBehaviour 
{
    private static Game instance;

    public static Game Manage
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Game>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.AddComponent<Game>();
                }
            }
            return instance;
        }
    }

    public string GameName = "Title Goes Here";
    public AudioClip Day1song;
    public AudioSource MusicManager;
    public UIHandler UI;
    public GameState CurrentGameState = GameState.PAUSED;
    public StarScoreSystem ScoreSystem;
    public TimeContainer GameTime = new TimeContainer(timescale: 4.8f);
    public TimeContainer GameTimeLimit = new TimeContainer(year: 0, month: 0, day: 3, hour: 0, minute: 1, timescale: 4.8f);
    public TimeContainer RealTime = new TimeContainer(minute: 15);
    public TimeContainer ProcrastinationTime = new TimeContainer(timescale: 60);

    public bool OnHomeScreen = true;

    public GameObject ConclusionPanelPrefab;

    void OnEnable()
    {
        GameEvents.ResetGameEvent += StartGame;
        GameEvents.MaxFeatureEvent += MaxedFeature;
    }

    void OnDisable()
    {
        GameEvents.ResetGameEvent -= StartGame;
        GameEvents.MaxFeatureEvent -= MaxedFeature;
    }

    public void MaxedFeature()
    {
        GameEvents.ShowMessage(message: "MAXED FEATURE: " + ScoreSystem.CurrentFeature.Name, time: 3);
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        MusicManager.clip = Day1song;
        MusicManager.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameTimeLimit.CheckTime(day: 2, hour: 0, minute: 0))
        {
            GameEvents.ShowMessage("2 Days Left!");
        }
        if (GameTimeLimit.CheckTime(day: 1, hour: 0, minute: 0))
        {
            GameEvents.ShowMessage("1 Days Left!");
        }
        if (GameTimeLimit.CheckTime(day: 0, hour: 0, minute: 0))
        {
            GameEvents.ShowMessage("TIME IS UP!");
        }

        switch (CurrentGameState)
        {
            case GameState.NONE:
                break;
            case GameState.PAUSED:
                Time.timeScale = 0;
                break;
            case GameState.RUNNING:
                Time.timeScale = 1;

                if (UI.CurrentAppPanel == null || UI.CurrentAppPanel.activeSelf == false)
                {
                    OnHomeScreen = true;
                }
                else
                {
                    OnHomeScreen = false;
                }

                if (OnHomeScreen == false)
                {
                    GameTime.StartTime(TimeType.Minute);
                    GameTimeLimit.ReverseTime(TimeType.Minute);
                }

                if (ScoreSystem.isWorking)
                {
                    ScoreSystem.ValidateFeature(ScoreSystem.Feature);
                }
                if(ScoreSystem.isWorking == false)
                {
                    ProcrastinationTime.StartTime(TimeType.Minute);
                    ScoreSystem.Fatigue.SleepFatigue();
                    if (ScoreSystem.Fatigue.getPercentage() > 75)
                    {
                        GameTimeLimit.TimeScale = GameTime.TimeScale * 2;
                    }
                    else
                    {
                        GameTimeLimit.TimeScale = GameTime.TimeScale;
                    }
                }

                break;
        }

        if (GameTimeLimit.CheckTime(day: 0, hour: 0, minute: 0))
        {
            if (UI.CurrentAppPanel != null || UI.CurrentAppPanel.activeSelf)
            {
                Destroy(UI.CurrentAppPanel);
            }
//            Debug.Log("GAME OVER! " + "Audio: " + ScoreSystem.Audio.Score + " Engine: " + ScoreSystem.Engine.Score + " Gameplay: " + ScoreSystem.Gameplay.Score + " Graphics: " + ScoreSystem.Graphics.Score + " Story: " + ScoreSystem.Story.Score);
            UI.DoorOSMainPanel.SetActive(false);
            Instantiate(ConclusionPanelPrefab).transform.SetParent(UI.transform, false);
            CurrentGameState = GameState.PAUSED;
        }

    }

    public void SetGameState(int gamestateindex)
    {
        CurrentGameState = (GameState) gamestateindex;
    }

    public void SetFeature(int featureindex)
    {
        ScoreSystem.Feature = (FeatureType) featureindex;
    }

    public void CloseApp()
    {
        UI.DoorAppsPanel.SetActive(true);
        if (UI.CurrentAppPanel.activeSelf == true)
        {
            UI.CurrentAppPanel.SetActive(false);
            UI.CurrentAppPanel = null;
        }
    }

    public void SetWorking()
    {
        ScoreSystem.isWorking = true;
    }
    public void SetProcrastinating()
    {
        ScoreSystem.isWorking = false;
    }

    public void StartGame()
    {
        GameTimeLimit.SetTime(year: 0, month: 0, week: 1, day: 3, hour: 0, minute: 0);
        GameTime.ResetFullDate();
        ScoreSystem.FullResetScore();
        ProcrastinationTime.ResetTime(day:true, minute:true, second:true, week:true);
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
