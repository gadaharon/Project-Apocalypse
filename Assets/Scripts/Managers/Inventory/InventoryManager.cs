using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> ItemList => itemList;
    public int Coins => coins;
    public int Gems => gems;

    List<Item> itemList;

    int coins = 0;
    int gems = 0;


    void Awake()
    {
        Init();
        // TODO add persistance to this manager
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
        itemList = new List<Item>();
        AddItem(new Item { itemType = Item.ItemType.Gun, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Shotgun, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Rifle, amount = 1 });
    }

    public void AddItem(Item item)
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

    public Item.ItemType GetListItemType(int index)
    {
        return itemList[index].itemType;
    }
}
