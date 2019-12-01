using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    /*[SerializeField]
    private Camera cam;*/

    public Transform m_PlayerBody;
    public float m_MouseSensitivity = 100f;

    private float m_xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * m_MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * m_MouseSensitivity * Time.deltaTime;

        m_xRotation -= MouseY;
        m_xRotation = Mathf.Clamp(m_xRotation, -80, 80);

        transform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
        m_PlayerBody.Rotate(Vector3.up * MouseX);
    }
}
