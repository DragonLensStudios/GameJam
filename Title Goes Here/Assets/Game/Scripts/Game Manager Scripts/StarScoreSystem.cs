[System.Serializable]
public class StarScoreSystem
{
    public int CurrentProgress;
    public double TotalScore;
    public GameFeature Audio = new GameFeature("Audio");
    public GameFeature Engine = new GameFeature("Engine");
    public GameFeature Gameplay = new GameFeature("Gameplay");
    public GameFeature Graphics = new GameFeature("Graphics");
    public GameFeature Story = new GameFeature("Story");


    public void TotalScoreCalc()
    {
        TotalScore = Audio.Score + Engine.Score + Gameplay.Score + Graphics.Score + Story.Score;
    }

}
