using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float m_TimeBetweenAttacks = 0.5f;

    public int m_AttackDamage = 25;

    private Animator m_Anim;

    private GameObject m_Player;

    private PlayerHealth m_PlayerHealth;

    private EnemyHealth m_EnemyHealth;

    private bool m_PlayerInRange;

    private float m_Timer;

    // Start is called before the first frame update
    void Start()
    {

        m_Anim = GetComponent<Animator>();

        m_Player = GameObject.FindGameObjectWithTag("Player");

        m_PlayerHealth = m_Player.GetComponent<PlayerHealth>();

        m_EnemyHealth = GetComponent<EnemyHealth>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_Player)
        {
            m_PlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == m_Player)
        {
            m_PlayerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer += Time.deltaTime;

        if (m_Timer >= m_TimeBetweenAttacks && m_PlayerInRange && m_EnemyHealth.m_CurrentHealth > 0)
        {
            Attack();
        }
    }

    private void Attack()
    {
        m_Timer = 0f;
        if (m_PlayerHealth.m_CurrentHealth > 0)
        {
            m_PlayerHealth.TakeDamage(m_AttackDamage);
        }
    }
}
