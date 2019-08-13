using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LootTable", menuName = "RPG/LootTable")]
public class LootTable : ScriptableObject {

    public List<LootDrop> lootAvaliable;
    public int[] lootTable;

    public GameObject GetDrop()
    {
        float total = 0;

        foreach (var item in lootTable)
        {
            total += item;
        }

        float randomNumber = Random.Range(0, total);

        for (int i = 0; i < lootTable.Length; i++)
        {
            // Compare the randomNumber to see if it's <= the current weight?
            if (randomNumber <= lootTable[i])
            {
                // Award Item
                Debug.Log("Award: " + lootTable[i]);
                // spawn the loot on top of our dead body
                if (lootAvaliable[i] == null)
                    return null;
                return lootAvaliable[i].prefab;
            }
            else
            {
                randomNumber -= lootTable[i];
            }
        }

        // should never get here
        return null;
    }
}
