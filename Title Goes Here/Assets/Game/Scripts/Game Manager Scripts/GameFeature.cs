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
//        initialtime = Time.TotalTimeSeconds;
    }

    public bool ProgressScore()
    {

//        if (float.IsNaN(initialtime))
//        {
//            initialtime = Time.TotalTimeSeconds;
//            //Debug.Log(initialtime);
//        }
//        float _delta = (Time.TotalTimeSeconds - initialtime) / 3600;
//
//        float _temp_score = -(_delta * _delta) * (5f / 196f) + 5 * _delta / 7f;
//        //Debug.Log("Did something, Delta: " + _delta + " , TempScore: " + _temp_score);
//
//        if (_temp_score - Score > .5f || _delta >=14)
//        {
//            Score = Mathf.Round(2 * _temp_score) / 2;
//            Debug.Log("score: " + Score + " time(hours): " + _delta);
//            return true;
//        }


        if (Score < 1 && Time.CheckTime(minute:30,second:0))
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

