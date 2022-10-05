using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public InventoryObject junkInventory;
    public InventoryObject toolInventory;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            junkInventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
            Debug.Log("E kepencet");

        }
    }
    private void OnApplicationQuit()
    {
        junkInventory.Container.Clear();
    }
}
