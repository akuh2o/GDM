using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject trollPrefab; // Prefab del troll a instanciar
    public int cantidadTrolls = 5; // Número de trolls a spawnear
    public float radioSpawn = 5f; // Radio alrededor del objeto para spawnear

    void Start()
    {
        SpawnTrolls();
    }

    void SpawnTrolls()
    {
        for (int i = 0; i < cantidadTrolls; i++)
        {
            Vector3 posicionAleatoria = transform.position + Random.insideUnitSphere * radioSpawn;
            posicionAleatoria.y = transform.position.y; // Mantener la misma altura
            Instantiate(trollPrefab, posicionAleatoria, Quaternion.identity);
        }
    }
}
