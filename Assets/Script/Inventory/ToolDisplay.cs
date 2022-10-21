using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ToolDisplay : MonoBehaviour
{
    [Header ("Inventory Object")]
    public InventoryObject inventory;

    [Header("Position")]
    public int X_START;//Posisi X awal di panel
    public int Y_START;//Posisi Y awal di panel

    private int totalTools;
    public int currentToolIndex;
    public GameObject[] tools;
    public GameObject toolHolder;
    private GameObject currentTool;

    public ItemObject sapu;
    public ItemObject pistol;
    public ItemObject filter;

    public ActiveWeapon weapon;
    public InventoryObject toolInventory;



    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        totalTools = 3;
        tools = new GameObject[3];

        if(totalTools > 0)
        {
            for (int i = 0; i < totalTools; i++)
            {
                tools[i] = toolHolder.transform.GetChild(i).gameObject;
                tools[i].SetActive(false);
            }

        }
    }


    void Update()
    {
        if (weapon.gunEquipped)
        {
            DisplayGun();
        }
        if (weapon.sapuEquipped)
        {
            DisplaySapu();
        }
        if (weapon.filterEquipped)
        {
            DisplayFilter();
        }
    }

    public void UpdateDisplay()
    {
        //Update display tiap frame dihitung dari jumlah index Container
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            //Kalau di container udah ada object maka akan ditambahkan saja amount nya
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                var obj2 = itemsDisplayed[inventory.Container[i]].transform.GetChild(0);
            }
            //Kalau di container belum ada objectnya maka akan ditambahkan nama object yang diambil beserta amountnya
            else
            {
                /*var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);*/
                totalTools++;
                tools[totalTools-1] = toolHolder.transform.GetChild(totalTools-1).gameObject;
                if(totalTools > 0)
                {
                    tools[currentToolIndex].SetActive(false);
                    currentToolIndex = totalTools - 1;
                    tools[currentToolIndex].SetActive(true);
                }
                
            }
        }
    }

    public void DisplayGun()
    {
        if (toolInventory.ContainsItem(pistol))
        {
            var objGun = toolHolder.transform.GetChild(1).gameObject;
            tools[1] = toolHolder.transform.GetChild(1).gameObject;
            currentTool = tools[1];
            tools[0].SetActive(false);
            tools[1].SetActive(true);
            tools[2].SetActive(false);
        }
        
    }
    public void DisplaySapu()
    {
        if (toolInventory.ContainsItem(sapu))
        {
            var objSapu = toolHolder.transform.GetChild(0).gameObject;
            tools[0] = toolHolder.transform.GetChild(0).gameObject;
            currentTool = tools[0];
            tools[0].SetActive(true);
            tools[1].SetActive(false);
            tools[2].SetActive(false);
        }
    }
    public void DisplayFilter()
    {
        if (toolInventory.ContainsItem(filter))
        {
            var objSapu = toolHolder.transform.GetChild(2);
            tools[2] = toolHolder.transform.GetChild(2).gameObject;
            currentTool = tools[2];
            tools[0].SetActive(false);
            tools[1].SetActive(false);
            tools[2].SetActive(true);
        }
        
    }


    public void CreateDisplay()
    {
        //Ketika awal mulai scene akan dibuat display dihitung dari Jumlah index container, awal seharusnya kosong karena belum bisa save
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START, Y_START, 0f);
    }
}
