using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] List<GameObject> enemiesPrefabs;
    [SerializeField] float spawnOffset = 1f;

    Transform parentTransform;
    LevelManager levelManager;

    void Start()
    {

        StartCoroutine(SpawnEnemy());
    }

    public void Init(Transform parentTransform, LevelManager levelManager)
    {
        this.parentTransform = parentTransform;
        this.levelManager = levelManager;
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnOffset);
        GameObject randomEnemyPrefab = GetRandomEnemyPrefab();
        if (randomEnemyPrefab == null)
        {
            Debug.LogError("There are no enemies to spawn, check the enemiesPrefabs SerializedField");
        }
        GameObject enemy = Instantiate(randomEnemyPrefab, transform.position, transform.localRotation, parentTransform);
        enemy.GetComponent<EnemyDeathHandler>()?.SetLevelManager(levelManager);
        Destroy(gameObject);
    }

    GameObject GetRandomEnemyPrefab()
    {
        if (enemiesPrefabs.Count <= 0) return null;

        if (enemiesPrefabs.Count == 1) return enemiesPrefabs[0];

        int randomIndex = Random.Range(0, enemiesPrefabs.Count);
        return enemiesPrefabs[randomIndex];
    }
}
