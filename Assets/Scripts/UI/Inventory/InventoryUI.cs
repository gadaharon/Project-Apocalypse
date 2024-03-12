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
                image.sprite = GetSlotSprite(inventory.ItemList[i]);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
            i++;
        }
    }

    Sprite GetSlotSprite(ItemSO item)
    {
        if (item.itemType == ItemSO.ItemType.Weapon)
        {
            return GetWeaponSprite(item as WeaponSO);
        }
        return null;
    }

    Sprite GetWeaponSprite(WeaponSO weapon)
    {
        switch (weapon.weaponType)
        {
            default:
            case WeaponSO.WeaponType.Pistol:
                return itemAssets.gunSprite;
            case WeaponSO.WeaponType.Shotgun:
                return itemAssets.shotgunSprite;
            case WeaponSO.WeaponType.Rifle:
                return itemAssets.rifleSprite;
        }
    }
}
