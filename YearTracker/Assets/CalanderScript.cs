using UnityEngine;
using System.Collections;

//declare this enum outside of the class so any class can use it
public enum Months
{
    Spring,
    Summer,
    Fall,
    Winter

}
//declare this enum outside of the class so any class can use it
public enum Days
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        NewYears

    }

public class CalanderScript : MonoBehaviour
{
    public const int YEARLENGTH = 300; //days
    public const int MONTHLENGTH = YEARLENGTH/((int)Months.Winter +1);//days
    public const int WEEKLENGTH = 7;//days
    public const int DAYLENGTH = 1440; //minutes
    public const int MINUTESPERHOUR = 60; // minutes
    public const int ACTIONSPER = 10; //in minutes
    public const int ACTIONSPERDAY = DAYLENGTH / ACTIONSPER;//new action every 10 minutes over 24 hours

    public static CalanderScript instance;
    public delegate void BaseDelegate();
    public event BaseDelegate nextAction;
    public delegate void DayDelegate(Days newDay);
    public event DayDelegate newDayDel;


    public int dayOfYear = 1;
    public int minuteTime = 0;

    //public Days[] weekDays;
    public Days dayOfTheWeek;

    public Days currentDay;

    void Awake()
    {
        instance = this;
        //weekDays = new Days[7];
        //
        //weekDays[0] = Days.Sunday;
        //weekDays[1] = Days.Monday;
        //weekDays[2] = Days.Tuesday;
        //weekDays[3] = Days.Wednesday;
        //weekDays[4] = Days.Thursday;
        //weekDays[5] = Days.Friday;
        //weekDays[6] = Days.Saturday;

    }
    void Update()
    {
        minuteTime++;
        //Debug.Log(minuteTime);
        UpdateTime();

    }
    void UpdateTime()
    {
        if (minuteTime != 0 && (minuteTime % ACTIONSPER) == 0)
        {
            //tell all NPC's to increment to the next state in their day list
            //Time being linear they will always move to the next in the list
            if (nextAction != null)
                nextAction();
        }

        //change day
        if (minuteTime != 0 && minuteTime % DAYLENGTH == 0)
        {
            dayOfYear++;
            if (dayOfYear > YEARLENGTH) dayOfYear = 1;
            minuteTime = 0;

            dayOfTheWeek = (Days)(((int)dayOfTheWeek + 1) % WEEKLENGTH);

           //for (int i = 0; i < 7; i++)
           //{
           //    //find the current day of the week in the list
           //    if (dayOfTheWeek == weekDays[i])
           //    {
           //        //increment the day if possible
           //        if (i + 1 < 7)
           //            dayOfTheWeek = weekDays[i + 1];
           //        //if not reset the week
           //        else dayOfTheWeek = weekDays[0];
           //
           //        break;
           //    }
           //}
            //is the day special?
            switch (dayOfYear)
            {
                case YEARLENGTH:
                    currentDay = Days.NewYears;
                    break;
                default:
                    currentDay = dayOfTheWeek;
                    break;
            }


            ///tell all NPC units to switch to their DayPosition list for the given day something like
            if (newDayDel != null)
                newDayDel(currentDay);


        }
    }
}
