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
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }
}
