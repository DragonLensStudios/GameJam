namespace DLS.Games.TitleGoesHere
{
    using UnityEngine;
    /// <summary>
    /// This is the Game Manager class, this handles the main execution thread and handles the game state operations.
    /// </summary>
    public class Game : MonoBehaviour
    {
        private static Game instance;

        /// <summary>
        /// Used to call methods and utilize variables in the Game.
        /// </summary>
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

        //        public string GameName = "Title Goes Here"; // Move to GameProject
        public TimeManager Timers;
        public AudioManager Audio;
        public UIHandler UI;
        public GameState CurrentGameState = GameState.PAUSED;
        public GameProject CurrentGameProject;
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
            GameEvents.ShowMessage(message: "MAXED FEATURE: " + CurrentGameProject.CurrentFeature.Name, time: 3);
        }

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            Audio.PlayBGM(0);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.M)) { Audio.Control.mute = !Audio.Control.mute; } // Toggles mute for the game audio
            if (Input.GetKeyDown(KeyCode.T)) { Debug.Log(CurrentGameProject.TotalScore); } // Debugs total score out.

            if (Timers.GameTimeLimit.CheckTime(day: 2, hour: 0, minute: 0)) { GameEvents.ShowMessage("2 Days Left!"); } //Shows Days remaining
            if (Timers.GameTimeLimit.CheckTime(day: 1, hour: 0, minute: 0)) { GameEvents.ShowMessage("1 Day Left!"); } //Shows Days remaining

            switch (CurrentGameState)
            {
                case GameState.NONE:
                    break;
                case GameState.PAUSED:
                    Time.timeScale = 0;
                    break;
                case GameState.RUNNING:
                    Time.timeScale = 1;

                    // This checks to see if there is an open app and if there is run the game timers, otherwise you are on the homescreen.
                    if (UI.CurrentAppPanel == null)
                    {
                        //Must be on the Homescreen or no app is open.
                    }
                    else
                    {
                        Timers.GameTime.StartTime(TimeType.Minute);
                        Timers.GameTimeLimit.ReverseTime(TimeType.Minute);
                    }

                    if (CurrentGameProject.isWorking)
                    {
                        CurrentGameProject.ValidateFeature(CurrentGameProject.Feature);
                    }
                    if (CurrentGameProject.isWorking == false)
                    {
                        Timers.ProcrastinationTime.StartTime(TimeType.Minute);
                        CurrentGameProject.Fatigue.SleepFatigue();
                        if (CurrentGameProject.Fatigue.getPercentage() > 75)
                        {
                            Timers.GameTimeLimit.TimeScale = Timers.GameTime.TimeScale * 2;
                        }
                        else
                        {
                            Timers.GameTimeLimit.TimeScale = Timers.GameTime.TimeScale;
                        }
                    }

                    break;
            }

            if (Timers.GameTimeLimit.CheckTime(day: 0, hour: 0, minute: 0))
            {
                GameEvents.ShowMessage("TIME IS UP");
                if (UI.CurrentAppPanel != null | UI.CurrentAppPanel.activeSelf)
                {
                    Destroy(UI.CurrentAppPanel);
                }
//            Debug.Log("GAME OVER! " + "Audio: " + CurrentGameProject.Audio.Score + " Engine: " + CurrentGameProject.Engine.Score + " Gameplay: " + CurrentGameProject.Gameplay.Score + " Graphics: " + CurrentGameProject.Graphics.Score + " Story: " + CurrentGameProject.Story.Score);
                UI.DoorOSMainPanel.SetActive(false);
                Instantiate(UI.ConclusionPanelPrefab).transform.SetParent(UI.transform, false);
                CurrentGameState = GameState.PAUSED;
            }

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
            CurrentGameProject.isWorking = true;
        }
        public void SetProcrastinating()
        {
            CurrentGameProject.isWorking = false;
        }

        public void StartGame()
        {
            Timers.GameTimeLimit.SetTime(year: 0, month: 0, week: 1, day: 3, hour: 0, minute: 0);
            Timers.GameTime.ResetFullDate();
            CurrentGameProject.FullResetScore();
            Timers.ProcrastinationTime.ResetTime(day: true, hour: true, minute: true, second: true);
        }


    }

}

