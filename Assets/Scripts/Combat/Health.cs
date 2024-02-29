using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action<Health> OnDeath;
    public int StartingHealth => startingHealth;
    public int CurrentHealth => currentHealth;
    public bool isDead => currentHealth <= 0;

    [SerializeField] int startingHealth = 3;

    int currentHealth;

    void Awake()
    {
        ResetHealth();
    }

    void ResetHealth()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke(this);
        }
    }
}
