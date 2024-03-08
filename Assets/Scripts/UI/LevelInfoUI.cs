using TMPro;
using UnityEngine;

public class LevelInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelNumberText;
    [SerializeField] TextMeshProUGUI enemiesInWaveText;

    LevelManager levelManager;

    void Awake()
    {
        levelManager = GetComponent<LevelManager>();
    }

    void Update()
    {
        enemiesInWaveText.text = levelManager.EnemiesInWave.ToString();
    }
}
