using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ammoText;

    Gun selectedWeapon;

    void OnEnable()
    {
        WeaponSwitchingManager.OnWeaponSelectChange += SetSelectedWeapon;
    }

    void OnDisable()
    {
        WeaponSwitchingManager.OnWeaponSelectChange -= SetSelectedWeapon;
    }

    void Update()
    {
        if (selectedWeapon != null)
        {
            SetAnnoStateUI();
        }
    }

    void SetAnnoStateUI()
    {
        if (selectedWeapon.ItemType == Item.ItemType.Gun)
        {
            // TODO change to infinity sing or something else to indicate for infinite ammo
            ammoText.text = "*/*";
        }
        else
        {
            ammoText.text = $"{selectedWeapon.CurrentAmmo}/{selectedWeapon.MaxAmmo}";
        }
    }

    void SetSelectedWeapon(WeaponSwitchingManager weaponSwitchingManager)
    {
        selectedWeapon = weaponSwitchingManager.selectedWeaponGO;
    }
}
