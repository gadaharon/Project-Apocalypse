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
            SetAmmoStateUI();
        }
    }

    void SetAmmoStateUI()
    {
        if (selectedWeapon.WeaponType == WeaponSO.WeaponType.Pistol)
        {
            // TODO change to infinity sing or something else to indicate for infinite ammo
            ammoText.text = "*/*";
        }
        else
        {
            ammoText.text = $"{selectedWeapon.CurrentAmmo}/{selectedWeapon.AmmoCapacity}";
        }
    }

    void SetSelectedWeapon(WeaponSwitchingManager weaponSwitchingManager)
    {
        selectedWeapon = weaponSwitchingManager.selectedWeaponGO;
    }
}
