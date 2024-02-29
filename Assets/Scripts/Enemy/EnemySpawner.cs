using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform parentTransform;

    [Header("Spawn time range:")]
    [SerializeField] float minSpawnTime = 6f;
    [SerializeField] float maxSpawnTime = 8f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (PlayerController.Instance) // Spawn enemies as long the player alive
        {
            Instantiate(enemyPrefab, transform.position, transform.localRotation, parentTransform);
            float spawnRange = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnRange);
        }
    }
}
