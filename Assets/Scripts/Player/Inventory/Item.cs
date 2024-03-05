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
}
