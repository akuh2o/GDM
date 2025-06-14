using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importar para manejar escenas

public class bulletmove : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()

    {
        Destroy(gameObject, 2f); // Destroy the bullet after 2 seconds to prevent memory leaks
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
