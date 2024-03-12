using UnityEngine;

[CreateAssetMenu(fileName = "Shop Item", menuName = "Scriptable Objects/Shop Item", order = 2)]
public class ShopItem : ScriptableObject
{
    public Sprite itemSprite;
    public ItemSO shopItem;
    public string title;
    public string description;
    public int price;
}
