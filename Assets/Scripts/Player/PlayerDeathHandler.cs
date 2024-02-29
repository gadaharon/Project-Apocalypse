using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    Health health;
    Animator animator;

    readonly int DEATH_ANIMATION = Animator.StringToHash("DeathAnimation");

    void Awake()
    {
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        health.OnDeath += HandleDeath;
    }

    void OnDisable()
    {
        health.OnDeath -= HandleDeath;
    }

    void HandleDeath(Health sender)
    {
        animator.Play(DEATH_ANIMATION);
        // Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
