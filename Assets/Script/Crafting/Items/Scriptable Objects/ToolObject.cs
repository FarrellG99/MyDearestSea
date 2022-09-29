using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Tool Object", menuName = "Crafting System/Item/Tool")]
public class ToolObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Tool;
    }
}
