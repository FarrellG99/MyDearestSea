using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public GameObject colliderWave;
    public GameObject filter;
    public InventoryObject toolInventory;
    public ItemObject filterObject;
    public GameObject music;

    public int pasang = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            colliderWave.SetActive(true);
            filter.SetActive(true);
            toolInventory.ReduceItem(filterObject,1);
            pasang = 1;
            music.SetActive(true);
        }
    }
}
