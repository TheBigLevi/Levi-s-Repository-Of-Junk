using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentEquipment : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_WeaponArray;

    [SerializeField]
    private GameObject m_AmmoDisplay;

    [SerializeField]
    private GameObject m_CurrentWeapon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        m_WeaponArray = new GameObject[2];

        int arrayPos = 0;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(m_WeaponArray[arrayPos]); //Prints current value to console.
            if (arrayPos >= m_WeaponArray.Length - 1)
            {
                arrayPos = 0;
                m_CurrentWeapon = m_WeaponArray[arrayPos];
            }
            else
            {
                arrayPos += 1;
                m_CurrentWeapon = m_WeaponArray[arrayPos];
            }

            //m_CurrentWeapon

            //InternalBellyRub = BellyRubCount;
            //BellyRubDisplay.GetComponent<Text>().text = "Belly Rubs: " + InternalBellyRub;
        }
    }
}

