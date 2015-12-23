using UnityEngine;
using System.Collections;

//declare this enum outside of the class so any class can use it
public enum Seasons
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
public struct calTime
{
    public int hour;
    public int minute;
}

public struct calAction
{
   public CalanderScript.BaseDelegate action;
   public calTime duration;
}
public class CalanderScript : MonoBehaviour
{
    public const int YEARLENGTH = 300; //days
    public const int MONTHLENGTH = YEARLENGTH/((int)Seasons.Winter +1);//days
    public const int WEEKLENGTH = 7;//days

    public const int DAYLENGTH = 24; //hours
    public const int MINUTESPERHOUR = 60; // minutes
    public const int ACTIONSPER = 10; //in minutes

    public const int ACTIONSPERDAY = DAYLENGTH / ACTIONSPER;//frequency of actions to be replaced?


    public static CalanderScript instance;
    public delegate void BaseDelegate();
    public event BaseDelegate nextAction;

    public delegate void TimeDelegate(calTime gtime);
    public event TimeDelegate EvUpdateTime;

    public delegate void DayDelegate(Days newDay);
    public event DayDelegate newDayDel;


    public int dayOfYear = 1;
    private calTime gTime;

    //public Days[] weekDays;
    public Days dayOfTheWeek;

    public Days currentDay;

    void Awake()
    {
        gTime = new calTime ();
        gTime.hour = 0;
        gTime.minute = 0;

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
        gTime.minute++;
        //Debug.Log(minuteTime);
        UpdateTime();

    }
    void UpdateTime()
    {
        if (gTime.minute != 0)
        {
            if ((gTime.minute % ACTIONSPER) == 0)
            {
                #region ////////////////////OLD WAY/////////////////////
                //tell all NPC's to increment to the next state in their day list
                //Time being linear they will always move to the next in the list
                //if (nextAction != null)
                //    nextAction();
                #endregion

                if (EvUpdateTime != null)
                    EvUpdateTime(gTime);
                else
                    Debug.Log("No events for evUpdateTime");
            }
            //update hour
                
            if (gTime.minute % MINUTESPERHOUR == 0)
            {
                gTime.hour++;
                gTime.minute = 0;
            }
            
            //change day
            if (gTime.hour != 0 && gTime.hour % DAYLENGTH == 0)
            {
                dayOfYear++;
                if (dayOfYear > YEARLENGTH) dayOfYear = 1;

                gTime.hour = 0;

                dayOfTheWeek = (Days)(((int)dayOfTheWeek + 1) % WEEKLENGTH);

                //for (int i = 0; i < 7; i++)
                
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
}
