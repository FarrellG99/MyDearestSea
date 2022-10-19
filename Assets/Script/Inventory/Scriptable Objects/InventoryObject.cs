using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName ="Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for(int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item == _item)
            {
                Container[i].addAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
    public void ReduceItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                if(Container[i].amount > 0)
                {
                    Container[i].subsAmount(_amount);
                    break;
                }
                else
                {
                    break;
                }
                
            }
        }
    }

    public bool ContainsItem(ItemObject _item)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                return true;
            }
        }
        return false;
    }

    public int GetAmount(ItemObject _item)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                return Container[i].amount;
            }
        }
        return 0;
    }

    public string GetItemName(ItemObject _item)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                return Container[i].item.itemName;
            }
        }
        return "NoName";
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void addAmount(int value)
    {
        amount += value;
    }
    public void subsAmount(int value)
    {
        amount -= value;
    }
}
