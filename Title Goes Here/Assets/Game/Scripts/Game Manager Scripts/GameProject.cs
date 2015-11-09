namespace DLS.Games.TitleGoesHere
{
    /// <summary>
    /// This class represents a Game Project Contains a Name, and Features and other variables that constitutes a full game project.
    /// </summary>
    [System.Serializable]
    public class GameProject
    {
        public string Name;
        public bool isWorking;
        public FeatureType Feature = FeatureType.NONE;
        public GameFeature CurrentFeature;
        public FatigueSystem Fatigue;
        public GameFeature Audio = new GameFeature("Audio");
        public GameFeature Engine = new GameFeature("Engine");
        public GameFeature Gameplay = new GameFeature("Gameplay");
        public GameFeature Graphics = new GameFeature("Graphics");
        public GameFeature Story = new GameFeature("Story");
        private float _totalScore;
        public float TotalScore
        {
            get
            {
                _totalScore = Audio.Score + Engine.Score + Gameplay.Score + Graphics.Score + Story.Score;
                return _totalScore;
            }
        }

        public void SetCurrentFeature(GameFeature feature)
        {
            CurrentFeature = feature;
        }

        public void ValidateFeature(FeatureType _feature)
        {
            switch (_feature)
            {
                case FeatureType.NONE:
                    SetCurrentFeature(null);
                    isWorking = false;
                    break;
                case FeatureType.AUDIO:
                    isWorking = true;
                    SetCurrentFeature(Audio);
                    FeatureStart();
                    break;
                case FeatureType.ENGINE:
                    isWorking = true;
                    SetCurrentFeature(Engine);
                    FeatureStart();
                    break;
                case FeatureType.GAMEPLAY:
                    isWorking = true;
                    SetCurrentFeature(Gameplay);
                    FeatureStart();
                    break;
                case FeatureType.GRAPHICS:
                    isWorking = true;
                    SetCurrentFeature(Graphics);
                    FeatureStart();
                    break;
                case FeatureType.STORY:
                    isWorking = true;
                    SetCurrentFeature(Story);
                    FeatureStart();
                    break;
            }
        }

        public void FeatureStart()
        {
            if (CurrentFeature.Maxed == false)
            {
                if (Fatigue.getPercentage() < 100)
                {
                    CurrentFeature.Time.StartTime(TimeType.Minute);
                    if (Fatigue.getPercentage() < 50)
                    {
                        //                    UnityEngine.Debug.Log("Normal Timescale");
                        CurrentFeature.Time.TimeScale = Game.Manage.Timers.GameTime.TimeScale;
                    }
                    if (Fatigue.getPercentage() >= 50)
                    {
                        //                    UnityEngine.Debug.Log("Lowered timescale to half");
                        CurrentFeature.Time.TimeScale = Game.Manage.Timers.GameTime.TimeScale / 2;
                    }
                    CurrentFeature.ProgressScore();
                    Fatigue.ProgressFatigue();
                }
                else
                {
                    UnityEngine.Debug.Log("YOU ARE FATIGUED!");
                }
            }
            else
            {
                Feature = FeatureType.NONE;
            }

        }

        public void FullResetScore()
        {
            Feature = FeatureType.NONE;
            isWorking = false;
            CurrentFeature.ResetFeature();
            Fatigue.ResetFatigue();
            Audio.ResetFeature();
            Engine.ResetFeature();
            Gameplay.ResetFeature();
            Graphics.ResetFeature();
            Story.ResetFeature();
        }

    }
}

