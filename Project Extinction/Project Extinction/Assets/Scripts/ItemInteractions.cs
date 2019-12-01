using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractions : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Enable world space canvas with information of the object
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Set the players canvas to have a promt to pick up that also dispears on exit
            //Update rotation to face player
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Close world space canvas with information of the object
        }
    }
}
