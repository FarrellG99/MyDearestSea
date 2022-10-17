using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public RaycastWeapon weaponFab;
    public ItemObject item;
    public InventoryObject toolInventory;
    private void OnTriggerEnter(Collider other)
    {
        ActiveWeapon activeWeapon = other.gameObject.GetComponent<ActiveWeapon>();
        if(activeWeapon)
        {
            RaycastWeapon newWeapon = Instantiate(weaponFab);
            activeWeapon.Equip(newWeapon);
            toolInventory.AddItem(item, 1);
        }
    }
}
