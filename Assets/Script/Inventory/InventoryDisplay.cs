using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    public InventoryObject inventory;

    public int X_START;//Posisi X awal di panel
    public int Y_START;//Posisi Y awal di panel
    public int Y_SPACE_BETWEEN_ITEMS; //Jarak Y tiap baris
    public int X_SPACE_BETWEEN_ITEMS; //Jarak X tiap baris
    public int NUMBER_OF_ROWS;//Jumlah baris
    public int NUMBER_OF_COLUMNS;//Jumlah baris
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
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
                obj2.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            //Kalau di container belum ada objectnya maka akan ditambahkan nama object yang diambil beserta amountnya
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                var obj2 = obj.transform.GetChild(0);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj2.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    public void CreateDisplay()
    {
        //Ketika awal mulai scene akan dibuat display dihitung dari Jumlah index container, awal seharusnya kosong karena belum bisa save
        for(int i  = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            var obj2 = obj.transform.GetChild(0);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj2.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEMS * (i % NUMBER_OF_COLUMNS)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i % NUMBER_OF_ROWS)), 0f);
    }

}
