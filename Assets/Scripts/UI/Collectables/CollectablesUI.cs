using TMPro;
using UnityEngine;

public class CollectablesUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    InventoryManager inventory;

    void Start()
    {
        inventory = GameManager.Instance.Inventory;
    }

    void Update()
    {
        coinsText.text = inventory.Coins.ToString();
    }
}
