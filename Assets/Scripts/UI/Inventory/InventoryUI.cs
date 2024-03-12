using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] ItemAssets itemAssets;

    InventoryManager inventory;
    List<WeaponSO> weapons;


    void Start()
    {
        inventory = GameManager.Instance.Inventory;
        weapons = inventory.GetAllWeapons();
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
            if (i < weapons.Count)
            {
                slot.gameObject.SetActive(true);
                Image image = slot.Find("Slot Item").GetComponent<Image>();
                image.sprite = GetSlotSprite(weapons[i]);
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
