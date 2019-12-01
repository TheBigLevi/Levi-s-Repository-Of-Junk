using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    public int m_StartingHealth = 100;

    public int m_CurrentHealth;

    public float m_SinkSpeed = 2.5f;

    public int m_ScoreValue = 10;

    public AudioClip m_DeathClip;


    private Animator m_Anim;

    private AudioSource m_EnemyAudio;

    private ParticleSystem m_HitParticles;

    private CapsuleCollider m_CapsuleCollider;

    private bool m_IsDead;

    private bool m_IsSinking;


    private void Awake()
    {
        m_Anim = GetComponent<Animator>();
        m_EnemyAudio = GetComponent<AudioSource>();
        m_HitParticles = GetComponentInChildren<ParticleSystem>();
        m_CapsuleCollider = GetComponent<CapsuleCollider>();

        m_CurrentHealth = m_StartingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        IsSinking();
    }

    private void IsSinking()
    {
        if (m_IsSinking)
        {
            transform.Translate(-Vector3.up * m_SinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(m_IsDead)
            return;

        m_EnemyAudio.Play();

        m_CurrentHealth -= amount;

        m_HitParticles.transform.position = hitPoint;

        m_HitParticles.Play();

        if(m_CurrentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        m_IsDead = true;

        m_CapsuleCollider.isTrigger = true;

        m_Anim.SetTrigger("Dead");

        m_EnemyAudio.clip = m_DeathClip;
        m_EnemyAudio.Play();
    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
         m_IsSinking = true;

        //ScoreManager.m_Score += m_ScoreValue;

        Destroy (gameObject, 3f);
    }

}
