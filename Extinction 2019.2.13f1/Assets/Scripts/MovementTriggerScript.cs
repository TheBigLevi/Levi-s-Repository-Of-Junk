using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTriggerScript : MonoBehaviour
{

    private EnemyMovement EM;

    // Start is called before the first frame update
    void Start()
    {
        EM = gameObject.transform.parent.gameObject.GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == EM.m_Player)
        {
            EM.m_CanMove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == EM.m_Player)
        {
            EM.m_CanMove = false;
        }
    }
}
