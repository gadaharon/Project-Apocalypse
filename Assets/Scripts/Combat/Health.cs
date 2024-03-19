using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action<Health> OnDeath;
    public static Action OnHealthAdd;

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

    public void AddHealth(int amount)
    {
        OnHealthAdd?.Invoke();
        if ((currentHealth + amount) >= startingHealth)
        {
            ResetHealth();
            return;
        }
        currentHealth += amount;
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
