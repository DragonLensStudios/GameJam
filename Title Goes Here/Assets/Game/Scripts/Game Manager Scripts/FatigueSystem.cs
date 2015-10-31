[System.Serializable]

    public class FatigueSystem 
    {

    public TimeContainer Time = new TimeContainer(hour: 0, minute: 0, second: 0, timescale: 4.8f);
    public float currentFatigue;
    public int maxFatigue = 300;
    public float percentage;


    public float getPercentage()
        {
            percentage = currentFatigue/maxFatigue;
            return percentage;
        }

    public bool ProgressFatigue()
    {

        Time.StartTime(TimeType.Minute);
        if (Time.CheckTime(minute: 2))
        {
            currentFatigue += 1.0f;
            Time.ResetTime();
            return true;
        }
            return false;
    }

    public bool SleepFatigue()
    {
        Time.StartTime(TimeType.Minute);
        if (!Time.CheckTime(minute: 2) || !(currentFatigue > 0)) return false;
        currentFatigue -= 3.0f;
        if (currentFatigue < 0)
        currentFatigue = 0;
        
        Time.ResetTime();
        return true;
    }
}


