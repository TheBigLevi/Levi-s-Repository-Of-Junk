using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform PlayerTransform;

    private Vector3 CameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;


	// Use this for initialization
	void Start () {
		CameraOffset = transform.position - PlayerTransform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 newPos = PlayerTransform.position + CameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
	}
}
