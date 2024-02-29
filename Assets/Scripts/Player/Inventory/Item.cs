

using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Gun,
        Shotgun,
        Rifle,
        RPG,
        Healthkit
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Gun:
                return ItemAssets.Instance.gunSprite;
            case ItemType.Shotgun:
                return ItemAssets.Instance.shotgunSprite;
            case ItemType.Rifle:
                return ItemAssets.Instance.rifleSprite;
        }
    }
}
