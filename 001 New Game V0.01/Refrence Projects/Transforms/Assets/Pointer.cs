using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

    public Transform target;
    public float angle;

    public enum Tracking
    {
        Immediate,
        Delayed,
        ImmediateHorizontal,
        DelayedHorizontal,
    };

    public Tracking tracking;
    public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        switch (tracking)
        {
            case Tracking.Immediate:
                // just point the forward vectorat the target object. The forward setter function
                // automtically normalises it for you
                transform.forward = target.position - transform.position;
                break;

            case Tracking.Delayed:
                {
                    // find the forward vector
                    Vector3 fwd = target.position - transform.position;
                    // get the quaternion corresponding to that forward vector
                    Quaternion towards = Quaternion.LookRotation(fwd);
                    // move towards it at a steady speed 
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, towards, speed * Time.deltaTime);
                }
                break;

            case Tracking.ImmediateHorizontal:
                // point straight at the target
                transform.forward = target.position - transform.position;
                // zero the rotation around x and z so we're just left with rotation around y
                transform.eulerAngles = Vector3.up * transform.eulerAngles.y;
                break;

            case Tracking.DelayedHorizontal:
                {
                    Vector3 fwd = target.position - transform.position;
                    // get the desired rotation around y using a trig helper function
                    angle = Mathf.Atan2(fwd.x, fwd.z) * Mathf.Rad2Deg;
                    // get the current euler angles
                    Vector3 angles = transform.eulerAngles;
                    // use a maths helper function that wraps us nicely around the 360 degrees boundary
                    angles.y = Mathf.MoveTowardsAngle(angles.y, angle, speed * Time.deltaTime);
                    // set the euler angle appropriately 
                    transform.eulerAngles = angles;
                }
                break;
        }
	}
}
