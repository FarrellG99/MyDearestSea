using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public InventoryObject junkInventory;
    public InventoryObject toolInventory;

    private void OnApplicationQuit()
    {
        junkInventory.Container.Clear();
    }
}
