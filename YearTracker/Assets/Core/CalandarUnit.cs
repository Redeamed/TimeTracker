using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CalandarUnit : MonoBehaviour
{
    public calAction currentAction;
    int actionValue = 0;
    calTime targetTime;
    public List<calAction> currentActions;

    public List<List<calAction>> dayActions;

    //based on what we discussed in steam they could each hold there own list title by day types to switch to.
    //this may mean a switch statement on the other side for the possible days and which to switch to by it will be much neater than nestest switches.
    void Awake()
    {
        targetTime = new calTime();

        #region ///////////////OLDWAY//////////////////
        //initialize week day events
        //WeekdayActions = new CalanderScript.BaseDelegate[CalanderScript.WEEKLENGTH][];
        //for (int i = 0; i < CalanderScript.WEEKLENGTH; ++i)
        //{
        //    //initialize for number of action changes per day
        //    WeekdayActions[i] = new CalanderScript.BaseDelegate[CalanderScript.ACTIONSPERDAY];
        //}
        //
        //NewYearsActions = new CalanderScript.BaseDelegate[CalanderScript.ACTIONSPERDAY];
        //
        //currentActions = WeekdayActions[0];
        //
        //currentAction = currentActions[0];
        #endregion
        //initialize week day events
        dayActions = new List<List<calAction>>();
       for (int i = 0; i < CalanderScript.WEEKLENGTH; ++i)
       {
           //initialize for number of action changes per day
           dayActions.Add(new List<calAction>());
            dayActions[i].Add(new calAction());
            
       }
        List<calAction> special = new List<calAction>();
        special.Add(new calAction());
        dayActions.Add(special);

        currentActions = dayActions[0];
        currentAction = currentActions[0];

        if (currentAction.action != null)
        {
            currentAction.action();
            TargetTimeSet(new calTime());
        }
        else
        {
            targetTime.hour = 0;
            targetTime.minute = 0;
        }
    }
    
    void Start()
    {

        CalanderScript.instance.newDayDel += NewDay;
        //CalanderScript.instance.nextAction += ActionIncrement;

        CalanderScript.instance.EvUpdateTime += NextAction;
    }

    public void NextAction(calTime gTime)
    {
        if (targetTime.hour >= gTime.hour &&
            targetTime.minute >= gTime.minute)
        {
            actionValue++;
        }
        ActionSet(actionValue, gTime);

    }
    public void ActionSet(int value, calTime gTime)
    {
        if (value < CalanderScript.ACTIONSPERDAY)
        {
            currentAction = currentActions[value];
            if (currentAction.action != null)
            {
                currentAction.action();
                TargetTimeSet(gTime);
            }
        }
        else
        {
            Debug.Log("Action Set Value out of range: " + value);
        }

    }
    //in the NPCUnit class something like
    public void NewDay(Days newDay)
    {

        currentActions = dayActions[(int)newDay];

        //What if no schedule for special day?


        #region //////////////////OLD WAY/////////////
        //if ((int)newDay < CalanderScript.WEEKLENGTH)
        //{
        //    currentActions = dayActions[(int)newDay];
        //    
        //}
        //else
        //{
        //
        //    switch (newDay)
        //    {
        //        case Days.NewYears:
        //            currentActions = dayActions[((int)newDay)];
        //            break;
        //        default:
        //            Debug.Log("Day unidentified");
        //            break;
        //    }
        //}
        //
        //ActionSet(0);
        #endregion
    }

    public void TargetTimeSet(calTime gTime)
    {

        targetTime.hour = gTime.hour + currentAction.duration.hour;
        targetTime.minute = gTime.minute + currentAction.duration.minute;

    }
}
