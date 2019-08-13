using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // The time in seconds before the arrow is removed
    public float m_MaxLifeTime = 2f;
    // The amount of damage done if the explosion is centred on a tank
    public float m_MaxDamage = 5f;


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // Find the rigidbody of the collision object
            Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();

            if (targetRigidbody != null)
            {
                // Find the Enemy's Health associated with the rigidbody
                EnemyScript targetHealth = targetRigidbody.GetComponent<EnemyScript>();

                if (targetHealth != null)
                {
                    // Calcuate the amount of damage the target should take based on it's distance from the projectile
                    //float damage = CalculateDamage(targetRigidbody.position);
                    float damage = m_MaxDamage;
                    targetHealth.TakeDamage(damage);
                    Destroy(gameObject);
                }
            }
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
