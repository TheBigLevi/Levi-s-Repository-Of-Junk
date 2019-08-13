using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterClass", menuName = "RPG/CharacterClass")]
public class CharacterClass : ScriptableObject {

    [System.Serializable]
    public struct ClassStat
    {
        public float cap;
        public float gainPerLevel;
    }


    [Header("Level Stats")]
    public ClassStat HealthStat;
    public float ManaStat;
    public float Defence;
    public float Inteligence;
    public float Dexterity;
    public float Speed;
    public float Vitality;
    public float Damage;

    [Header("Current Stats")]
    public float currentHealth;

    public void TakeDamage()
    {

    }

}
