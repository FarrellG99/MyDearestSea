using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Splash : MonoBehaviour
{
    public Transform InpLoadingBar;
    public GameObject Button_UjiCoba;
    [SerializeField] private float nilaiSekarang;
    [SerializeField] private float nilaiKec;

    void Update()
    {
        if (nilaiSekarang < 100)
        {
            nilaiSekarang += nilaiKec * Time.deltaTime;
            Debug.Log((int)nilaiSekarang);
        }
        else
        {
            Button_UjiCoba.SetActive(true);
            // SceneManager.LoadScene("Prologue");
        }
        InpLoadingBar.GetComponent<Image>().fillAmount = nilaiSekarang / 100;


    }

    public void PindahScene()
    {
        SceneManager.LoadScene("Prologue");
    }
}
