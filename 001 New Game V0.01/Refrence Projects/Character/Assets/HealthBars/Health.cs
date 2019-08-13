using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health = 100;
    public float maxHealth = 100;

    void Start()
    {
        HealthBarManager.instance.AddHealthBar(this);
    }
}
