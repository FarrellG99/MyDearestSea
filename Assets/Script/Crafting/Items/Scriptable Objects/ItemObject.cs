using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class untuk object Item secara general
public enum ItemType
{
    Junk,
    Tool,
    Coin
}
public abstract class ItemObject : ScriptableObject
{
    public string itemName;
    public GameObject prefab;
    public ItemType type;
    [TextArea (15,20)]
    public string description;
}
