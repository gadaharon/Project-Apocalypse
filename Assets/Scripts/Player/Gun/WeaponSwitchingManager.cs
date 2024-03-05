using UnityEngine;

public class WeaponSwitchingManager : MonoBehaviour
{
    public Item.ItemType SelectedWeapon => selectedWeapon;

    [SerializeField] InventoryManager inventory;

    Item.ItemType selectedWeapon = 0;

    void Start()
    {
        selectedWeapon = inventory.GetListItemType(0);
        SelectWeapon();
    }

    void Update()
    {
        Item.ItemType previousSelectedWeapon = selectedWeapon;

        HandleInputs();

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventory.ItemList.Count >= 1)
        {
            selectedWeapon = inventory.GetListItemType(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && inventory.ItemList.Count >= 2)
        {
            selectedWeapon = inventory.GetListItemType(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 && inventory.ItemList.Count >= 3)
        {
            selectedWeapon = inventory.GetListItemType(2);
        }
        // else if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4) // TBD Rocket Launcher
        // {
        //     selectedWeapon = 3;
        // }
    }

    void SelectWeapon()
    {
        // Select weapon according to the itemType in the inventory
        foreach (Transform weapon in transform)
        {
            Item.ItemType weaponType = weapon.GetComponent<Gun>().ItemType;
            if (weaponType == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
        }
    }
}
