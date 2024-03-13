using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Objects/Items/New Weapon", order = 3)]
public class WeaponSO : ItemSO
{
    public enum WeaponType
    {
        Pistol,
        Shotgun,
        Rifle,
        RPG,
    }

    public WeaponType weaponType;
    public float fireRate;
    public AmmoSO ammo;
    public int damage;

    void OnEnable()
    {
        itemType = ItemType.Weapon;
    }
}
