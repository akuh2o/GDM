using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importar para manejar escenas

public class bulletmove : MonoBehaviour
{
    [SerializeField] private float speed;

    void Start()

    {
        Destroy(gameObject, 2f); // Destroy the bullet after 2 seconds to prevent memory leaks
    }


    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null) return;

        Idamage enemyDamage = collision.gameObject.GetComponent<Idamage>();

        if (enemyDamage != null)
        {
            enemyDamage.TakeDamage(10); // Llamar al método TakeDamage con un valor de 10
            Debug.Log("Bullet hit: " + collision.gameObject.name);
        }

        Destroy(gameObject); // Destruir el proyectil al colisionar con cualquier cosa
    }


}