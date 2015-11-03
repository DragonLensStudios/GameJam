[System.Serializable]

    public class FatigueSystem 
    {

    public TimeContainer Time = new TimeContainer(hour: 0, minute: 0, second: 0, timescale: 4.8f);
    public float currentFatigue;
    public int maxFatigue = 100;
    public float percentage;


    public float getPercentage()
    {
        percentage = currentFatigue/maxFatigue * 100;
        return percentage;
    }

    public bool ProgressFatigue()
    {
        Time.StartTime(TimeType.Minute);
        if (Time.Minute >= 10)
        {
            currentFatigue += 5;
            Time.ResetTime(minute:true, second:true);
            return true;
        }
        return false;
//        Time.StartTime(TimeType.Minute);
//        if (Time.CheckTime(minute: 2))
//        {
//            currentFatigue += 1.0f;
//            Time.ResetTime(hour: true, minute: true, second: true);
//            return true;
//        }
//            return false;
    }

    public bool SleepFatigue()
    {
        Time.StartTime(TimeType.Minute);
        if (Time.Minute >= 5)
        {
            if (getPercentage() < 75)
            {
                {
                    currentFatigue -= 5;
                }
            }
            else
            {
                currentFatigue -= 1;
            }

            if (currentFatigue - 5 <= 0)
            {
                currentFatigue = 0;
            }
            Time.ResetTime(minute:true, second:true);
            return true;
        }

        return false;
//        Time.StartTime(TimeType.Minute);
//        if (!Time.CheckTime(minute: 2) || !(currentFatigue > 0)) return false;
//        currentFatigue -= 3.0f;
//        if (currentFatigue < 0)
//        currentFatigue = 0;
//
//        Time.ResetTime(hour: true, minute: true, second: true);
//        return true;
    }

    public void ResetFatigue()
    {
        Time.ResetTime(hour:true, minute:true, second:true);
        currentFatigue = 0;
        percentage = 0;
    }
}


