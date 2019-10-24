using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Would it be better to dervive the player  from a scriptiable object
    [SerializeField]
    private float m_PlayerSpeed;

    [SerializeField]
    private float m_SprintMultiplier = 2;

    [SerializeField]
    private float m_Gravity = 5f;

    private Vector3 m_MoveDirection;
    private CollisionFlags m_MoveFlags;

    private CharacterController m_Controller;

    private Animator m_Anim;

    private void Awake()
    {
        m_Controller = GetComponent<CharacterController>();

        m_Anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool sprintKey = Input.GetKey(KeyCode.LeftShift);


        //Checks if player is grounded and stops player movemnt if not
        if ((m_MoveFlags & CollisionFlags.Below) != 0)
        {
            m_MoveDirection = (horizontal * transform.right) + (vertical * transform.forward);
            m_MoveDirection *= m_PlayerSpeed;

            if (sprintKey)
            {
                m_MoveDirection *= m_SprintMultiplier;
            }
        }

        m_MoveDirection.y -= m_Gravity * Time.deltaTime;

        m_MoveFlags = m_Controller.Move(m_MoveDirection);
    }
}
