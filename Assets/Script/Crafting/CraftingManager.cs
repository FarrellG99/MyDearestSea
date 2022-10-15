using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public GameObject pondok;
    public GameObject craftingPanel;
    public TextMeshProUGUI craftPromptText;

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
                craftingPanel.SetActive(true);
                craftPromptText.gameObject.SetActive(false);
                craftAllowed = true;
            }
            if (menuOpened)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    craftingPanel.SetActive(false);
                    craftPromptText.gameObject.SetActive(true);
                    menuOpened = false;
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("masuk gubug");
            withinPondokRange = true;
            craftPromptText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            craftingPanel.SetActive(false);
            Debug.Log("keluar gubug");
            withinPondokRange = false;
            craftPromptText.gameObject.SetActive(false);
        }
    }

    private void OpenCraftingMenu()
    {
        craftingPanel.SetActive(true);
        menuOpened = true;
        Debug.Log("Menu kebuka: " + menuOpened);
    }

    private void CloseCraftingMenu()
    {
        craftingPanel.SetActive(false);
        menuOpened = false;
        Debug.Log("Menu kebuka: " + menuOpened);
    }

    private void Crafting()
    {

    }
}
