using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takedamage : MonoBehaviour
{
    [SerializeField] private int vida; // Health or damage value\
   

    // Update is called once per frame
    void Update()
    {
        // Check if the object has taken damage
        if (vida <= 0)
        {
            // Handle the case when the object is destroyed or dead
            Destroy(gameObject); // Destroy the object when health reaches zero
        }
        

    }
}
