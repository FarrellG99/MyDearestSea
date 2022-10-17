using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public GameObject pondok;
    public GameObject craftingPanel;
    public TextMeshProUGUI craftPromptText;

    public InventoryObject junkInventory;
    public InventoryObject toolInventory;

    public CraftingRecipe sapuRecipe;
    public CraftingRecipe pistolRecipe;
    public CraftingRecipe filterRecipe;

    private bool menuOpened;
    private bool withinPondokRange;
    private bool craftAllowed;
    // Start is called before the first frame update
    void Start()
    {
        withinPondokRange = false;
        craftPromptText.gameObject.SetActive(false);
        menuOpened = false;
        craftAllowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (withinPondokRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!craftingPanel.activeInHierarchy)
                {
                    OpenCraftingMenu();
                    craftAllowed = true;
                }
                else
                {
                    CloseCraftingMenu();
                    craftAllowed = false;
                }
            }

            if (craftAllowed)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    CraftSapuLidi();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    CraftFilterAir();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    CraftPistolAir();
                }
            }
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            withinPondokRange = true;
            craftPromptText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            craftingPanel.SetActive(false);
            withinPondokRange = false;
            craftPromptText.gameObject.SetActive(false);
        }
    }

    private void OpenCraftingMenu()
    {
        craftingPanel.SetActive(true);
        craftPromptText.gameObject.SetActive(false);
        craftAllowed = true;
        Debug.Log("Boleh craft? " + craftAllowed);
    }

    private void CloseCraftingMenu()
    {
        craftingPanel.SetActive(false);
        craftPromptText.gameObject.SetActive(true);
        craftAllowed = false;
        Debug.Log("Boleh craft? " + craftAllowed);
    }

    
    public void CraftSapuLidi()
    {
        sapuRecipe.Craft(junkInventory, toolInventory);
        Debug.Log("Craft Sapu lidi");
    }

    public void CraftPistolAir()
    {
        pistolRecipe.Craft(junkInventory, toolInventory);
        Debug.Log("Craft Pistol Air");
    }
    public void CraftFilterAir()
    {
        filterRecipe.Craft(junkInventory, toolInventory);
        Debug.Log("Craft Filter Air");
    }
}
