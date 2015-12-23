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
        weekDays = new string[(int)Days.NewYears + 1];
        weekDays[0] = "Sunday";
        weekDays[1] = "Monday";
        weekDays[2] = "Tuesday";
        weekDays[3] = "Wednesday";
        weekDays[4] = "Thursday";
        weekDays[5] = "Friday";
        weekDays[6] = "Satday";
        weekDays[7] = "New Years day";
        seasons = new string[(int)Seasons.Winter+1];
        seasons[0] = "Spring";
        seasons[1] = "Summer";
        seasons[2] = "Fall";
        seasons[3] = "Winter";
    }
    void Start()
    {
        CalanderScript.instance.EvUpdateTime += Action;
        CalanderScript.instance.newDayDel += UpdateDay;

        day = weekDays[0];
        season = seasons[0];

        Action(new calTime());
    }
    public void Action(calTime gTime)
    {
        UpdateTime(gTime);
        DisplayTime();
    }
    public void UpdateDay(Days newDay)
    {
        temp = (int)(newDay);
        day = weekDays[temp];

    }
    void UpdateTime(calTime gTime)
    {
        int hours   = gTime.hour;
        int minutes = gTime.minute;
        
        time = hours + ":" + minutes;
    }
    void UpdateSeason(Seasons value)
    {
        
    }
    void DisplayTime()
    {
        text.text = "Season: " + season + "\n" + "Day: " + day + "\n" + "Time: " + time;
    }


}
