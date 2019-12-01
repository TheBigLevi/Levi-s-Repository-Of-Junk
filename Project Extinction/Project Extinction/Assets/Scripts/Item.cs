using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
public class Item : ScriptableObject
{   
    [Header("General Item Atributes")]
    [Tooltip("Determines the name of the object.")]
    public string m_PrefabName;

    public enum ItemTypes { Food, Utility, Weapon, Resource, Apparel };

    public ItemTypes Type;

    [Tooltip("Determines the worth of the item.")]
    public int m_Value = 0;

    [Tooltip("Determines how much inventory space the item will take up.")]
    public float m_Weight = 0;

    [Tooltip("Determines if users can interact with this item in their menu select.")]
    public bool m_Interactable = false;

    [Tooltip("Determines if users can equip this item.")]
    public bool m_Equipable = false;

    [Header("Food Item Atributes")]
    //Details on what eating certain items will do and the buffs or debuffs they will grant
    public int placeholder = 0;

    [Header("Utility Item Atributes")]
    //Details on what consuming certain utility items will do and the buffs or debuffs they will grant
    public int placeholder2 = 0;

    [Header("Weapon Item Atributes")]
    [Tooltip("Current ammo within the firearm's magazine.")]
    public int m_CurrentClip = 0;

    [Tooltip("Max ammo that can be held in the firearm's magazine.")]
    public int m_MaxClip = 0;

    [Tooltip("Current total ammo that you have for this firearm not including the clip.")]
    public int m_CurrentAmmo = 0;

    /*[Tooltip("Max total ammo that you have for this firearm not including the clip.")]
    public int m_MaxAmmo;*/

    [Header("Utility Item Atributes")]
    //Details on what consuming certain utility items will do and the buffs or debuffs they will grant
    [Tooltip("Determines how much health the player will gain immediatly after consumtion of the item.")]
    public float m_InstantHealthGain;

    /*public void ItemInteract()
    {
        if (Type == ItemTypes.Food || Type == ItemTypes.Utility)
        {
            m_Interactable = true;
        }
        else if (Type == ItemTypes.Weapon || Type == ItemTypes.Apparel)
        {
            m_Equipable = true;
        }
        else
        {
            m_Interactable = false;
            m_Equipable = false;
        }
    }*/

}