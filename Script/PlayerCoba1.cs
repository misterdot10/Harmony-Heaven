using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCoba1 : MonoBehaviour
{
    public int b = 0;
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void ProcessBValue(int bValue)
    {
        b = bValue;
    }

    void Update()
    {
        if (b == 1)
        {
            TakeDamage(20);
            b = 0;
        }
    }

    void TakeDamage(int damage)
    {   
      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);
    }
}