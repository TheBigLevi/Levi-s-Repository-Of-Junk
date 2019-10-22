using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public WeaponObject m_CurrentWeapon;

    //private GameObject m_WeaponModelInstance;

    public GameObject m_WeaponTransform;

    [SerializeField]
    private Canvas m_PlayerHUD;

    public GameObject[] m_WeaponsEquipped;

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
        TotalAmmo = new int[System.Enum.GetValues(typeof(WeaponObject.RangedType)).Length - 1];
        ClipAmmo = new int[System.Enum.GetValues(typeof(WeaponObject.RangedType)).Length - 1];


        if (m_CurrentWeapon.m_RangedType != WeaponObject.RangedType.Null)
        {
            Debug.Log(m_CurrentWeapon.m_RangedType + " " + (int)m_CurrentWeapon.m_RangedType);
            m_LocalCurrentAmmo = m_CurrentWeapon.m_MaxAmmo;
            m_LocalClipAmmo = m_CurrentWeapon.m_ClipSize;

            onEquip();
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        m_PlayerHUD.transform.Find("Weapon Name").GetComponent<Text>().text = m_CurrentWeapon.m_WeaponName;
        m_PlayerHUD.transform.Find("Ammo").GetComponent<Text>().text = m_LocalClipAmmo + " / " + m_LocalCurrentAmmo;

        onAttack();

        onReload();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            onEquip();
        }
    }

    private void onEquip()
    {
        //Set player's current item to this and replace it with current weapon if inventory full
        //gameObject.GetComponentInParent<CurrentEquipment>(). replace with current hand else fill empty hand

        //Instantiate weapon at set point



        GameObject NewWeaponObject = Instantiate(m_CurrentWeapon.m_WeaponModelPrefab, m_WeaponTransform.transform.position, m_WeaponTransform.transform.rotation) as GameObject;

        m_CurrentWeapon.m_FireTransform = NewWeaponObject.transform.Find("FireTransformObject");

        NewWeaponObject.transform.parent = m_WeaponTransform.transform;

        Debug.Log("FireTransformObject Found");
    }

    private void onAttack()
    {

        if (Input.GetButtonDown("Fire1") && m_CurrentWeapon.m_RangedType != WeaponObject.RangedType.Null && m_CurrentWeapon.m_CanFire == true && m_LocalClipAmmo != 0)
        {
            m_CurrentWeapon.m_IsReloading = false;

            m_CurrentWeapon.m_FiredProjectile = Instantiate(m_CurrentWeapon.m_Projectile, m_CurrentWeapon.m_FireTransform.transform.position, m_CurrentWeapon.m_FireTransform.transform.rotation) as GameObject;
            Rigidbody m_FiredProjectileRigidbody = m_CurrentWeapon.m_FiredProjectile.GetComponent<Rigidbody>();
            m_FiredProjectileRigidbody.AddForce(m_CurrentWeapon.m_FiredProjectile.transform.forward * m_CurrentWeapon.m_Speed /* Time.deltaTime*/);

            m_LocalClipAmmo--;
        }
        else if (m_CurrentWeapon.m_IsReloading == true)
        {
            m_CurrentWeapon.m_CanFire = true;
            m_CurrentWeapon.m_IsReloading = false;

            // Stop anim and begin to shoot
        }
    }

    private void onReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && m_LocalCurrentAmmo > 0 && m_LocalClipAmmo != m_CurrentWeapon.m_ClipSize && m_CurrentWeapon.m_CanFire == true)
        {
            m_CurrentWeapon.m_CanFire = false;
            m_CurrentWeapon.m_IsReloading = true;

            StartCoroutine(ReloadTimer());

            int reloadAmount;

            reloadAmount = Mathf.Min(m_CurrentWeapon.m_ClipSize - m_LocalClipAmmo, m_LocalCurrentAmmo);

            m_LocalCurrentAmmo -= reloadAmount;
            m_LocalClipAmmo += reloadAmount;

            m_CurrentWeapon.m_CanFire = true;
        }
    }

    private IEnumerator ReloadTimer()
    {
        yield return new WaitForSecondsRealtime(m_CurrentWeapon.m_ReloadTime);
    }
    private IEnumerator TimeBetweenShots()
    {
        yield return new WaitForSecondsRealtime(m_CurrentWeapon.m_FireRateTimer);
    }
}
