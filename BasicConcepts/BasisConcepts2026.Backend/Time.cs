namespace BasisConcepts2026.Backend;

public class Time
// Fields
{
    private int _hours;
    private int _milliSeconds;
    private int _minutes;
    private int _seconds;
    // Constructors
    public Time()
    {
        _hours = 0;
        _milliSeconds = 0;
        _minutes = 0;
        _seconds = 0;
    }
    public Time(int hours)
    {
        Hours = hours;
    }

    public Time(int hours, int minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }

    public Time(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        
    }

    public Time(int hours, int minutes, int seconds, int milliSeconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        MilliSeconds = milliSeconds;
    }


    // Properties
    public int Hours
    {
        get => _hours;
        set => _hours = ValidHours(value);
    }
    public int MilliSeconds
    {
        get => _milliSeconds;
        set => _milliSeconds = ValidMillisecond(value);
    }
    public int Minutes
    {
        get => _minutes;
        set => _minutes = ValidMinutes(value);
    }
    public int Seconds
    {
        get => _seconds;
        set => _seconds = ValidSecond(value);
    }
    // Methods

    public Time Add(Time other)
    {
        int tmillisecond =this.ToMilliseconds() + other.ToMilliseconds();
        tmillisecond %= 24 * 3600000;
        int hour = (tmillisecond / 3600000);
        int minute = (tmillisecond / 60000) % 60;
        int second = (tmillisecond / 1000) % 60;
        int millisecond = (tmillisecond % 1000);


        return new Time(hour, minute, second, millisecond);
    }
    public bool IsOtherDay(Time other)
    {
        int totalMilliseconds = this.ToMilliseconds() + other.ToMilliseconds();
        if (totalMilliseconds >= 24 * 3600000)
        {
            return true;
        }
            return false;
    }
    public int ToMilliseconds()
    {
        if (Hours < 0 || Hours > 23)
        {
            return  0;
        }
        if (Minutes < 0 || Minutes > 59)
        {
            return 0;
        }
        if (Seconds < 0 || Seconds > 59)
        {
            return 0;
        }
        if (MilliSeconds < 0 || MilliSeconds > 999)
        {
            return 0;
        }   
        return (Hours * 3600000)
             + (Minutes * 60000)
             + (Seconds * 1000)
             + MilliSeconds;
    }
    public int ToMinutes()
    {
        if (Hours < 0 || Hours > 23)
        {
            return 0;
        }
        if (Minutes < 0 || Minutes > 59)
        {
            return 0;
        }
        if (Seconds < 0 || Seconds > 59)
        {
            return 0;
        }
        if (MilliSeconds < 0 || MilliSeconds > 999)
        {
            return 0;
        }
        return (Hours * 60) + Minutes + (Seconds / 60) + (MilliSeconds / 60000);
    }
    public int ToSeconds()
    {
        if (Hours < 0 || Hours > 23)
        {
            return 0;
        }
        if (Minutes < 0 || Minutes > 59)
        {
            return 0;
        }
        if (Seconds < 0 || Seconds > 59)
        {
            return 0;
        }
        if (MilliSeconds < 0 || MilliSeconds > 999)
        {
            return 0;
        }
        return (Hours * 3600)
             + (Minutes * 60)
             + Seconds
             + (MilliSeconds / 1000);

    }
    public override string ToString()
    {
        if (Hours < 0 || Hours > 23)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (Minutes < 0 || Minutes > 59)
        {
            throw new ArgumentOutOfRangeException();

        }
        if (Seconds < 0 || Seconds > 59)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (MilliSeconds < 0 || MilliSeconds > 999)
        {
            throw new ArgumentOutOfRangeException();
        }
        int hour12 = Hours % 12;
        if (hour12 == 0)
            hour12 = 12;

        string period = Hours < 12 ? "AM" : "PM";

        return $"{hour12:00}:{Minutes:00}:{Seconds:00}.{MilliSeconds:000} {period}";
    }
    private int ValidHours(int hours)
    {
        if (hours < 0 || hours > 23)
        {  
            throw new ArgumentOutOfRangeException(nameof(hours), $"The hour: {hours}, Is not valid");
        }
        return hours;
    }

    private int ValidMinutes(int minutes)
    {
        if (minutes < 0 || minutes > 59)
        {
            throw new ArgumentOutOfRangeException(nameof(minutes), $"The minutes: {minutes}, Is not valid");
        }
        return minutes;
    }

    private int ValidSecond(int seconds)
    {
        if (seconds < 0 || seconds > 59)
        {
            throw new ArgumentOutOfRangeException(nameof(seconds), $"The seconds: {seconds}, Is not valid");
        }
        return seconds;
    }

    private int ValidMillisecond(int milliseconds)
    {
        if (milliseconds < 0 || milliseconds > 999)
        {
            throw new ArgumentOutOfRangeException(nameof(milliseconds), $"The milliseconds: {milliseconds}, Is not valid.");
        }
        return milliseconds;
    }

}

