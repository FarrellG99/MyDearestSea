using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pausePanel;
    private bool pauseActive;
    public InventoryObject junkInventory;
    public InventoryObject toolInventory;

    // Start is called before the first frame update
    void Start()
    {
        pauseActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape)){
                Pause();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape)){
                Unpause();
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        junkInventory.Container.Clear();
        toolInventory.Container.Clear();
        Time.timeScale = 1;
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        pauseActive = true;
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseActive = false;
        Cursor.visible = false;
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainmenu");
    }
}
