using TMPro;
using UnityEngine;

public class LevelInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelNumberText;
    [SerializeField] TextMeshProUGUI enemiesInWaveText;
    [SerializeField] TextMeshProUGUI levelCompletedText;

    LevelManager levelManager;

    void Awake()
    {
        levelManager = GetComponent<LevelManager>();
        levelCompletedText.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        LevelManager.OnLevelCompleted += HandleLevelCompleteUI;
    }

    void OnDisable()
    {
        LevelManager.OnLevelCompleted -= HandleLevelCompleteUI;
    }

    void Update()
    {
        enemiesInWaveText.text = levelManager.EnemiesInWave.ToString();
    }

    void HandleLevelCompleteUI()
    {
        levelCompletedText.gameObject.SetActive(true);
    }
}
