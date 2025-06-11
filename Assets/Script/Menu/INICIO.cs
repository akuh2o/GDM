using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class INICIO : MonoBehaviour
{

    public void ChangeScene(int sceneName)
    {
        // Cargar la escena del juego
        SceneManager.LoadScene(sceneName);
    }
}
