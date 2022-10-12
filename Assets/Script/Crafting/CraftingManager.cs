using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public GameObject gubug;
    public GameObject craftingPanel;
    public TextMeshProUGUI craftPromptText;

    private bool craftAllowed;
    // Start is called before the first frame update
    void Start()
    {
        craftAllowed = false;
        craftPromptText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (craftAllowed && Input.GetKeyDown(KeyCode.E))
        {
            craftingPanel.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            craftPromptText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("masuk gubug");
            craftAllowed = true;
            craftPromptText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            craftingPanel.SetActive(false);
            Debug.Log("masuk gubug");
            craftAllowed = false;
            craftPromptText.gameObject.SetActive(false);
        }
    }

    private void Crafting()
    {

    }
}
