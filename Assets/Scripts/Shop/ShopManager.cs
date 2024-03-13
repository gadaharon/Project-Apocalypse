using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Weapon Slot Details")]
    [SerializeField] TextMeshProUGUI weaponSlotTitle;
    [SerializeField] TextMeshProUGUI weaponSlotPriceText;

    [Header("Medkit Slot Details")]
    [SerializeField] TextMeshProUGUI medkitSlotTitle;
    [SerializeField] TextMeshProUGUI medkitSlotPriceText;

    [Header("Shop Items List")]
    [SerializeField] List<ShopItemSO> shopListItems;

    int randomWeaponIndex;

    void Start()
    {
        InitStoreContent();
    }

    void InitStoreContent()
    {
        List<ShopItemSO> weaponsToDisplay = new List<ShopItemSO>();
        foreach (ShopItemSO shopItemSO in shopListItems)
        {
            if (shopItemSO.item.itemType == ItemSO.ItemType.MedKit)
            {
                medkitSlotTitle.text = shopItemSO.title;
                medkitSlotPriceText.text = shopItemSO.price.ToString();
            }
            else if (shopItemSO.item.itemType == ItemSO.ItemType.Weapon)
            {
                weaponsToDisplay.Add(shopItemSO);
            }
        }
        if (weaponsToDisplay.Count > 0)
        {
            randomWeaponIndex = UnityEngine.Random.Range(0, weaponsToDisplay.Count);
            weaponSlotTitle.text = weaponsToDisplay[randomWeaponIndex].title;
            weaponSlotPriceText.text = weaponsToDisplay[randomWeaponIndex].price.ToString();
        }
    }

    public void PurchaseItem(string itemType)
    {
        switch (itemType)
        {
            case "Weapon":
                // buy weapon
                Debug.Log("I'm buying a weapon!!");
                break;
            case "Medkit":
                Debug.Log("Oh!!! a medkit!!");
                // buy medkit
                break;
            case "Ammunition":
                Debug.Log("Time for some ammo");
                // refill ammo
                break;
        }
    }

    /*
        --- Add this when connecting to game flow ---
        foreach(ShopItemSO shopItem in shopListItems) {
            if(shopItem.item.itemType == ItemSO.ItemType.Weapon) {
                if(!inventory.InventoryItems.ContainKey(shopItem.item.itemId)) {
                    can show on ui....
                }
            }
        }
    */
}
