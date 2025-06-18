using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CargarEscenaConCarga : MonoBehaviour
{
    public string escenaADesplegar = "SampleScene"; 
    public float tiempoMinimoPantalla = 2f;

    void Start()
    {
        StartCoroutine(CargarEscena());
    }

    IEnumerator CargarEscena()
    {
        float tiempoInicio = Time.time;

        AsyncOperation operacion = SceneManager.LoadSceneAsync(escenaADesplegar);
        operacion.allowSceneActivation = false;

        
        while (Time.time - tiempoInicio < tiempoMinimoPantalla)
        {
            yield return null;
        }

       
        while (operacion.progress < 0.9f)
        {
            yield return null;
        }

        
        operacion.allowSceneActivation = true;
    }
}
