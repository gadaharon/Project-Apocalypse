using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;

    void Start()
    {
        // Debug.Log(inventory.ItemList.Count);
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }



    void RefreshInventoryItems()
    {
        int i = 0;
        foreach (Transform slot in transform)
        {
            if (i < inventory.ItemList.Count)
            {
                slot.gameObject.SetActive(true);
                Image image = slot.Find("Slot Item").GetComponent<Image>();
                image.sprite = inventory.ItemList[i].GetSprite();
                // Debug.Log(inventory.ItemList.Count);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
            i++;
        }
    }


}
