using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour {

    public struct StatValue
    {
        public StatValue(float val)
        {
            current = max = val;
        }

        public void LevelUp(float val)
        {
            current = max = val;
        }

        public float current;
        public float max;
    }

    public CharacterClass characterClass;
    public int characterLevel;

    public Dictionary<string, StatValue> StatDictionary = new Dictionary<string, StatValue>();

    public virtual void IntialiseDictionary()
    {
        SetStat(Stats.Health, new StatValue(characterClass.HealthStat.cap));
        SetStat(Stats.Mana, new StatValue(characterClass.ManaStat));
        SetStat(Stats.Defence, new StatValue(characterClass.Defence));
        SetStat(Stats.Inteligence, new StatValue(characterClass.Inteligence));
        SetStat(Stats.Dexterity, new StatValue(characterClass.Dexterity));
        SetStat(Stats.Speed, new StatValue(characterClass.Speed));
        SetStat(Stats.Vitality, new StatValue(characterClass.Vitality));
        SetStat(Stats.Damage, new StatValue(characterClass.Damage));

    }

    public enum Stats
    {
        Health,
        Mana,
        Defence,
        Inteligence,
        Dexterity,
        Speed,
        Vitality,
        Damage,
    }

    public void SetStat(Stats stat, StatValue value)
    {
        StatDictionary[stat.ToString()] = value;
    }
}
