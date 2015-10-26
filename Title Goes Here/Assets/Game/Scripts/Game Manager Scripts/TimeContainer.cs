﻿using UnityEngine;

/// <summary>
/// This is the Time Container class, This class holds time variables and methods used for custom timers and custom clocks.
/// </summary>
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
    /// this the Expanded Time Container, you can choose which values to set to default including the default time counting format.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="week"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <param name="timescale"></param>
    /// <param name="secondsInMinute"></param>
    /// <param name="minutesinhour"></param>
    /// <param name="hoursinday"></param>
    /// <param name="daysinweek"></param>
    /// <param name="weeksinmonth"></param>
    /// <param name="monthsinyear"></param>
    public TimeContainer(
        int year = 0,
        int month = 0,
        int week = 0,
        int day = 0,
        int hour = 0,
        int minute = 0,
        float second = 0,
        float timescale = 1,
        int secondsInMinute = 60,
        int minutesinhour = 60,
        int hoursinday = 24,
        int daysinweek = 7,
        int weeksinmonth = 4,
        int monthsinyear = 12
        )
    {
        Year = year;
        Month = month;
        Week = week;
        Day = day;
        Hour = hour;
        Minute = minute;
        Second = second;
        TimeScale = timescale;
        SecondsInMinute = secondsInMinute;
        MinutesInHour = minutesinhour;
        HoursInDay = hoursinday;
        DaysInWeek = daysinweek;
        WeeksInMonth = weeksinmonth;
        MonthsInYear = monthsinyear;
    }

    /// <summary>
    /// This sets the Seconds to Time.deltaTime * TimeScale. This effectively will set the proper second value when called in update.
    /// This class also checks the time counting to make sure that after 60 seconds 1 minute is added (by default) and 60 Minutes adds 1 hour, etc etc.
    /// (Must be called in Update for the Time to be properly set.)
    /// </summary>
    /// <returns></returns>
    public virtual bool StartTime()
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

    /// <summary>
    /// This will check the Day and return true or false based on the check.
    /// </summary>
    /// <param name="day"></param>
    /// <returns></returns>
    public virtual bool CheckDay(int day)
    {
        if (dayCheckBool == false && Day == day)
        {
            dayCheckBool = true;
            return true;
        }
        return false;
    }

    /// <summary>
    /// This will check the Hour and return true or false based on the check.
    /// </summary>
    /// <param name="hour"></param>
    /// <returns></returns>
    public virtual bool CheckHour(int hour)
    {
        if (hourCheckBool == false && Hour == hour)
        {
            hourCheckBool = true;
            return true;
        }
        return false;
    }

    /// <summary>
    /// This will check the Minute and return true or false based on the check.
    /// </summary>
    /// <param name="minute"></param>
    /// <returns></returns>
    public virtual bool CheckMinute(int minute)
    {
        if (minuteCheckBool == false && Minute == minute)
        {
            minuteCheckBool = true;
            return true;
        }
        return false;
    }

    /// <summary>
    /// This will check the Second and return true or false based on the check.
    /// </summary>
    /// <param name="second"></param>
    /// <returns></returns>
    public virtual bool CheckSecond(int second)
    {        
        if ((int)Second == second)
        {
//            secondCheckBool = true;
            return true;
        }
        return false;

    }
    /// <summary>
    /// This will check the time provided and return true or false based on the check. This has optional parameters that can be called like this
    /// EXAMPLE: CheckFullTIme(day:5,minute:30); - This will check to make sure Day 5 and 30 Minutes is true and execute.
    /// Passing -1 on a parameter will always evaluate the selected check to true for the check call.
    /// </summary>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public virtual bool CheckFullTime(int day = -1, int hour = -1, int minute = -1, int second = -1)
    {
        bool daychecked = Day == day;
        bool hourchecked = Hour == hour;
        bool minutechecked = Minute == minute;
        bool secondchecked = (int)Second == second;

        if (day == -1)
        {
            daychecked = true;
        }
        if (hour == -1)
        {
            hourchecked = true;
        }
        if (minute == -1)
        {
            minutechecked = true;
        }
        if (second == -1)
        {
            secondchecked = true;
        }
            if (daychecked && hourchecked && minutechecked && secondchecked)
            {
                return true;
            }

        return false;
    }
//    public virtual bool CheckFullTime(int day = 0, int hour = 0, int minute = 0, int second = 0)
//    {
//        if (fulltimeCheckBool == false)
//        {
//            if (day != 0 && hour != 0 && minute != 0 && second != 0)
//            {
//                if (Day == day && Hour == hour && Minute == minute && (int)Second == second)
//                {
//                    fulltimeCheckBool = true;
//                    return true;
//                }
//            }
//            else if (day != 0 && hour != 0 && minute != 0)
//            {
//                if (Day == day && Hour == hour && Minute == minute)
//                {
//                    fulltimeCheckBool = true;
//                    return true;
//                }
//            }
//            else if (day != 0 && hour != 0)
//            {
//
//                if (Day == day && Hour == hour)
//                {
//                    fulltimeCheckBool = true;
//                    return true;
//                }
//
//            }
//            else if (day != 0)
//            {
//
//                if (Day == day)
//                {
//                    fulltimeCheckBool = true;
//                    return true;
//                }
//
//            }
//            else if (hour != 0 && minute != 0 && second != 0)
//            {
//                if (Hour == hour && Minute == minute && (int)Second == second)
//                {
//                    fulltimeCheckBool = true;
//                    return true;
//                }
//
//            }
//            else if (hour != 0 && minute != 0)
//            {
//                if (Hour == hour && Minute == minute)
//                {
//                    fulltimeCheckBool = true;
//                    return true;
//                }
//
//            }
//            else if (hour != 0)
//            {
//                if (Hour == hour)
//                {
//                    fulltimeCheckBool = true;
//                    return true;
//                }
//            }
//            else if (minute != 0 && second != 0)
//            {
//                if (Minute == minute && (int)Second == second)
//                {
//                    fulltimeCheckBool = true;
//                    return true;
//                }
//            }
//            else if (minute != 0)
//            {
//                if (Minute == minute)
//                {
//                    fulltimeCheckBool = true;
//                    return true;
//                }
//            }
//            else if (second != 0)
//            {
//                if ((int)Second == second)
//                {
//                    fulltimeCheckBool = true;
//                    return true;
//                }
//            }
//        }
//        fulltimeCheckBool = false;
//        return false;
//    }

    public bool CheckExactFullTime(int day = 0, int hour = 0, int minute = 0, int second = 0)
    {
        if (fulltimeCheckBool == false)
        {
            if (Day == day && Hour == hour && Minute == minute && (int)Second == second)
            {
                Debug.Log("Time is Exactly Day: " + day + " Hour: " + hour + " Minute: " + minute + " Second: " + second);
                fulltimeCheckBool = true;
                return true;
            }
        }
        fulltimeCheckBool = false;
        return false;
    }
    /// <summary>
    /// This formats the time like so EXAMPLE: H:MM:SS  
    /// </summary>
    /// <returns></returns>
    public virtual string GetTimeString()
    {
        var timestring = System.String.Format("{0}:{1:00}:{2:00}", Hour, Minute, Second);
        return timestring;
    }

    public virtual void ClearAllChecks()
    {
        secondCheckBool = false;
        minuteCheckBool = false;
        hourCheckBool = false;
        dayCheckBool = false;
        weekCheckBool = false;
        monthCheckBool = false;
        yearCheckBool = false;
        fulltimeCheckBool = false;
    }
}

