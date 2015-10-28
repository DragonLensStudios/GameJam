/// <summary>
/// This is the Time Container class, This class holds time variables and methods used for custom timers and custom clocks.
/// </summary>
[System.Serializable]
public class TimeContainer
{
    public Days CurrentDay = Days.Monday;
    public Months CurrentMonth = Months.January;
    public int Year = 1;
    public int Month = 1;
    public int Week = 1;
    public int Day = 1;
    public int Hour = 1;
    public int Minute = 0;
    public float Second = 0;
    public float TimeScale = 1;
    public int SecondsInMinute = 60;
    public int MinutesInHour = 60;
    public int HoursInDay = 24;
    public int DaysInMonth = 30;
    public int MonthsInYear = 12;

    /// <summary>
    /// <para>This is class is responsible for being used as a container for a custom timer, you can Initialize optional variables for this time class.</para>
    /// <para>You can set values for example like so: [EXAMPLE: new TimeContainer(timescale: 60, day: 5, currentday: Days.Monday)] This will set the timescale to 60 and the day count to 5 and the currentday to Monday</para>
    /// <para>You can set the Following Values: Year, Month, Week, Day, Hour, Minute, Second, Time, SecondsInMinute, MinutesInHour, HoursInDay, DaysInMonth, MonthsInYear, CurrentDay, CurrentMonth if you do not set any of these values they will retain their default values.</para>
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
    /// <param name="daysinmonth"></param>
    /// <param name="monthsinyear"></param>
    /// <param name="currentday"></param>
    /// <param name="currentmonth"></param>

    public TimeContainer(
        int year = 1,
        int month = 1,
        int week = 1,
        int day = 1,
        int hour = 1,
        int minute = 0,
        float second = 0,
        float timescale = 1,
        int secondsInMinute = 60,
        int minutesinhour = 60,
        int hoursinday = 24,
        int daysinmonth = 30,
        int monthsinyear = 12,
        Days currentday = Days.Monday,
        Months currentmonth = Months.January
        )
    {
        Year = year;
        Week = week;
        Day = day;
        Hour = hour;
        Minute = minute;
        Second = second;
        TimeScale = timescale;
        SecondsInMinute = secondsInMinute;
        MinutesInHour = minutesinhour;
        HoursInDay = hoursinday;
        DaysInMonth = daysinmonth;
        MonthsInYear = monthsinyear;
        CurrentDay = currentday;
        if (currentmonth != Months.January)
        {
            Month = (int)currentmonth;
            CurrentMonth = currentmonth;
        }
        else if (month != 1)
        {
            Month = month;
            CurrentMonth = (Months)month;
        }
        ValidateTime();
    }

    /// <summary>
    /// This sets the Seconds to Time.deltaTime * TimeScale. This effectively will set the proper second value when called in update.
    /// this method also calls ValidateTime. <see cref="ValidateTime"/>
    /// (Must be called in Update for the Time to be properly set.)
    /// </summary>
    /// <returns></returns>
    public virtual void StartTime()
    {
        Second += UnityEngine.Time.deltaTime * TimeScale;
        ValidateTime();
    }

    /// <summary>
    /// This method checks the time counting to make sure that after 60 seconds 1 minute is added (by default) and 60 Minutes adds 1 hour, etc etc.
    /// </summary>
    public virtual void ValidateTime()
    {
        Month = (int)CurrentMonth;

        if (Second >= SecondsInMinute)
        {
            Second = 0;
            Minute++;
        }
        if (Minute >= MinutesInHour)
        {
            Minute = 0;
            Hour++;
        }
        if (Hour >= HoursInDay)
        {
            Hour = 1;
            if (CurrentDay == Days.Sunday)
            {
                CurrentDay = Days.Monday;
                Week++;
            }
            else
            {
                CurrentDay++;
            }
            Day++;

        }

        if (Day > DaysInMonth )
        {
            Week = 1;
            Day = 1;
            if (CurrentMonth == Months.December)
            {
                CurrentMonth = Months.January;
            }
            else
            {
                CurrentMonth++;
            }
            Month++;
        }
        if (Month > MonthsInYear)
        {
            Month = 1;
            Year++;
        }

    }

    /// <summary>
    /// This will check the time provided and return true or false based on the check. This has optional parameters that can be called like this
    /// EXAMPLE: CheckFullTIme(day:5,minute:30); - This will check to make sure Day 5 and 30 Minutes is true and execute.
    /// Passing -1 on a parameter will always evaluate the selected check to true for the check call.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="week"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public virtual bool CheckTime(int year =1, int month = -1, int week = -1,int day = -1, int hour = -1, int minute = -1, int second = -1)
    {
        bool yearchecked = Year == year;
        bool monthchecked = Month == month;
        bool weekchecked = Week == week;
        bool daychecked = Day == day;
        bool hourchecked = Hour == hour;
        bool minutechecked = Minute == minute;
        bool secondchecked = (int)Second == second;

        if (year == -1)
        {
            yearchecked = true;
        }
        if (month == -1)
        {
            monthchecked = true;
        }
        if (week == -1)
        {
            weekchecked = true;
        }
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
            if (yearchecked && monthchecked && weekchecked && daychecked && hourchecked && minutechecked && secondchecked)
            {
                return true;
            }

        return false;
    }

    /// <summary>
    /// <para>Checks the Exact Second.</para>
    /// Returns True if the time has been reached otherwise returns False.
    /// </summary>
    /// <param name="second"></param>
    /// <returns></returns>
    public bool CheckExactTime(int second)
    {
        if ((int)Second == second)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// <para>Checks the Exact Minute, Second.</para>
    /// Returns True if the time has been reached otherwise returns False.
    /// </summary>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public bool CheckExactTime(int minute, int second)
    {
        if (Minute == minute && (int)Second == second)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// <para>Checks the Exact Hour, Minute, Second.</para>
    /// Returns True if the time has been reached otherwise returns False.
    /// </summary>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns>test</returns>
    public bool CheckExactTime(int hour, int minute, int second)
    {
            if (Hour == hour && Minute == minute && (int)Second == second)
            {
                return true;
            }        
        return false;
    }
    /// <summary>
    /// <para>Checks the Exact Day, Hour, Minute, Second.</para>
    /// Returns True if the time has been reached otherwise returns False.
    /// </summary>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public bool CheckExactTime(int day, int hour, int minute, int second)
    {
        if (Day == day && Hour == hour && Minute == minute && (int)Second == second)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// <para>Checks the Exact Week, Day, Hour, Minute, Second.</para>
    /// Returns True if the time has been reached otherwise returns False.
    /// </summary>
    /// <param name="week"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public bool CheckExactTime(int week, int day, int hour, int minute, int second)
    {
        if (Week == week && Day == day && Hour == hour && Minute == minute && (int)Second == second)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// <para>Checks the Exact Month, Week, Day, Hour, Minute, Second.</para>
    /// Returns True if the time has been reached otherwise returns False.
    /// </summary>
    /// <param name="month"></param>
    /// <param name="week"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public bool CheckExactTime(int month, int week, int day, int hour, int minute, int second)
    {
        if (Month == month && Week == week && Day == day && Hour == hour && Minute == minute && (int)Second == second)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// <para>Checks the Exact Year, Month, Week, Day, Hour, Minute, Second.</para>
    /// Returns True if the time has been reached otherwise returns False.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="week"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public bool CheckExactTime(int year, int month, int week, int day, int hour, int minute, int second)
    {
        if (Month == month && Week == week && Day == day && Hour == hour && Minute == minute && (int)Second == second)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// <para>Returns a time string formatted like: H:MM:SS  [EXAMPLE: 2:15:30 12/25/2015]</para>
    /// This returns a string containing Hour, Minute, Second  
    /// </summary>
    /// <returns></returns>
    public virtual string GetTimeString()
    {
        return System.String.Format("{0}:{1:00}:{2:00}", Hour, Minute, Second);
    }

    /// <summary>
    /// <para>Returns a time string formatted like: H:MM:SS M/D/Y [EXAMPLE: 2:15:30 12/25/2015] </para>
    /// This returns a string containing Year, Month, Day, Hour, Minute, Second
    /// </summary>
    /// <returns></returns>
    public virtual string GetFullTimeString()
    {
        var timestring = System.String.Format("{0}:{1:00}:{2:00} {3}/{4}/{5}", Hour, Minute, Second, Month, Day, Year);
        return timestring;
        
    }
}

