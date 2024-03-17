using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnPointPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform parentTransform;
    [SerializeField] LevelManager levelManager;

    [Header("Spawn time range:")]
    [SerializeField] float minSpawnTime = 6f;
    [SerializeField] float maxSpawnTime = 8f;

    [Header("Spawn points range")]
    [SerializeField] int minSpawnPoints = 4;
    [SerializeField] int maxSpawnPoints = 8;

    [SerializeField] Collider2D confiner;

    Bounds spawnBounds;

    void Awake()
    {
        spawnBounds = confiner.bounds;
    }

    void Start()
    {
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
            Vector2[] spawnPoints = getSpawnPoints();
            foreach (Vector2 spawnPoint in spawnPoints)
            {
                GameObject instance = Instantiate(spawnPointPrefab, spawnPoint, transform.localRotation);
                instance.GetComponent<SpawnPoint>().Init(parentTransform, levelManager);
            }
            float spawnRange = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnRange);
        }
    }

    Vector2[] getSpawnPoints()
    {
        int numberOfPositions = Random.Range(minSpawnPoints, maxSpawnPoints);
        Vector2[] positions = new Vector2[numberOfPositions];
        for (int i = 0; i < numberOfPositions; i++)
        {
            positions[i] = GetSpawnPoint();
        }
        return positions;
    }

    Vector2 GetSpawnPoint()
    {
        float xPos = Random.Range(spawnBounds.min.x, spawnBounds.max.x);
        float yPos = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
        return new Vector2(xPos, yPos);
        // if (isVertical)
        // {
        //     float randomYPos = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
        //     return new Vector2(transform.position.x, randomYPos);
        // }
        // float randomXPos = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
        // return new Vector2(randomXPos, transform.position.y);
    }
}
