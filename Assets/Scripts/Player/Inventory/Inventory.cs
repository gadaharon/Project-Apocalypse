using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> ItemList => itemList;

    [SerializeField] InventoryUI inventoryUI;
    List<Item> itemList;


    void Awake()
    {
        Init();
    }


    void Init()
    {
        itemList = new List<Item>();
        AddItem(new Item { itemType = Item.ItemType.Gun, amount = 1 });
        inventoryUI.SetInventory(this);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public Item.ItemType GetListItemType(int index)
    {
        return itemList[index].itemType;
    }


}
