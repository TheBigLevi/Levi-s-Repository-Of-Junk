using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerScript : MonoBehaviour
{

    private EnemyAttack EA;
    // Start is called before the first frame update
    void Start()
    {
        EA = gameObject.transform.parent.gameObject.GetComponent<EnemyAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EA.m_Player)
        {
            EA.m_PlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == EA.m_Player)
        {
            EA.m_PlayerInRange = false;
        }
    }
}
