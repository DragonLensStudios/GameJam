using System.Diagnostics;

[System.Serializable]
public class GameFeature
{
    public string Name;
    public float Score = 0;
    public float ScoreAmount = .5f;
    public float MaxScore = 5;
    public bool Maxed;
    public TimeContainer Time = new TimeContainer(hour:0, minute: 0,second: 0, timescale: 4.8f);
    public GameFeature(string name)
    {
        Name = name;
    }

    public bool ProgressScore()
    {
        if (Maxed)
        {
            return false;
        }
        if (Maxed == false)
        {
            IncreaseScore();
            return true;
        }

        return false;;
    }

    private void IncreaseScore()
    {
        if (Score < 1 && Time.CheckTime(minute: 30))
        {
            RealIncrease();
        }
        if (Score < 2 && Time.CheckTime(minute: 45))
        {
            RealIncrease();
        }
        if (Score < 3 && Time.CheckTime(hour: 1, minute: 15))
        {
            RealIncrease();
        }
        if (Score < 3.5 && Time.CheckTime(hour: 1, minute: 30))
        {
            RealIncrease();
        }
        if (Score < 4 && Time.CheckTime(hour: 2))
        {
            RealIncrease();
        }
        if (Score < 4.5 && Time.CheckTime(hour: 2, minute: 30))
        {
            RealIncrease();
        }
        if (Score >= 4.5 && Time.CheckTime(hour: 3))
        {
            RealIncrease();
        }


//        if (Time.CheckTime(minute: 30))
//        {
//            RealIncrease();
//        }
//        if (Time.CheckTime(minute: 45))
//        {
//            RealIncrease();
//        }
//        if (Time.CheckTime(hour: 1, minute: 15))
//        {
//            RealIncrease();
//        }
//        if (Time.CheckTime(hour: 1, minute: 30))
//        {
//            RealIncrease();
//        }
//        if (Time.CheckTime(hour: 2))
//        {
//            RealIncrease();
//        }
//        if (Time.CheckTime(hour: 2, minute: 30))
//        {
//            RealIncrease();
//        }
//        if (Time.CheckTime(hour: 3))
//        {
//            RealIncrease();
//        }
    }


    public void RealIncrease()
    {
        Time.ResetTime(hour: true, minute: true, second: true);
        Score += ScoreAmount;
        GameEvents.IncreaseScore();
        if (Score == (int)Score)  // This is kinda a hack way of doing things but it works lol. since Score is a float this will round it when typecasted to Int
        {
            GameEvents.ShowMessage(message: "Star Gained", time: 3);
            UnityEngine.Debug.Log("Full Star Gained");
        }
        if (Score >= MaxScore)
        {
            Maxed = true;
            GameEvents.MaxFeature();
        }
    }

    public void ResetFeature()
    {
        Score = 0;
        Maxed = false;
        Time.ResetTime(hour:true, minute:true, second:true);
    }
}

