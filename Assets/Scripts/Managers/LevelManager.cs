using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static Action OnLevelCompleted;
    public int EnemiesInWave => enemiesInWave;

    [SerializeField] int enemiesInWave = 10;



    public void DecreaseEnemiesInWave()
    {
        enemiesInWave--;

        if (enemiesInWave <= 0)
        {
            Debug.Log("Level completed");
            OnLevelCompleted?.Invoke();
            // level completed
            // GameManager.SetGameState(GameManager.State.LevelCompleted)
        }
    }
}
