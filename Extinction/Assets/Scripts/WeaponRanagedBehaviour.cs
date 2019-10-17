using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRanagedBehaviour : MonoBehaviour
{
    public WeaponRangedObject m_CurrentWeapon;

    private GameObject m_WeaponModelInstance;

    public int[] TotalAmmo;
    public int[] ClipAmmo;



    // this is a property
    // its a get and set function that get treated like a variable!
    public int m_LocalCurrentAmmo
    {
        get { return TotalAmmo[(int)m_CurrentWeapon.m_RangedType]; }
        set { TotalAmmo[(int)m_CurrentWeapon.m_RangedType] = value; }
    }
    public int m_LocalClipAmmo
    {
        get { return ClipAmmo[(int)m_CurrentWeapon.m_RangedType]; }
        set { ClipAmmo[(int)m_CurrentWeapon.m_RangedType] = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (m_CurrentWeapon)
        {
            m_LocalCurrentAmmo = m_CurrentWeapon.m_MaxAmmo;
            m_LocalClipAmmo = m_CurrentWeapon.m_ClipSize;

            //m_FireTransform = transform.Find("FireTransformObject").gameObject;
        }
        //m_Projectile = transform.Find("Projectile").gameObject;

        onEquip(); onEquip();

        //TotalAmmo = new int[(int)WeaponRangedObject.WeaponType.RPG + 1];

    }

    // Update is called once per frame
    void Update()
    {
        onAttack();

        onReload();

    }

    private void onEquip()
    {
        //Set player's current item to this and replace it with current weapon if inventory full
        //gameObject.GetComponentInParent<CurrentEquipment>(). replace with current hand else fill empty hand

    }

    private void onAttack()
    {
        ;

        if (Input.GetButton("Fire1") && m_CurrentWeapon.m_CanFire == true && m_LocalClipAmmo != 0)
        {
            m_CurrentWeapon.m_IsReloading = false;


            m_CurrentWeapon.m_FiredProjectile = Instantiate(m_CurrentWeapon.m_Projectile, m_CurrentWeapon.m_FireTransform.transform.position, m_CurrentWeapon.m_FireTransform.transform.rotation) as GameObject;
            Rigidbody m_FiredProjectileRigidbody = m_CurrentWeapon.m_FiredProjectile.GetComponent<Rigidbody>();
            m_FiredProjectileRigidbody.AddForce(m_CurrentWeapon.m_FiredProjectile.transform.forward * m_CurrentWeapon.m_Speed /* Time.deltaTime*/);


            m_LocalCurrentAmmo--;
        }
        else if (m_CurrentWeapon.m_IsReloading == true)
        {
            //Stop reload function and add some sort of animation
        }
    }

    private void onReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && m_LocalCurrentAmmo > 0 && m_LocalClipAmmo != m_CurrentWeapon.m_ClipSize)
        {
            m_CurrentWeapon.m_IsReloading = true;
            int reloadAmount;

            if (m_CurrentWeapon.m_CanFire == true)
            {
                reloadAmount = Mathf.Min(m_CurrentWeapon.m_ClipSize - m_LocalClipAmmo, m_LocalCurrentAmmo);

                m_LocalCurrentAmmo -= reloadAmount;
                m_LocalClipAmmo += reloadAmount;

            }

        }
    }
}
