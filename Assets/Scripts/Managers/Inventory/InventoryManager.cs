using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static Action<InventoryManager> OnInventoryChange;
    public List<Item> ItemList => itemList;

    List<Item> itemList;


    void Awake()
    {
        Init();
        // TODO add persistance to this manager
    }

    void Start()
    {
        OnInventoryChange?.Invoke(this);
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

    public Item.ItemType GetListItemType(int index)
    {
        return itemList[index].itemType;
    }
}
