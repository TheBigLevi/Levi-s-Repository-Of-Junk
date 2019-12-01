using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    //public GameObject Players[];

    public Item m_Item;

    [SerializeField]
    [Tooltip("The item object must have a child with a collider in position 0")]
    private Collider m_Collider;


    // Start is called before the first frame update
    void Start()
    {

        m_Collider = gameObject.transform.GetChild(0).GetComponent<Collider>();

    }

    private void Update()
    {



    }
}
