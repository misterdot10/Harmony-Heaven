using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoba2 : MonoBehaviour
{
    public int c = 0;
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void ProcessCValue(int cValue)
    {
        c = cValue;
    }

    void Update()
    {
        if (c == 1)
        {
            TakeDamage(20);
            c = 0;
        }
    }

    void TakeDamage(int damage)
    {   
      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);
    }
}