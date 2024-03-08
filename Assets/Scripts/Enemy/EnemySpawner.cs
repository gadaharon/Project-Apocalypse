using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform parentTransform;
    [SerializeField] LevelManager levelManager;

    [Header("Spawn time range:")]
    [SerializeField] float minSpawnTime = 6f;
    [SerializeField] float maxSpawnTime = 8f;

    Bounds spawnBounds;
    bool isVertical;

    void Awake()
    {
        spawnBounds = GetComponent<Collider2D>().bounds;
    }

    void Start()
    {
        isVertical = spawnBounds.size.y > spawnBounds.size.x;
        StartCoroutine(SpawnRoutine());
    }

    void OnEnable()
    {
        LevelManager.OnLevelCompleted += ClearAllEnemies;
    }

    void OnDisable()
    {
        LevelManager.OnLevelCompleted -= ClearAllEnemies;
    }

    void ClearAllEnemies()
    {
        foreach (Transform enemy in parentTransform)
        {
            Destroy(enemy.gameObject);
            // enemy.gameObject.GetComponent<EnemyDeathHandler>().PlayDeathAnimation();
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (PlayerController.Instance && levelManager.EnemiesInWave > 0) // Spawn enemies as long the player alive
        {
            Vector2 spawnPoint = GetSpawnPoint();
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint, transform.localRotation, parentTransform);
            enemy.GetComponent<EnemyDeathHandler>()?.SetLevelManager(levelManager);
            float spawnRange = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnRange);
        }
    }

    Vector2 GetSpawnPoint()
    {
        if (isVertical)
        {
            float randomYPos = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
            return new Vector2(transform.position.x, randomYPos);
        }
        float randomXPos = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
        return new Vector2(randomXPos, transform.position.y);
    }
}
