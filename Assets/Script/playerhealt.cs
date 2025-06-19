using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class   Player : MonoBehaviour
{
    public int currentHealth;
    public Animator animator;
    public int vida = 100;


    void Start()
    {
        currentHealth = vida;
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (animator != null)
        {
            animator.SetTrigger("Golpeado");
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (animator != null)
            animator.SetTrigger("Morir");
        // Aqu� puedes desactivar el objeto o destruirlo
        Destroy(gameObject, 1.5f); // Espera 1.5 segundos para que la animaci�n se reproduzca
        UnityEngine.SceneManagement.SceneManager.LoadScene("Derrota");
    }
   
}
