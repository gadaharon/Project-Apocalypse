using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip gunSFX;
    [SerializeField] AudioClip shotgunSFX;

    [SerializeField] AudioClip coinPickSFX;
    [SerializeField] AudioClip gemPickSFX;

    Item.ItemType weaponType;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        ShootManager.OnShoot += HandleWeaponAudio;
        WeaponSwitchingManager.OnWeaponSelectChange += SetItemType;
        Coin.OnCoinCollected += HandleCoinAudio;
        Gem.OnGemCollected += HandleGemAudio;
    }

    void OnDisable()
    {
        ShootManager.OnShoot -= HandleWeaponAudio;
        WeaponSwitchingManager.OnWeaponSelectChange -= SetItemType;
        Coin.OnCoinCollected -= HandleCoinAudio;
        Gem.OnGemCollected -= HandleGemAudio;
    }

    void SetItemType(WeaponSwitchingManager weaponSwitchingManager)
    {
        weaponType = weaponSwitchingManager.selectedWeaponGO.ItemType;
    }

    void HandleWeaponAudio()
    {
        switch (weaponType)
        {
            case Item.ItemType.Gun:
            case Item.ItemType.Rifle:
                audioSource.PlayOneShot(gunSFX);
                break;
            case Item.ItemType.Shotgun:
                audioSource.PlayOneShot(shotgunSFX);
                break;
        }
    }

    // TODO move the collectables sound effect to their own scriptable object, so it will be more maintainable and cleaner
    void HandleCoinAudio(Coin coin)
    {
        audioSource.PlayOneShot(coinPickSFX);
    }

    void HandleGemAudio()
    {
        audioSource.PlayOneShot(gemPickSFX);
    }
}
