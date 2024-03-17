using System.Collections;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
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
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.localRotation, parentTransform);
        enemy.GetComponent<EnemyDeathHandler>()?.SetLevelManager(levelManager);
        Destroy(gameObject);
    }
}
