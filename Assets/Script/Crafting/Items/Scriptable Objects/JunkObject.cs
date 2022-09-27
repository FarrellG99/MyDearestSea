using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Junk Object", menuName ="Crafting System/Item/Junk")]
public class JunkObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Junk;
    }

}
