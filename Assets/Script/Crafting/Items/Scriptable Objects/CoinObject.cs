using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Junk Object", menuName = "Crafting System/Item/Coin")]
public class CoinObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Coin;
    }
}
