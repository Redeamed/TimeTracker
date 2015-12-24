using UnityEngine;
using System.Collections;

public class scrCharacter : MonoBehaviour {
    CalandarUnit calandarUnit;
    scrMove scrmove;

    public int targetValue = -1;
    public Transform[] targets;
    public Transform door;

	// Use this for initialization
	void Awake ()
    {
        calandarUnit = this.GetComponent<CalandarUnit>();
        scrmove = this.GetComponent<scrMove>();
	}

    void Start()
    {

        calAction workingAction;
        #region Sunday SetUp
        for (int i = 0; i < 7; ++i)
        {
        workingAction = new calAction();
        workingAction.action += DoNothing;
        workingAction.duration = new calTime();
        workingAction.duration.hour = 6;
        workingAction.duration.minute = 0;
        calandarUnit.dayActions[i].Add(workingAction);

        workingAction = new calAction();
        workingAction.duration = new calTime();
        workingAction.action += NextPosition;
        workingAction.duration.hour = 6;
        workingAction.duration.minute = 0;
        calandarUnit.dayActions[i].Add(workingAction);

        workingAction = new calAction();
        workingAction.duration = new calTime();
        workingAction.action += NextPosition;
        workingAction.duration.hour = 6;
        workingAction.duration.minute = 0;
        calandarUnit.dayActions[i].Add(workingAction);

        workingAction = new calAction();
        workingAction.duration = new calTime();
        workingAction.action += NextPosition;
        workingAction.duration.hour = 6;
        workingAction.duration.minute = 0;
        calandarUnit.dayActions[i].Add(workingAction);
    }
        #endregion
    }
    public void DoNothing()
    {
        //Do Nothing
    }

    public void NextPosition()
    {
        targetValue++;
        if (targetValue >= targets.Length)
        {
            scrmove.SetTarget(door);
            targetValue = -1 sadqwqdwwwew;
        }
        else
        {
            scrmove.SetTarget(targets[targetValue]);

        }
    }
}
