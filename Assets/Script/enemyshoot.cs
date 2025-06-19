using UnityEngine;

public class enemyshoot : MonoBehaviour
{
    public int damage = 10; // Daño que el enemigo inflige al jugador

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisiona es el jugador
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}


