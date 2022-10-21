using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    public ItemObject item;
    public ItemObject coin;
    public InventoryObject junkInventory;
    public GameObject player;

    public TextMeshProUGUI pickupText;

    private bool pickupAllowed;

    private void Start()
    {
        pickupText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(pickupAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player masuk");
            pickupText.gameObject.SetActive(true);
            pickupAllowed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player keluar");
            pickupText.gameObject.SetActive(false);
            pickupAllowed = false;
        }
    }

    private void PickUp()
    {
        ActiveWeapon activeWeapon = player.gameObject.GetComponent<ActiveWeapon>();
        if (activeWeapon.sapuEquipped)
        {
            junkInventory.AddItem(item, 2);
        }
        else
        {
            junkInventory.AddItem(item, 1);
        }
        junkInventory.AddItem(coin, 1);
        Destroy(gameObject);
        pickupText.gameObject.SetActive(false);
    }
}
