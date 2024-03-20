using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InventoryManager Inventory => inventoryManager;
    public AmmoManager AmmoManager => ammoManager;

    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] AmmoManager ammoManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GameOver()
    {
        UIManager.Instance.ShowGameOverCanvas();
    }

    public void LoadNextLevel()
    {
        LoadScene("Level 2");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void DestroyPersistentParent()
    {
        GameObject persistentParent = GameObject.FindGameObjectWithTag("PersistentParent");
        if (persistentParent != null)
        {
            Destroy(persistentParent);
        }
    }

    public void RestartGame()
    {
        DestroyPersistentParent();
        StartGame();
    }

    public void LoadMainMenuScene()
    {
        DestroyPersistentParent();
        LoadScene("Main Menu");
    }

    public void StartGame()
    {
        Debug.Log("START GAME");
        LoadScene("Sandbox");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
