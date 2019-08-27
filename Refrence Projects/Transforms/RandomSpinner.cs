using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpinner : MonoBehaviour {

    Quaternion start;
    Quaternion end;
    float lerp = 1.1f;
    public float speed = 1;

	// Update is called once per frame
	void Update () {
        if (lerp > 1.0f)
        {
            start = transform.rotation;
            end = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            lerp = 0;
        }
        else
        {
            lerp += Time.deltaTime * speed;
            transform.rotation = Quaternion.Slerp(start, end, lerp);
        }
	}
}
