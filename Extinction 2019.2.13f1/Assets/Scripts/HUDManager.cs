using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentEquipment : MonoBehaviour
{
    [SerializeField]
    private WeaponObject[] m_WeaponArray;

    private GameObject m_AmmoDisplay;

    private GameObject m_WeaponDisplay;

    [SerializeField]
    private GameObject m_CurrentWeapon;

    //Viewable Variables

    public int arrayPos = 0;
    public int clipAmmo = 0;
    public int currentAmmo = 0;
    public string weaponName;

    // Start is called before the first frame update
    void Start()
    {
        //m_WeaponArray = new GameObject[2];

        //m_WeaponArray[1].SetActive(false);

        //m_WeaponArray[0] = GameObject.FindWithTag("Default Weapon");

        m_AmmoDisplay = GameObject.FindWithTag("Ammo Display");
        m_WeaponDisplay = GameObject.FindWithTag("Weapon Name Display");
    }

    // Update is called once per frame
    void Update()
    {

        //cycleEquipment();

        //updateUI();

    }

    /*private void cycleEquipment()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //m_WeaponArray = new GameObject[2];


            if (arrayPos >= m_WeaponArray.Length - 1)
            {
                m_WeaponArray[arrayPos].SetActive(false);
                arrayPos = 0;
                m_WeaponArray[arrayPos].SetActive(true);
            }
            else
            {
                m_WeaponArray[arrayPos].SetActive(false);
                arrayPos += 1;
                m_WeaponArray[arrayPos].SetActive(true);
            }
            Debug.Log("Current weapon changed to: " + m_WeaponArray[arrayPos]); //Prints current value to console.
        }
    }

    private void updateUI()
    {
        //Creates link to the gameobject within array
        GameObject m_CurrentWeapon = m_WeaponArray[arrayPos];
        WeaponRanagedBehaviour m_WeaponScript = m_CurrentWeapon.GetComponent<WeaponRanagedBehaviour>();

        //Creates local variables from the weapons independent stats
        clipAmmo = m_WeaponScript.m_LocalClipAmmo;
        currentAmmo = m_WeaponScript.m_LocalCurrentAmmo;
        weaponName = m_WeaponScript.m_CurrentWeapon.m_WeaponName;

        //Assigns loacl varaibles to players GUI
        m_AmmoDisplay.GetComponent<Text>().text = clipAmmo + " / " + currentAmmo;
        m_WeaponDisplay.GetComponent<Text>().text = weaponName;
    }*/
}

