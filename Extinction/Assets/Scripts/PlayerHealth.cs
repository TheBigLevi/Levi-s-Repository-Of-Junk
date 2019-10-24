using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int m_StartingHealth = 75;

    public int m_CurrentHealth;

    public Slider m_HealthSlider;

    [SerializeField]
    private Image m_DamageImage;

    [SerializeField]
    private float m_ImageSpeed = 5f;
    
    [SerializeField]
    private Color m_ImageColor = new Color(1f, 0f, 0f, 0.1f);

    [SerializeField]
    private AudioClip m_DeathClip;


    private Animator m_Anim;

    private AudioSource m_PlayerAudio;

    private PlayerController m_PlayerMovement;

    // TODO -  Get this to change dependent on weapon
    private PlayerAttack m_WeaponBehaviour;

    private bool m_IsDead;

    private bool m_Damaged;


    private void Awake()
    {
        m_Anim = GetComponent<Animator>();
        m_PlayerAudio = GetComponent<AudioSource>();
        m_PlayerMovement = GetComponent<PlayerController>();
        m_WeaponBehaviour = GetComponent<PlayerAttack>();

        m_CurrentHealth = m_StartingHealth;

    }

    // Update is called once per frame
    void Update()
    {
        whenDamaged();
    }

    private void whenDamaged()
    {
        if (m_Damaged)
        {
            m_DamageImage.color = m_ImageColor;
        }
        else
        {
            //m_DamageImage.color = Color.Lerp(m_DamageImage.color, Color.clear, m_ImageSpeed * Time.deltaTime);
        }

        m_Damaged = false;
    }

    public void TakeDamage (int amount)
    {
        m_Damaged = true;
        m_CurrentHealth -= amount;

        m_HealthSlider.value = m_CurrentHealth;

        m_PlayerAudio.Play();

        if(m_CurrentHealth <= 0 && !m_IsDead)
        {
            Death();
        }
    }

    private void Death()
    {
        m_IsDead = true;

        m_Anim.SetTrigger ("Die");

        m_PlayerAudio.clip = m_DeathClip;
        m_PlayerAudio.Play();

        m_PlayerMovement.enabled = false;
        m_WeaponBehaviour.enabled = false;
    }
}

