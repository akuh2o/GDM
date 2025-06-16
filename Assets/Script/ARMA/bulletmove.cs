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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Idamage damageable = collision.gameObject.GetComponent<Idamage>();
            if (damageable != null)
            {
                damageable.TakeDamage(10); // Assuming the bullet does 10 damage
                Debug.Log("Enemy hit by bullet");
            }
            Destroy(gameObject); // Destroy the bullet on impact
        }
        
    }
}
