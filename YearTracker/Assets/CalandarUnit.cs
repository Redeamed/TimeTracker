using UnityEngine;
using System.Collections;

public class CalandarUnit : MonoBehaviour {

    CalanderScript.BaseDelegate currentDay;
    
    CalanderScript.BaseDelegate currentAction;
    int actionValue = 0;

    CalanderScript.BaseDelegate[] currentActions;

    CalanderScript.BaseDelegate[] SundayActions;
    CalanderScript.BaseDelegate[] MondayActions;
    //based on what we discussed in steam they could each hold there own list title by day types to switch to.
    //this may mean a switch statement on the other side for the possible days and which to switch to by it will be much neater than nestest switches.
    void Awake()
    {
        currentDay = SundayUpdate;
        SundayActions = new CalanderScript.BaseDelegate[CalanderScript.ACTIONSPERDAY];
        for (int i = 0; i < CalanderScript.ACTIONSPERDAY; ++i)
        {
            if (i < CalanderScript.ACTIONSPERDAY * (1.0f / 3.0f))
                SundayActions[i] = Action1;
            else if (i < CalanderScript.ACTIONSPERDAY * (2.0f / 3.0f))
                SundayActions[i] = Action2;
            else
                SundayActions[i] = Action3;
        }

        MondayActions = new CalanderScript.BaseDelegate[CalanderScript.ACTIONSPERDAY];
        for (int i = 0; i < CalanderScript.ACTIONSPERDAY; ++i)
        {
            if (i < CalanderScript.ACTIONSPERDAY * (1.0f / 3.0f))
                MondayActions[i] = Action3;
            else if (i < CalanderScript.ACTIONSPERDAY * (2.0f / 3.0f))
                MondayActions[i] = Action2;
            else
                MondayActions[i] = Action1;
        }

        currentActions = SundayActions;

    }
    void Action1()
    {
        Debug.Log(currentDay + " Action1");
        transform.position += Vector3.right * 0.1f;
    }
    void Action2()
    {
        Debug.Log(currentDay + " Action2");
        transform.position += Vector3.right * -0.1f;
    }
    void Action3()
    {
        Debug.Log(currentDay + " Action3");
        if (transform.localScale.x == 2)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = Vector3.one * 2;
        }
    }
    void Start()
    {
        CalanderScript.instance.newDayDel += NewDay;
        CalanderScript.instance.nextAction += ActionUpdate;
    }
    public void SundayUpdate()
    {
        Debug.Log("Sunday");
    }
    public void MondayUpdate()
    {
        Debug.Log("Monday");
    }
    public void TuesdayUpdate()
    {
        Debug.Log("Tuesday");
    }
    public void WednesdayUpdate()
    {
        Debug.Log("Wednesday");
    }
    public void ThursdayUpdate()
    {
        Debug.Log("Thursday");
    }
    public void FridayUpdate()
    {
        Debug.Log("Friday");
    }
    public void SaturdayUpdate()
    {
        Debug.Log("Saturday");
    }
    public void NewYearsUpdate()
    {
        Debug.Log("New Years");
    }

    public void ActionUpdate()
    {
        actionValue++;
        if (actionValue >= CalanderScript.ACTIONSPERDAY) actionValue = 0;

        currentAction = currentActions[actionValue];
        currentAction();
    }
    //in the NPCUnit class something like
    public void NewDay(Days newDay)
    {
       
        switch (newDay)
        {

            case Days.Sunday:
                currentDay = SundayUpdate;
                currentActions = SundayActions;
                break;
            case Days.Monday:
                currentDay = MondayUpdate;
                currentActions = MondayActions;
                break;
            case Days.Tuesday:
                currentDay = TuesdayUpdate;
                break;
            case Days.Wednesday:
                currentDay = WednesdayUpdate;
                break;
            case Days.Thursday:
                currentDay = ThursdayUpdate;
                break;
            case Days.Friday:
                currentDay = FridayUpdate;
                break;
            case Days.Saturday:
                currentDay = SundayUpdate;
                break;
            case Days.NewYears:
                currentDay = NewYearsUpdate;
                
                break;
            default:
                Debug.Log("Day unidentified");
                break;
        }

        actionValue = 0;
        currentAction = currentActions[actionValue];

        currentDay();
    }
}
