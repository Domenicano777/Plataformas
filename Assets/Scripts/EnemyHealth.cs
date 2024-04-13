using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; 
    private int currentHealth; 

    void Start()
    {
        currentHealth = maxHealth; 
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 
        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

    void Die()
    {
        // Aquí puedes agregar cualquier lógica que desees cuando el enemigo muera, como reproducir una animación, reproducir un sonido, etc.
        Destroy(gameObject); // Destruir el GameObject del enemigo
    }
}
