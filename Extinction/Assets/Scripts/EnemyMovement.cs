using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform m_Player;

    private PlayerHealth m_PlayerHealth;

    private EnemyHealth m_EnemyHealth;

    private NavMeshAgent m_NavMesh;

    public bool m_CanMove = false;

    private void Awake()
    {
        // Set up refrences.

        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_PlayerHealth = m_Player.GetComponent<PlayerHealth>();
        m_EnemyHealth = GetComponent<EnemyHealth>();
        m_NavMesh = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(m_EnemyHealth.m_CurrentHealth > 0 && m_PlayerHealth.m_CurrentHealth > 0 && m_CanMove == true)
        {
            m_NavMesh.enabled = true;
            m_NavMesh.SetDestination(m_Player.position);
        }
        else
        {
            m_NavMesh.enabled = false;
            m_CanMove = false;
        }

    }
}
