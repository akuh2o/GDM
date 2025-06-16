using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour, Idamage
{
    [SerializeField] private int vida = 100; // Health of the enemy, default is 100

    public void TakeDamage(int damage)
    {
        // Reduce the health by the damage amount
        vida -= damage; // Subtract the damage from the health
        Debug.Log("Enemy took damage: " + damage + ", remaining health: " + vida);


        if (vida <= 0)
        {
            // Handle the case when the object is destroyed or dead

            Destroy(gameObject); // Destroy the object when health reaches zero

        }
      
    }
}
