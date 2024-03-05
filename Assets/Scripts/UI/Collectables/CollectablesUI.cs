using TMPro;
using UnityEngine;

public class CollectablesUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI gemText;

    InventoryManager inventory;

    void Start()
    {
        inventory = GameManager.Instance.Inventory;
    }

    void Update()
    {
        coinsText.text = inventory.Coins.ToString();
        gemText.text = inventory.Gems.ToString();
    }
}
