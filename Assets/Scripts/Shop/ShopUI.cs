using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Header("Weapon Slot Details")]
    [SerializeField] TextMeshProUGUI weaponSlotTitle;
    [SerializeField] TextMeshProUGUI weaponSlotPriceText;
    [SerializeField] Image weaponSlotImage;

    [Header("Medkit Slot Details")]
    [SerializeField] TextMeshProUGUI medkitSlotTitle;
    [SerializeField] TextMeshProUGUI medkitSlotPriceText;
    [SerializeField] Image medkitSlotImage;

    [Header("Ammunition Slot Details")]
    [SerializeField] TextMeshProUGUI ammoSlotTitle;
    [SerializeField] TextMeshProUGUI ammoSLotPriceText;
    [SerializeField] Image ammoSlotImage;

    public void SetMedkitSlotDetails(ShopItemSO shopItemSO, bool isActive)
    {
        if (!isActive)
        {
            HideMedkitSlot();
        }
        medkitSlotTitle.text = shopItemSO.title;
        medkitSlotPriceText.text = shopItemSO.price.ToString();
        medkitSlotImage.sprite = shopItemSO.itemSprite;
    }
    public void SetWeaponSlotDetails(ShopItemSO shopItemSO, bool isActive)
    {
        if (!isActive)
        {
            HideWeaponSlot();
        }
        weaponSlotTitle.text = shopItemSO.title;
        weaponSlotPriceText.text = shopItemSO.price.ToString();
        weaponSlotImage.sprite = shopItemSO.itemSprite;
    }
    public void SetAmmoSlotDetails(ShopItemSO shopItemSO, bool isActive)
    {
        if (!isActive)
        {
            HideAmmoSlot();
        }
        ammoSlotTitle.text = shopItemSO.title;
        ammoSLotPriceText.text = shopItemSO.price.ToString();
        ammoSlotImage.sprite = shopItemSO.itemSprite;
    }

    public void HideMedkitSlot()
    {
        medkitSlotTitle.transform.parent.gameObject.SetActive(false);
    }
    public void HideWeaponSlot()
    {
        weaponSlotTitle.transform.parent.gameObject.SetActive(false);
    }
    public void HideAmmoSlot()
    {
        ammoSlotTitle.transform.parent.gameObject.SetActive(false);
    }
}
