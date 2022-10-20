using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuS : MonoBehaviour
{
    public void MulaiGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void KeluarGame()
    {
        Application.Quit();
        Debug.Log("Metu game");
    }
}
