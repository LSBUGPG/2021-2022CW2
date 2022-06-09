using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timeline : MonoBehaviour
{
    public TextMeshProUGUI[] timeText;
    public TextMeshProUGUI[] dateText;

    public TimeFormat timeFormat = TimeFormat.Hour_24;
    public DateFormat dateFormat = DateFormat.DD_MM_YYYY;
    [SerializeField] float secPerMin = 1;

    string time;
    string date;

    bool isAm;

    int hours;
    int minutes;
    int days;
    int months;
    int years;

    int maxHours = 24;
    int maxMinutes = 60;
    int maxDays = 30;
    int maxMonths = 12;

    float timer = 0;

    public enum TimeFormat
    {
        Hour_24,
        Hour_12
    }

    public enum DateFormat
    {
        DD_MM_YYYY,
        MM_DD_YYYY,
        YYYY_DD_MM,
        YYYY_MM_DD
    }

    void Awake()
    {
        /*
        hours   = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        days    = System.DateTime.Now.Day;
        months  = System.DateTime.Now.Month;
        years   = System.DateTime.Now.Year;
        */

        /*
        hours = System.DateTime.0;
        minutes = System.DateTime.0;
        days = System.DateTime.0;
        months = System.DateTime.0;
        years = System.DateTime.0;
        */

        if (hours < 12)
        {
            isAm = true;
        }
    }

    void Update()
    {
        if (timer >= secPerMin)
        {
            minutes++;
            
            if (minutes >= maxMinutes)
            {
                minutes = 0;
                hours++;

                if (hours >= maxHours)
                {
                    hours = 0;
                    days++;

                    if (days >= maxDays)
                    {
                        days = 1;
                        months++;

                        if (months >= maxMonths)
                        {
                            months = 1;
                            years++;
                        }
                    }
                }
            }

            SetTimeDateString();
            timer = 0;
        }

        else
        {
            timer += Time.deltaTime;
        }
    }

    void SetTimeDateString()
    {
        switch (timeFormat)
        {
            case TimeFormat.Hour_12:
                {
                    int h;

                    if (hours >= 13)
                    {
                        h = hours - 12;
                    }

                    else if (hours == 0)
                    {
                        h = 12;
                    }

                    else
                    {
                        h = hours;
                    }

                    time = h + ":";

                    if (minutes <= 9)
                    {
                        time += "0" + minutes;
                    }

                    else
                    {
                        time += minutes;
                    }

                    if (isAm)
                    {
                        time += " AM";
                    }

                    else
                    {
                        time += " PM";
                    }

                    break;
                }

            case TimeFormat.Hour_24:
                {
                    if (hours <=9)
                    {
                        time = "0" + hours + ":";
                    }

                    else
                    {
                        time = hours + ":";
                    }

                    if (minutes <= 9)
                    {
                        time += "0" + minutes;
                    }

                    else
                    {
                        time += minutes;
                    }

                    break;
                }
        }

        switch (dateFormat)
        {
            case DateFormat.DD_MM_YYYY:
                {
                    date = days + "/" + months + "/" + years;

                    break;
                }

            case DateFormat.MM_DD_YYYY:
                {
                    date = months + "/" + days + "/" + years;

                    break;
                }

            case DateFormat.YYYY_DD_MM:
                {
                    date = years + "/" + days + "/" + months;

                    break;
                }

            case DateFormat.YYYY_MM_DD:
                {
                    date = years + "/" + months + "/" + days;

                    break;
                }
        }

        for (int i = 0; i < timeText.Length; i++)
        {
            timeText[i].text = time;
        }

        for (int i = 0; i < dateText.Length; i++)
        {
            dateText[i].text = date;
        }
    }
}
