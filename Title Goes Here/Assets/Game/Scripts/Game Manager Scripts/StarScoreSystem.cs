[System.Serializable]
public class StarScoreSystem
{
    public FeatureType Feature = FeatureType.NONE;
    public double TotalScore;
    public bool isWorking;
    public GameFeature CurrentFeature;
    public FatigueSystem Fatigue;
    public GameFeature Audio = new GameFeature("Audio");
    public GameFeature Engine = new GameFeature("Engine");
    public GameFeature Gameplay = new GameFeature("Gameplay");
    public GameFeature Graphics = new GameFeature("Graphics");
    public GameFeature Story = new GameFeature("Story");

    public void TotalScoreCalc()
    {
        TotalScore = Audio.Score + Engine.Score + Gameplay.Score + Graphics.Score + Story.Score;
    }

    public void SetCurrentFeature(GameFeature feature)
    {
        CurrentFeature = feature;
    }

    public bool ValidateFeature(FeatureType _feature)
    {
        switch (_feature)
        {
            case FeatureType.NONE:
                SetCurrentFeature(null);
                isWorking = false;
                return false;
                break;
            case FeatureType.AUDIO:
                isWorking = true;
                SetCurrentFeature(Audio);
                FeatureStart();
                return true;
                break;
            case FeatureType.ENGINE:
                isWorking = true;
                SetCurrentFeature(Engine);
                FeatureStart();
                return true;
                break;
            case FeatureType.GAMEPLAY:
                isWorking = true;
                SetCurrentFeature(Gameplay);
                FeatureStart();
                return true;
                break;
            case FeatureType.GRAPHICS:
                isWorking = true;
                SetCurrentFeature(Graphics);
                FeatureStart();
                return true;
                break;
            case FeatureType.STORY:
                isWorking = true;
                SetCurrentFeature(Story);
                FeatureStart();
                return true;
                break;
        }
        return false;
    }

    public void FeatureStart()
    {
        if (CurrentFeature.Maxed == false)
        {
            CurrentFeature.Time.StartTime(TimeType.Minute);
            if (Fatigue.currentFatigue < Fatigue.maxFatigue)
            {
                CurrentFeature.ProgressScore();
                Fatigue.ProgressFatigue();
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
        TotalScore = 0;
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
