using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitchingManager : MonoBehaviour
{
    public static Action<WeaponSwitchingManager> OnWeaponSelectChange;

    // public Item.ItemType SelectedWeapon => selectedWeapon;
    public WeaponSO.WeaponType SelectedWeapon => selectedWeapon;
    public Gun selectedWeaponGO { get; private set; }

    InventoryManager inventory;
    List<WeaponSO> weapons;

    // Item.ItemType selectedWeapon = 0;
    WeaponSO.WeaponType selectedWeapon;

    void Start()
    {
        // weapons = GameManager.Instance.Inventory.GetAllWeapons();
        inventory = GameManager.Instance.Inventory;
        if (inventory != null)
        {
            weapons = inventory.GetAllWeapons();

        }

        SelectWeapon();
    }

    void Update()
    {
        // Item.ItemType previousSelectedWeapon = selectedWeapon;

        // HandleInputs();

        // if (previousSelectedWeapon != selectedWeapon)
        // {
        //     SelectWeapon();
        // }

        WeaponSO.WeaponType previousSelectedWeapon = selectedWeapon;

        HandleInputs();

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void HandleInputs()
    {
        // if (Input.GetKeyDown(KeyCode.Alpha1) && inventory.ItemList.Count >= 1)
        // {
        //     selectedWeapon = inventory.GetListItemType(0);
        // }
        // else if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && inventory.ItemList.Count >= 2)
        // {
        //     selectedWeapon = inventory.GetListItemType(1);
        // }
        // else if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 && inventory.ItemList.Count >= 3)
        // {
        //     selectedWeapon = inventory.GetListItemType(2);
        // }

        if (Input.GetKeyDown(KeyCode.Alpha1) && weapons.Count >= 1)
        {
            selectedWeapon = weapons[0].weaponType;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && weapons.Count >= 2)
        {
            selectedWeapon = weapons[1].weaponType;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 && weapons.Count >= 3)
        {
            selectedWeapon = weapons[2].weaponType;
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
            WeaponSO.WeaponType weaponType = weapon.GetComponent<Gun>().WeaponType;
            if (weaponType == selectedWeapon)
            {
                selectedWeaponGO = weapon.gameObject.GetComponent<Gun>();
                weapon.gameObject.SetActive(true);
                OnWeaponSelectChange?.Invoke(this);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
        }
    }
}
