using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    [SerializeField] GameObject pickup;

    Health health;
    Animator animator;
    LootBag lootBag;
    LevelManager levelManager;

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

    public void SetLevelManager(LevelManager levelManager)
    {
        this.levelManager = levelManager;
    }

    void HandleDeath(Health sender)
    {
        PlayDeathAnimation();
    }

    public void PlayDeathAnimation()
    {
        animator.Play(DEATH_ANIMATION);
    }

    // being called has animation event
    void Die()
    {
        // create pickup
        lootBag.InstantiateLoot(transform.position);
        Destroy(gameObject);
        levelManager?.DecreaseEnemiesInWave();
    }
}
