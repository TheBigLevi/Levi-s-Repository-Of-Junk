using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRanagedBehaviour : MonoBehaviour
{
    //private GameObject m_ThisGun;


    [Header("Weapon Specifics")]
    public string m_WeaponName;

    private enum WeaponType { SingleShot, SemiAutomatic, Burst, Automatic, ShotGun, RPG }

    [SerializeField]
    private WeaponType behaviourType;

    [Tooltip("m_Projectile needs to be a child of this object and named 'Projectile'")]
    [SerializeField]
    private GameObject m_Projectile;

    [Tooltip("m_FireTransform needs to be a child of this object and named 'FireTransformObject'")]
    [SerializeField]
    private GameObject m_FireTransform;

    [SerializeField]
    //[Tooltip()]
    private int m_MaxAmmo = 0;

    public int m_LocalCurrentAmmo = 0;

    [SerializeField]
    private int m_ClipSize = 0;

    public int m_LocalClipAmmo = 0;

    [Header("Projectile Properties")]
    [SerializeField]
    private float m_Speed = 0f;

    [SerializeField]
    private float m_Damage;

    [Header("Fire Properties")]
    [SerializeField]
    private bool m_CanFire = true;

    [SerializeField]
    private bool m_IsReloading = false;

    private GameObject m_FiredProjectile;

    // Start is called before the first frame update
    void Start()
    {

        m_LocalCurrentAmmo = m_MaxAmmo;
        m_LocalClipAmmo = m_ClipSize;

        m_FireTransform = transform.Find("FireTransformObject").gameObject;
        //m_Projectile = transform.Find("Projectile").gameObject;

        onEquip();

    }

    // Update is called once per frame
    void Update()
    {

        onFire();

        onReload();

    }

    private void onEquip()
    {
        //Set player's current item to this and replace it with current weapon if inventory full
        //gameObject.GetComponentInParent<CurrentEquipment>(). replace with current hand else fill empty hand

    }

    private void onFire()
    {
        if (Input.GetButton("Fire1") && m_CanFire == true && m_LocalClipAmmo != 0)
        {
            m_IsReloading = false;
            

            m_FiredProjectile = Instantiate(m_Projectile, m_FireTransform.transform.position, m_FireTransform.transform.rotation) as GameObject;
            Rigidbody m_FiredProjectileRigidbody = m_FiredProjectile.GetComponent<Rigidbody>();
            m_FiredProjectileRigidbody.AddForce(m_FiredProjectile.transform.forward * m_Speed /* Time.deltaTime*/);
            

            m_LocalClipAmmo -= 1;
        }
        else if (m_IsReloading == true)
        {
            //Stop reload function and add some sort of animation
        }
    }

    private void onReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && m_LocalCurrentAmmo > 0 && m_LocalClipAmmo != m_ClipSize)
        {
            m_IsReloading = true;
            int reloadAmount;

            if (m_CanFire == true)
            {
                reloadAmount = Mathf.Min(m_ClipSize - m_LocalClipAmmo, m_LocalCurrentAmmo);

                m_LocalCurrentAmmo -= reloadAmount;
                m_LocalClipAmmo += reloadAmount;

            }

        }
    }
}
