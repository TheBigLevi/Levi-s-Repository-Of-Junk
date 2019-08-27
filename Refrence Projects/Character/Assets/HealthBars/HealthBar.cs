﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Health health;

    // this is the image we'll grow and shrink as the character's health changes
    public Image image;

    public Vector3 screenPos;

    Rect initialRect;
    // Use this for initialization
    void Start ()
    {
        // set the image to fill from the left. Change this to radial fill or anything else as you desire!
        if (image)
        {
            image.type = Image.Type.Filled;
            image.fillMethod = Image.FillMethod.Horizontal;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        // position the health bar 2m above the character's root (between their feet)
        // improve this by having a height field in Health for large or small characters
        transform.position = health.transform.position + Vector3.up * 2;

        // billboard the UI element towards the camera every frame
        transform.forward = Camera.main.transform.forward;

        // scale the meter
        float pct = Mathf.Clamp01(health.health / health.maxHealth);
        image.fillAmount = pct;

        // store the position in screen space of the health bar for sorting purposes
        screenPos = Camera.main.WorldToScreenPoint(health.transform.position);
    }
}