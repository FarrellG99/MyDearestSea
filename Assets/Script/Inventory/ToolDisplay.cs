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
    public GameObject currentTool;


    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
        totalTools = inventory.Container.Count;
        tools = new GameObject[totalTools];

        for (int i=0;i < totalTools; i++)
        {
            tools[i] = toolHolder.transform.GetChild(i).gameObject;
            tools[i].SetActive(false);
        }
        tools[0].SetActive(true);
        currentTool = tools[0];
        currentToolIndex = 0;
    }


    void Update()
    {
        UpdateDisplay();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //ke tool selanjutnya
            if(currentToolIndex < totalTools-1)
            {
                tools[currentToolIndex].SetActive(false);
                currentToolIndex++;
                tools[currentToolIndex].SetActive(true);
            }
            else if(currentToolIndex == totalTools - 1)
            {
                tools[currentToolIndex].SetActive(false);
                currentToolIndex = 0;
                tools[currentToolIndex].SetActive(true);
            }
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
                //GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            //Kalau di container belum ada objectnya maka akan ditambahkan nama object yang diambil beserta amountnya
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
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
