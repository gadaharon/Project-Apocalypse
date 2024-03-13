using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // public List<ItemSO> ItemList => itemList;
    public Dictionary<string, ItemSO> InventoryItems => itemDictionary;
    public int Coins => coins;
    public int Gems => gems;

    // [SerializeField] ItemSO rifle;
    [SerializeField] List<ItemSO> itemList = new List<ItemSO>();

    AmmoManager ammoManager;
    Dictionary<string, ItemSO> itemDictionary = new Dictionary<string, ItemSO>();


    int coins = 0;
    int gems = 0;


    void Awake()
    {
        Init();
    }

    void OnEnable()
    {
        Coin.OnCoinCollected += HandleCollectCoins;
        Gem.OnGemCollected += HandleCollectGems;
    }

    void OnDisable()
    {
        Coin.OnCoinCollected -= HandleCollectCoins;
        Gem.OnGemCollected -= HandleCollectGems;
    }


    void Init()
    {
        ammoManager = GameManager.Instance.AmmoManager;
        AmmoSO weaponAmmo;
        // itemList.Add(rifle);
        foreach (ItemSO item in itemList)
        {
            itemDictionary.Add(item.itemId, item);

            // Add ammo to ammo inventory
            weaponAmmo = (item as WeaponSO).ammo;
            ammoManager.AddAmmo(weaponAmmo, weaponAmmo.maxCapacity);
        }
    }

    public void AddItem(ItemSO item)
    {
        itemList.Add(item);
    }

    void HandleCollectCoins(Coin coin)
    {
        IncreaseCoinsAmount(coin.CoinAmount);
    }

    void HandleCollectGems()
    {
        IncreaseGemsAmount(1);
    }

    void IncreaseCoinsAmount(int coinAmount)
    {
        coins += coinAmount;
    }

    void DecreaseCoinsAmount(int coinAmount)
    {
        coins -= coinAmount;
    }

    void IncreaseGemsAmount(int gemsAmount)
    {
        gems += gemsAmount;
    }

    void DecreaseGemsAmount(int gemsAmount)
    {
        gems -= gemsAmount;
    }

    public ItemSO.ItemType GetListItemType(int index)
    {
        return itemList[index].itemType;
    }

    public List<WeaponSO> GetAllWeapons()
    {
        List<WeaponSO> weapons = new List<WeaponSO>();
        foreach (KeyValuePair<string, ItemSO> item in itemDictionary)
        {
            if (item.Value.itemType == ItemSO.ItemType.Weapon)
            {
                weapons.Add(item.Value as WeaponSO);
            }
        }
        return weapons;
    }
}
