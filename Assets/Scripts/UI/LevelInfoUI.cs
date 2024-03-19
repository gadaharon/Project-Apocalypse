using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelNumberText;
    [SerializeField] TextMeshProUGUI enemiesInWaveText;
    [SerializeField] TextMeshProUGUI levelCompletedText;
    [SerializeField] Button levelCompleteButton;

    LevelManager levelManager;

    void Awake()
    {
        levelManager = GetComponent<LevelManager>();
        levelCompletedText.gameObject.SetActive(false);
        levelCompleteButton.gameObject.SetActive(false);
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
        if (levelManager.EnemiesInWave <= 0)
        {
            enemiesInWaveText.text = "0";
        }
        else
        {
            enemiesInWaveText.text = levelManager.EnemiesInWave.ToString();
        }
    }

    void HandleLevelCompleteUI()
    {
        levelCompletedText.gameObject.SetActive(true);
        levelCompleteButton.gameObject.SetActive(true);
    }
}
