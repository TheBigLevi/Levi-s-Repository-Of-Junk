using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
public class WeaponRangedObject : ScriptableObject
{
    [Header("Weapon Specifics")]
    public string m_WeaponName;

    public enum RangedType { Pistol, Submachine_Gun, Assult_Rifle, Sniper, ShotGun, RPG, Null }
    public RangedType m_RangedType;

    public enum RangedFireType {Semi_Auto, Burst, Full_Auto }


    public enum MeleeType { Short_Sword, Long_Sword, Battle_Axe, Dagger }
    public MeleeType m_MeleeType;

    public bool m_IsThrowable;
    
    private GameObject m_WeaponModelPrefab;

    [Tooltip("m_Projectile needs to be a child of this object and named 'Projectile'")]
    
    public GameObject m_Projectile;

    [Tooltip("m_FireTransform needs to be a child of this object and named 'FireTransformObject'")]
    public GameObject m_FireTransform;

    [SerializeField]
    //[Tooltip()]
    public int m_MaxAmmo = 0;

    public int m_LocalCurrentAmmo = 0;

    [SerializeField]
    public int m_ClipSize = 0;

    public int m_LocalClipAmmo = 0;

    [Header("Projectile Properties")]
    public float m_Speed = 0f;

    [SerializeField]
    public float m_Damage;

    [Header("Fire Properties")]
    public bool m_CanFire = true;

    public bool m_IsReloading = false;

    public GameObject m_FiredProjectile;
}
