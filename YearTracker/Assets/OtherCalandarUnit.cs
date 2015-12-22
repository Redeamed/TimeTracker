using UnityEngine;
using System.Collections;

public class OtherCalandarUnit : MonoBehaviour
{
    public CalanderScript.BaseDelegate currentAction;
    int actionValue = 0;

    public CalanderScript.BaseDelegate[] currentActions;

    public CalanderScript.BaseDelegate[][] WeekdayActions;
    public CalanderScript.BaseDelegate[] NewYearsActions;
    //based on what we discussed in steam they could each hold there own list title by day types to switch to.
    //this may mean a switch statement on the other side for the possible days and which to switch to by it will be much neater than nestest switches.
    void Awake()
    {
        //initialize week day events
        WeekdayActions = new CalanderScript.BaseDelegate[CalanderScript.WEEKLENGTH][];
        for (int i = 0; i < CalanderScript.WEEKLENGTH; ++i)
        {
            //initialize for number of action changes per day
            WeekdayActions[i] = new CalanderScript.BaseDelegate[CalanderScript.ACTIONSPERDAY];
        }

        NewYearsActions = new CalanderScript.BaseDelegate[CalanderScript.ACTIONSPERDAY];

        currentActions = WeekdayActions[0];

        currentAction = currentActions[0];

        if (currentAction != null)
            currentAction();
    }
    
    void Start()
    {
        CalanderScript.instance.newDayDel += NewDay;
        CalanderScript.instance.nextAction += ActionIncrement;
    }


    public void ActionIncrement()
    {
        
            actionValue++;
            if (actionValue >= CalanderScript.ACTIONSPERDAY) actionValue = 0;

        currentAction = currentActions[actionValue];
        if(currentAction != null)
        currentAction();

    }
    public void ActionSet(int value)
    {
        if (value > 0 && value < CalanderScript.ACTIONSPERDAY)
        {
            currentAction = currentActions[actionValue];
            currentAction();
        }
        else
        {
            Debug.Log("Action Set Value out of range: " + value);
        }

    }
    //in the NPCUnit class something like
    public void NewDay(Days newDay)
    {
        if ((int)newDay < CalanderScript.WEEKLENGTH)
        {
            currentActions = WeekdayActions[(int)newDay];
            
        }
        else
        {

            switch (newDay)
            {
                case Days.NewYears:
                    currentActions = NewYearsActions;
                    break;
                default:
                    Debug.Log("Day unidentified");
                    break;
            }
        }

        ActionSet(0);
        
    }
}
