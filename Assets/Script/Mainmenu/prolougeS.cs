using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prolougeS : MonoBehaviour
{
    public string namaScene;

    public void PindahScene()
    {
        Scene sceneIni = SceneManager.GetActiveScene();

        if (sceneIni.name != namaScene)
        {
            SceneManager.LoadScene(namaScene);
        }

    }
}
