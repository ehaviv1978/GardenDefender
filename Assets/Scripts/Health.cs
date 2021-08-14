using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int startingHealth = 10;
    [SerializeField] GameObject deathVFX;

    int currentHealth;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            if(deathVFX)
            {
                DeathAnimation();
            }
            Destroy(gameObject);
        }
    }

    void DeathAnimation()
    {
        var vfx = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(vfx, 1f);
    }
}
