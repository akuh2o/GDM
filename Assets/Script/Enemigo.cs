using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour, Idamage
{
    [SerializeField] private int vida = 100; // Health of the enemy, default is 100


    private void Start()
    {
        // Initialization code if needed
    }
    public void TakeDamage(int damage)
    {
        vida -= damage; // Reduce enemy health by the damage amount
        Debug.Log($"Enemy took {damage} damage, remaining health: {vida}");

        if (vida <= 0)
        {
            Destroy(gameObject); 
        }
    }
}
