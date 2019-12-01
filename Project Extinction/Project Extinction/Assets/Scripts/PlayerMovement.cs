using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController m_CharacterController;

    public float m_Speed = 10f;
    public float m_Gravity = -9.81f;
    public float m_Jumpheight = 3f;

    Vector3 m_Velocity;
    private bool m_IsGrounded = false;

    // Update is called once per frame
    void Update()
    {
        if ((m_CharacterController.collisionFlags & CollisionFlags.Below) != 0)
        {
            //Checks if the character controller is grounded
            m_IsGrounded = true;
            m_Velocity.y = -2f;
        }
        else
        {
            m_IsGrounded = false;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 MoveDir = transform.right * x + transform.forward * z;

        m_CharacterController.Move(MoveDir * m_Speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && m_IsGrounded == true)
        {
            m_Velocity.y = Mathf.Sqrt(m_Jumpheight * -2f * m_Gravity);
        }


        m_Velocity.y += m_Gravity * Time.deltaTime;

        m_CharacterController.Move(m_Velocity * Time.deltaTime);



    }
}
