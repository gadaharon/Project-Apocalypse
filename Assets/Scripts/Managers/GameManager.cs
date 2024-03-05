using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InventoryManager Inventory => inventoryManager;

    [SerializeField] InventoryManager inventoryManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
