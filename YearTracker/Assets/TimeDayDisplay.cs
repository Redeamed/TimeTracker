using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TimeDayDisplay : MonoBehaviour
{
    Text text;
    string[] weekDays;
    string[] seasons;

    string season;
    string day;
    string time;
    public int temp;
    void Awake()
    {
        text = GetComponent<Text>();
        weekDays = new string[8];
        weekDays[0] = "Sunday";
        weekDays[1] = "Monday";
        weekDays[2] = "Tuesday";
        weekDays[3] = "Wednesday";
        weekDays[4] = "Thursday";
        weekDays[5] = "Friday";
        weekDays[6] = "Satday";
        weekDays[7] = "New Years day";
        seasons = new string[(int)Months.Winter+1];
        seasons[0] = "Spring";
        seasons[1] = "Summer";
        seasons[2] = "Fall";
        seasons[3] = "Winter";
    }
    void Start()
    {
        CalanderScript.instance.nextAction += Action;
        CalanderScript.instance.newDayDel += UpdateDay;
        day = weekDays[0];
        season = seasons[0];
        UpdateTime();
        DisplayTime();
    }

    public void Action()
    {
        
        UpdateTime();
        DisplayTime();
    }
    public void UpdateDay(Days newDay)
    {
        temp = (int)(newDay);
        day = weekDays[temp];

    }
    void UpdateTime()
    {
        int hours = 0;
        int minutes = CalanderScript.instance.minuteTime;

        while (minutes >= CalanderScript.MINUTESPERHOUR)
        {
            hours++;
            minutes -= CalanderScript.MINUTESPERHOUR;
        }
        time = hours + ":" + minutes;
    }
    void UpdateSeason(Months value)
    {
        
    }
    void DisplayTime()
    {
        text.text = "Season: " + season + "\n" + "Day: " + day + "\n" + "Time: " + time;
    }


}
