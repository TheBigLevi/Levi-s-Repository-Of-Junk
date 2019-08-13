using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    Animator anim;
    int m_ExcludedLayerMask;
    float turn = 0;


    #region Play Stat Variables (Replaced with dictionary)
    /*
    [Header("Player Stats")]
    public float currentExp;
    public float currentLevel;

    public float currentHealth;
    public float totalHealth;

    public float currentMana;
    public float totalMana;

    public float currentDex;
    */
    #endregion

    [Header("Player Damage Properties")]
    // Prefab of the projectile
    public Rigidbody m_Projectile;
    // A child of the tank where the shells are spawned
    public Transform m_FireTransform;
    // The force given to the shell when firing
    public float m_LaunchForce;

    //public float damage;

    [Header("Player Movement Properties")]
    public float moveSpeed = 2f;

    public bool controllerInUse;


    void Awake()
    {
        //m_layerMask = LayerMask.GetMask("Ground");
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Playermovement with Keyboard and Controller
        PlayerMovement();

        // Aim with Mouse
        if (!controllerInUse)
        {
            PlayerAim();
        }

        // Aim with Controller
        if (controllerInUse)
        {
            ControllerAim();
        }


    }



    #region // Player Aim and Fire
    void PlayerAim()
    {
        if (Input.GetButton("Fire1"))
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

            Fire();

        }
    }

    void ControllerAim()
    {
        Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");
        if (playerDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        }
    }

    void Fire()
    {
        // Create an instance of the projectile and store a refrence to it's rigidbody
        Rigidbody projectileInstance = Instantiate(m_Projectile, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Set the projectile's velcoity of the launch force in the fire position's forward direction
        projectileInstance.velocity = m_LaunchForce * m_FireTransform.forward;
    }
    #endregion

    #region // Player Movement

    void PlayerMovement()
    {

        float verticalMoveAxis = Input.GetAxis("Vertical");
        float horizontalMoveAxis = Input.GetAxis("Horizontal");

        ApplyInput(verticalMoveAxis, horizontalMoveAxis);

    }


    void ApplyInput(float verticalInput, float horizontalInput)
    {
        turn *= 0.01f;

        Vector3 forward = Camera.main.transform.forward;
        // take away vertical component and renormalise
        forward.y = 0;
        forward.Normalize();
        Vector3 move = (forward * verticalInput * moveSpeed);
        Vector3 right = Camera.main.transform.right;
        right.y = 0;
        right.Normalize();
        move += (right * horizontalInput * moveSpeed);
        transform.position += move;

        if (verticalInput != 0 || horizontalInput != 0)
        {
            Vector3 fwd = move;
            turn = Vector3.Cross(fwd, transform.forward).y;
            transform.forward = fwd;
        }

        anim.SetFloat("Forward", verticalInput * verticalInput + horizontalInput * horizontalInput);
        anim.SetFloat("Turn", turn);



    }
    #endregion
}
