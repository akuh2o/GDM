using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmove : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    void Start()
    {
        // Destruye la bala después de 2 segundos para evitar acumulación en la escena
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        // Mueve la bala hacia adelante en su eje local
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
