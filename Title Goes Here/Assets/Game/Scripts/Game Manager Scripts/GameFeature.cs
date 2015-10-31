[System.Serializable]
public class GameFeature
{
    public string Name;
    public float Score = 0;
    public TimeContainer Time = new TimeContainer(hour:0, minute: 0,second: 0, timescale: 4.8f);
    private float initialtime;

    public GameFeature(string name)
    {
        Name = name;
    }

    public bool ProgressScore()
    {
        if (Score < 1 && Time.CheckTime(minute:30))
        {
            Time.ResetTime();
            Score += 0.5f;
            UnityEngine.Debug.Log("Tier 1 Progress: " + Name);
            return true;
        }
        if (Score < 2 && Time.CheckTime(minute:45))
        {
            Time.ResetTime();
            Score += 0.5f;
            UnityEngine.Debug.Log("Tier 2 Progress " + Name);
            return true;
        }
        if (Score < 3 && Time.CheckTime(hour: 1, minute: 15))
        {
            Time.ResetTime();
            Score += 0.5f;
            UnityEngine.Debug.Log("Tier 3 Progress " + Name);
            return true;
        }
        if (Score < 3.5 && Time.CheckTime(hour: 1, minute:30))
        {
            Time.ResetTime();
            Score += 0.5f;
            UnityEngine.Debug.Log("Tier 4 Progress " + Name);
            return true;
        }
        if (Score < 4 && Time.CheckTime(hour: 2))
        {
            Time.ResetTime();
            Score += 0.5f;
            UnityEngine.Debug.Log("Tier 4 Progress " + Name);
            return true;
        }
        if (Score < 4.5 && Time.CheckTime(hour: 2, minute:30))
        {
            Time.ResetTime();
            Score += 0.5f;
            UnityEngine.Debug.Log("Tier 5 Progress " + Name);
            return true;
        }
        if (Score >= 4.5 && Time.CheckTime(hour: 3))
        {
            Time.ResetTime();
            Score += 0.5f;
            UnityEngine.Debug.Log("Tier 5 Progress " + Name);
            return true;
        }
        return false;;
    }
}

