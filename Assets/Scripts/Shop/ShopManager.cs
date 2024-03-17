using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    const string SHOP_ITEM_WEAPON = "Weapon";
    const string SHOP_ITEM_MEDKIT = "Medkit";
    const string SHOP_ITEM_AMMUNITION = "Ammunition";

    [Header("Shop content")]
    [SerializeField] List<ShopItemSO> shopContent;

    InventoryManager inventory;
    AmmoManager ammoManager;
    ShopUI shopUI;
    Dictionary<string, ShopItemSO> shopList = new Dictionary<string, ShopItemSO>();

    void Awake()
    {
        shopUI = GetComponent<ShopUI>();
    }

    void Start()
    {
        inventory = GameManager.Instance.Inventory;
        ammoManager = GameManager.Instance.AmmoManager;
        InitStoreContent();
    }

    void InitStoreContent()
    {
        List<ShopItemSO> weapons = new List<ShopItemSO>();
        foreach (ShopItemSO shopItemSO in shopContent)
        {
            if (shopItemSO.itemType == ItemSO.ItemType.Ammunition)
            {
                shopList.TryAdd(SHOP_ITEM_AMMUNITION, shopItemSO);
                shopUI.SetAmmoSlotDetails(shopList[SHOP_ITEM_AMMUNITION], CanBuyAmmo());
            }
            if (shopItemSO.itemType == ItemSO.ItemType.MedKit)
            {
                shopList.TryAdd(SHOP_ITEM_MEDKIT, shopItemSO);
                shopUI.SetMedkitSlotDetails(shopList[SHOP_ITEM_MEDKIT], true);
            }
            else if (shopItemSO.itemType == ItemSO.ItemType.Weapon && !IsExistsInInventory(shopItemSO.item.itemId))
            {
                weapons.Add(shopItemSO);
            }
        }
        bool weaponInShop = weapons.Count > 0;
        if (!weaponInShop)
        {
            shopUI.HideWeaponSlot();
        }
        else
        {
            int randomWeaponIndex = Random.Range(0, weapons.Count);
            shopList.TryAdd(SHOP_ITEM_WEAPON, weapons[randomWeaponIndex]);
            shopUI.SetWeaponSlotDetails(shopList[SHOP_ITEM_WEAPON], weaponInShop);
        }
    }

    void HideItemSlot(string itemType)
    {
        switch (itemType)
        {
            case SHOP_ITEM_AMMUNITION:
                shopUI.HideAmmoSlot();
                return;
            case SHOP_ITEM_MEDKIT:
                shopUI.HideMedkitSlot();
                return;
            case SHOP_ITEM_WEAPON:
                shopUI.HideWeaponSlot();
                return;
        }
    }

    bool IsExistsInInventory(string itemId)
    {
        return inventory.InventoryItems.ContainsKey(itemId);
    }

    bool CanBuyAmmo()
    {
        return inventory.GetAllWeapons().Count > 1;
    }

    public void PurchaseItem(string itemType)
    {
        if (shopList[itemType].price > inventory.Coins)
        {
            Debug.Log("Not enough coins to purchase");
            return;
        }
        if (itemType == SHOP_ITEM_AMMUNITION)
        {
            HandleAmmoPurchase();
        }
        else
        {
            HandleItemPurchase(itemType);
        }
        HideItemSlot(itemType);
        inventory.DecreaseCoinsAmount(shopList[itemType].price);
    }

    void HandleItemPurchase(string itemType)
    {
        if (!inventory.AddItem(shopList[itemType].item))
        {
            Debug.Log("Item already exists in inventory");
        }
    }

    void HandleAmmoPurchase()
    {
        WeaponSO weapon;
        foreach (WeaponSO weaponItem in inventory.GetAllWeapons())
        {
            weapon = inventory.InventoryItems[weaponItem.itemId] as WeaponSO;
            ammoManager.AddAmmo(weapon.ammo, weapon.ammo.maxCapacity);
        }
    }

    public void HandleNextLevelButton()
    {
        GameManager.Instance.LoadNextLevel();
    }
}
