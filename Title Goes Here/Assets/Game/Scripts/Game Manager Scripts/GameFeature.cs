[System.Serializable]
public class GameFeature
{
    public string Name;
    public float Score = 0;
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
            EventManager.IncreaseScoreEvent -= IncreaseScore;
            return false;
        }
        if (Maxed == false)
        {
            EventManager.IncreaseScoreEvent += IncreaseScore;
            EventManager.IncreaseScore();
            if (Score >= MaxScore)
            {
                EventManager.IncreaseScore();
                Maxed = true;
            }
            return true;
        }

        return false;;
    }

    private void IncreaseScore()
    {

        if (Score < 1 && Time.CheckTime(minute: 30))
        {
            Time.ResetTime(hour:true,minute:true,second:true);
            Score += 0.5f;
            UnityEngine.Debug.Log("Progress: " + Name + "Score: " + Score);
        }
        if (Score < 2 && Time.CheckTime(minute: 45))
        {
            Time.ResetTime(hour: true, minute: true, second: true);
            Score += 0.5f;
            UnityEngine.Debug.Log("Progress: " + Name + "Score: " + Score);
        }
        if (Score < 3 && Time.CheckTime(hour: 1, minute: 15))
        {
            Time.ResetTime(hour: true, minute: true, second: true);
            Score += 0.5f;
            UnityEngine.Debug.Log("Progress: " + Name + "Score: " + Score);
        }
        if (Score < 3.5 && Time.CheckTime(hour: 1, minute: 30))
        {
            Time.ResetTime(hour: true, minute: true, second: true);
            Score += 0.5f;
            UnityEngine.Debug.Log("Progress: " + Name + "Score: " + Score);
        }
        if (Score < 4 && Time.CheckTime(hour: 2))
        {
            Time.ResetTime(hour: true, minute: true, second: true);
            Score += 0.5f;
            UnityEngine.Debug.Log("Progress: " + Name + "Score: " + Score);
        }
        if (Score < 4.5 && Time.CheckTime(hour: 2, minute: 30))
        {
            Time.ResetTime(hour: true, minute: true, second: true);
            Score += 0.5f;
            UnityEngine.Debug.Log("Progress: " + Name + "Score: " + Score);
        }
        if (Score >= 4.5 && Time.CheckTime(hour: 3))
        {
            Time.ResetTime(hour: true, minute: true, second: true);
            Score += 0.5f;
            UnityEngine.Debug.Log("Progress: " + Name + "Score: " + Score);
            Maxed = true;
        }
    }

    public void ResetFeature()
    {
        Score = 0;
        Maxed = false;
        Time.ResetTime(hour:true, minute:true, second:true);
    }
}

