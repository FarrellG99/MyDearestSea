using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public ItemObject item;
    [Range (1,999)]
    public int amount;

}

[CreateAssetMenu(fileName = "New Crafting Recipe Object", menuName = "Crafting System/Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> materials;
    public List<ItemAmount> results;

    public bool CanCraft(InventoryObject junkInventory)
    {
        foreach(ItemAmount itemAmount in materials)
        {
            if(junkInventory.GetAmount(itemAmount.item) < itemAmount.amount)
            {
                return false;
            }
        }
        return true;
    }

    public void Craft(InventoryObject junkInventory, InventoryObject toolInventory)
    {
        if (CanCraft(junkInventory))
        {
            foreach(ItemAmount itemAmount in materials)
            {
                for(int i = 0; i < itemAmount.amount; i++)
                {
                    junkInventory.ReduceItem(itemAmount.item,1);
                }
            }

            foreach(ItemAmount itemAmount in results)
            {
                for (int i = 0; i < itemAmount.amount; i++)
                {
                    toolInventory.AddItem(itemAmount.item, 1);
                }
            }
        }
    }
}
