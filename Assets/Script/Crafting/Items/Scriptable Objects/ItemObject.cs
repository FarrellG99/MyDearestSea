using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class untuk object Item secara general
public enum ItemType
{
    Junk,
    Tool
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea (15,20)]
    public string description;
}
