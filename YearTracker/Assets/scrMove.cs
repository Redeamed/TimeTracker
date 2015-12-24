using UnityEngine;
using System.Collections;

public class scrMove : MonoBehaviour {
    public float speed = 1.0f;
    public Transform target;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            transform.LookAt(target);
            Vector3 diff = transform.position - target.position;
            Vector3 vel = (diff).normalized * speed * Time.deltaTime;
            if (vel.sqrMagnitude < diff.sqrMagnitude)
                transform.position -= vel;
            else
            {
                transform.position = target.position;
                target = null;
            }
        }
	
	}

    public void SetTarget(Transform trans)
    {
        target = trans;
    }
}
