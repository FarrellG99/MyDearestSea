using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    public ItemObject item;
    public InventoryObject junkInventory;

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
            pickupText.gameObject.SetActive(true);
            pickupAllowed = false;
        }
    }

    private void PickUp()
    {
        junkInventory.AddItem(item, 1);
        Destroy(gameObject);
        pickupText.gameObject.SetActive(false);
    }
}
