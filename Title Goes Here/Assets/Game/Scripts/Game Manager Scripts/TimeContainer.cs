using UnityEngine;

[System.Serializable]
public class TimeContainer
{
    public int Year;
    public int Month;
    public int Week;
    public int Day;
    public int Hour;
    public int Minute;
    public float Second;
    public float TimeScale = 1;
    public int SecondsInMinute = 60;
    public int MinutesInHour = 60;
    public int HoursInDay = 24;
    public int DaysInWeek = 7;
    public int WeeksInMonth = 4;
    public int MonthsInYear = 12;

    public bool secondCheckBool;
    public bool minuteCheckBool;
    public bool hourCheckBool;
    public bool dayCheckBool;
    public bool weekCheckBool;
    public bool monthCheckBool;
    public bool yearCheckBool;
    public bool fulltimeCheckBool;

    /// <summary>
    /// This is the Time Container, you can choose which values to set by default.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="week"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <param name="timescale"></param>
    public TimeContainer(int year = 0, int month = 0, int week = 0,int day = 0, int hour = 0, int minute = 0, float second = 0, float timescale = 1)
    {
        Year = year;
        Month = month;
        Week = week;
        Day = day;
        Hour = hour;
        Minute = minute;
        Second = second;
        TimeScale = timescale;
    }

    /// <summary>
    /// Needs to be called in an Update function for the Time to be properly set.
    /// </summary>
    /// <returns></returns>
    public bool ValidateTime()
    {
        Second += Time.deltaTime * TimeScale;

        if (Second >= SecondsInMinute)
        {
            Second = 0;
            minuteCheckBool = false;
            Minute++;
        }
        if (Minute >= MinutesInHour)
        {
            Minute = 0;
            hourCheckBool = false;
            Hour++;
        }
        if (Hour >= HoursInDay)
        {
            Hour = 0;
            dayCheckBool = false;
            Day++;
        }
        if (Day >= DaysInWeek)
        {
            Day = 0;
            weekCheckBool = false;
            Week++;
        }
        if (Week >= WeeksInMonth)
        {
            Week = 0;
            monthCheckBool = false;
            Month++;
        }
        if (Month >= MonthsInYear)
        {
            Month = 0;
            yearCheckBool = false;
            Year++;
        }

        return true;
    }

    public bool CheckDay(int day)
    {
        if (dayCheckBool == false && Day == day)
        {
            dayCheckBool = true;
            return true;
        }
        return false;
    }

    public bool CheckHour(int hour)
    {
        if (hourCheckBool == false && Hour == hour)
        {
            hourCheckBool = true;
            return true;
        }
        return false;
    }

    public bool CheckMinute(int minute)
    {
        if (minuteCheckBool == false && Minute == minute)
        {
            minuteCheckBool = true;
            return true;
        }
        return false;
    }

    public bool CheckSecond(int second)
    {        
        if (secondCheckBool == false && (int)Second == second)
        {
            secondCheckBool = true;
            return true;
        }
        return false;

    }

    public bool CheckFullTime(int day = 0, int hour = 0, int minute = 0, int second = 0)
    {
        if (fulltimeCheckBool == false)
        {
            if (day != 0 && hour != 0 && minute != 0 && second != 0)
            {
                if (Day == day && Hour == hour && Minute == minute && (int)Second == second)
                {
                    fulltimeCheckBool = true;
                    return true;
                }
            }
            else if (day != 0 && hour != 0 && minute != 0)
            {
                if (Day == day && Hour == hour && Minute == minute)
                {
                    fulltimeCheckBool = true;
                    return true;
                }
            }
            else if (day != 0 && hour != 0)
            {

                if (Day == day && Hour == hour)
                {
                    fulltimeCheckBool = true;
                    return true;
                }

            }
            else if (day != 0)
            {

                if (Day == day)
                {
                    fulltimeCheckBool = true;
                    return true;
                }

            }
            else if (hour != 0 && minute != 0 && second != 0)
            {
                if (Hour == hour && Minute == minute && (int)Second == second)
                {
                    fulltimeCheckBool = true;
                    return true;
                }

            }
            else if (hour != 0 && minute != 0)
            {
                if (Hour == hour && Minute == minute)
                {
                    fulltimeCheckBool = true;
                    return true;
                }

            }
            else if (hour != 0)
            {
                if (Hour == hour)
                {
                    fulltimeCheckBool = true;
                    return true;
                }
            }
            else if (minute != 0 && second != 0)
            {
                if (Minute == minute && (int)Second == second)
                {
                    fulltimeCheckBool = true;
                    return true;
                }
            }
            else if (minute != 0)
            {
                if (Minute == minute)
                {
                    fulltimeCheckBool = true;
                    return true;
                }
            }
            else if (second != 0)
            {
                if ((int)Second == second)
                {
                    fulltimeCheckBool = true;
                    return true;
                }
            }
        }
        return false;
    }
    public string GetTimeString()
    {
        var timestring = System.String.Format("{0}:{1:00}:{2:00}", Hour, Minute, Second);
        return timestring;
    }
}

