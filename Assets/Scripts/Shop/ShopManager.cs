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
            int randomIndex = Random.Range(0, weaponsToDisplay.Count);
            ShopItemSO randomWeaponToDisplay = weaponsToDisplay[randomIndex];
            weaponSlotTitle.text = randomWeaponToDisplay.title;
            weaponSlotPriceText.text = randomWeaponToDisplay.price.ToString();
        }


    }

    /*
        foreach(ShopItemSO shopItem in shopListItems) {
            if(shopItem.item.itemType == ItemSO.ItemType.Weapon) {
                if(!inventory.InventoryItems.ContainKey(shopItem.item.itemId)) {
                    can show on ui....
                }
            }
        }
    */
}
