using UnityEngine;
using System.Collections;

public class Scr_Sun : MonoBehaviour {
    CalandarUnit calandarUnit;
    float minutesPerDay;
	// Use this for initialization
	void Awake ()
    {
        calandarUnit = GetComponent<CalandarUnit>();
	}
	
	void Start ()
    {
        #region oldWay
        //for (int i = 0; i < calandarUnit.dayActions.Length; ++i)
        //{
        //    for (int j = 0; j < calandarUnit.dayActions[i].Length; ++j)
        //    {
        //        calandarUnit.dayActions[i][j] += Rotate;
        //    }
        //}
        #endregion
        minutesPerDay = (float)(CalanderScript.DAYLENGTH * CalanderScript.MINUTESPERHOUR);
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(Vector3.forward, 360.0f / minutesPerDay);
        
    }
}
