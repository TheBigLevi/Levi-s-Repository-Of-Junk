using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy Movement Varabiles")]
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;

    [Header("Enemy Stats")]
    public float m_Damage = 10f;

    public float m_TotalHealth = 35f;
    [SerializeField]
    private float m_CurrentHealth;
    private bool m_Dead;

    public float m_Defense = 2f;

    [Header("Enemy Loot Drops")]
    public List<LootTable> lootTables;
    public int[] lootTableChance = { };


    public int total;
    public int randomNumber;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // When the tank is enabled, reset the tank's health and whether or not it's dead
        m_CurrentHealth = m_TotalHealth;
        m_Dead = false;

        SetHealthUI();
    }

    void Update()
    {
        target = PlayerManager.instance.player.transform;
        MoveToPlayer();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void SetHealthUI()
    {
        //
        //TODO: Update the users interface with the enemys health
        //
    }

    public void TakeDamage(float amount)
    {
        // Reduce current health by the amount of damage done
        m_CurrentHealth -= amount;

        // Change the UI elements appropriately
        SetHealthUI();

        // If the current health is at or below zero and has not yet been registered, call OnDeath
        if (m_CurrentHealth == 0f && !m_Dead)
        {
            OnDeath();
        }
    }

    #region //Enemy Movement
    private void MoveToPlayer()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                // Attack the target
                //Face the target
                FaceTarget();
            }
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    #endregion

    private void OnDeath()
    {
        foreach (var item in lootTableChance)
        {
            total += item;
        }

        randomNumber = UnityEngine.Random.Range(0, total);

        for (int i = 0; i < lootTableChance.Length; i++)
        {
            // Compare the randomNumber to see if it's <= the current weight?
            if (randomNumber <= lootTableChance[i])
            {
                // Award Item
                Debug.Log("Award: " + lootTableChance[i]);

                // spawn the loot on top of our dead body
                if (lootTables[i] != null)
                {
                    GameObject drop = lootTables[i].GetDrop();
                    if (drop != null)
                        Instantiate(drop, transform.position, transform.rotation);
                }
                m_Dead = true;
                Destroy(gameObject);
                return;
            }
            else
            {
                randomNumber -= lootTableChance[i];
            }
        }
    }
}