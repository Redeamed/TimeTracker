using UnityEngine;
using System.Collections;

public class Scr_Sun : MonoBehaviour {
    OtherCalandarUnit calandarUnit;
	// Use this for initialization
	void Awake ()
    {
        calandarUnit = GetComponent<OtherCalandarUnit>();
	}
	
	void Start ()
    {
        for (int i = 0; i < calandarUnit.WeekdayActions.Length; ++i)
        {
            for (int j = 0; j < calandarUnit.WeekdayActions[i].Length; ++j)
            {
                calandarUnit.WeekdayActions[i][j] += Rotate;
            }
        }
    }

    void Rotate()
    {
        transform.Rotate(Vector3.forward, 360.0f / (float)calandarUnit.WeekdayActions[0].Length);
    }
}
