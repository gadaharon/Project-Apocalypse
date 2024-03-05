using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] ItemAssets itemAssets;

    InventoryManager inventory;


    void Start()
    {
        inventory = GameManager.Instance.Inventory;
        RefreshInventoryItems();
    }


    // ======DON'T DELETE YET======
    // void OnEnable()
    // {
    //     InventoryManager.OnInventoryChange += SetInventoryUI;
    // }

    // void OnDisable()
    // {
    //     InventoryManager.OnInventoryChange -= SetInventoryUI;
    // }

    // void SetInventoryUI(InventoryManager inventory)
    // {
    //     // if (this.inventory == null)
    //     // {
    //     //     this.inventory = inventory;
    //     // }
    //     RefreshInventoryItems();
    // }



    void RefreshInventoryItems()
    {
        int i = 0;
        foreach (Transform slot in transform)
        {
            if (i < inventory.ItemList.Count)
            {
                slot.gameObject.SetActive(true);
                Image image = slot.Find("Slot Item").GetComponent<Image>();
                image.sprite = GetSlotSprite(inventory.ItemList[i].itemType);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
            i++;
        }
    }

    Sprite GetSlotSprite(Item.ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case Item.ItemType.Gun:
                return itemAssets.gunSprite;
            case Item.ItemType.Shotgun:
                return itemAssets.shotgunSprite;
            case Item.ItemType.Rifle:
                return itemAssets.rifleSprite;
        }
    }
}
