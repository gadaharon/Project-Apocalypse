using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    [SerializeField] GameObject pickup;

    Health health;
    Animator animator;
    LootBag lootBag;

    readonly int DEATH_ANIMATION = Animator.StringToHash("DeathAnimation");

    void Awake()
    {
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();
        lootBag = GetComponent<LootBag>();
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
    }

    // being called has animation event
    void Die()
    {
        // create pickup
        // Instantiate(pickup, transform.position, Quaternion.identity);
        lootBag.InstantiateLoot(transform.position);
        Destroy(gameObject);
    }
}
