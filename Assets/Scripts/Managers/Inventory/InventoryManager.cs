using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // public static Action<InventoryManager> OnInventoryChange; DON'T DELETE YET
    public List<Item> ItemList => itemList;
    public int Coins => coins;

    List<Item> itemList;

    int coins = 0;


    void Awake()
    {
        Init();
        // TODO add persistance to this manager
    }

    //  =====DON'T DELETE YET====
    // void Start()
    // {
    //     OnInventoryChange?.Invoke(this);
    // }

    void OnEnable()
    {
        Coin.OnCoinCollected += HandleCollectCoins;
    }

    void OnDisable()
    {
        Coin.OnCoinCollected -= HandleCollectCoins;
    }


    void Init()
    {
        itemList = new List<Item>();
        AddItem(new Item { itemType = Item.ItemType.Gun, amount = 1 });
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        // OnInventoryChange?.Invoke(this);
    }

    void HandleCollectCoins(Coin coin)
    {
        IncreaseCoinsAmount(coin.CoinAmount);
    }

    void IncreaseCoinsAmount(int coinAmount)
    {
        coins += coinAmount;
    }

    void DecreaseCoinsAmount(int coinAmount)
    {
        coins -= coinAmount;
    }

    public Item.ItemType GetListItemType(int index)
    {
        return itemList[index].itemType;
    }
}
