using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    //private Camera m_Camera;
    [SerializeField]
    private float m_MouseSensitivity = 0.5f;

    private float m_MouseX;
    private float m_MouseY;

    private void Awake()
    {
        //m_Camera = GetComponent<Camera>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        m_MouseX += Input.GetAxisRaw("Mouse X") * m_MouseSensitivity;        
        m_MouseY -= Input.GetAxisRaw("Mouse Y") * m_MouseSensitivity;

        m_MouseY = Mathf.Clamp(m_MouseY, -70, 70);

        Quaternion cameraRotation = Quaternion.Euler(m_MouseY, 0f, 0f);

        Quaternion playerRotation = Quaternion.Euler(0f, m_MouseX, 0f);

        transform.localRotation = cameraRotation;
        transform.parent.localRotation = playerRotation;
    }
}
