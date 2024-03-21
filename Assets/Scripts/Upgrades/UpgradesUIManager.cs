using UnityEngine;
using UnityEngine.UI;

public class UpgradesUIManager : MonoBehaviour
{
    [SerializeField] UITextGroup uITextGroup;
    [SerializeField] Transform ammoUpgradeSlot;
    [SerializeField] Button continueButton;


    void Awake()
    {
        uITextGroup.Init();
        ammoUpgradeSlot.gameObject.SetActive(false);
        continueButton.onClick.AddListener(() => GameManager.Instance.GoToStore());
    }


    public void SetHealthUpgradeDetails(PlayerUpgradeSO playerUpgrade)
    {
        string description = playerUpgrade.maxHealthUpgrade.description;
        string price = $"{playerUpgrade.maxHealthUpgrade.price}";
        SetSlotDetails("health", playerUpgrade.maxHealthUpgrade.title, description, price);
    }

    public void SetWeaponUpgradeDetails(string prefix, Upgrade upgrade)
    {
        if (upgrade.upgradeType == Upgrade.UpgradeType.AmmoCapacity)
        {
            ammoUpgradeSlot.gameObject.SetActive(true);
        }

        string title = upgrade.title;
        string description = upgrade.description;
        string price = $"{upgrade.price}";
        SetSlotDetails(prefix, title, description, price);
    }

    void SetSlotDetails(string prefix, string title, string description, string price)
    {
        uITextGroup.SetText($"{prefix}_title", title);
        uITextGroup.SetText($"{prefix}_description", description);
        uITextGroup.SetText($"{prefix}_price", price);
    }
}
