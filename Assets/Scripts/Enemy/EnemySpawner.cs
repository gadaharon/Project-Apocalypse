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
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.localRotation, parentTransform);
            enemy.GetComponent<EnemyDeathHandler>()?.SetLevelManager(levelManager);
            float spawnRange = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnRange);
        }
    }
}
