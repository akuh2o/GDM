using UnityEngine;

public class colider : MonoBehaviour
{
    [SerializeField] private int vida = 10;

    // Este script debe estar en el objeto "shaft"
    public void TakeDamage(int damage)
    {
        vida -= damage;
        Debug.Log("El enemigo ha recibido daño. Salud restante: " + vida);

        if (vida <= 0)
        {
            Destroy(gameObject);
            Debug.Log("El enemigo ha sido destruido.");
        }
    }

    // Detecta colisiones físicas solo con objetos con tag "Enemigo"
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Por ejemplo, cada colisión hace 5 de daño
            TakeDamage(5);
        }
    }
}
