using UnityEngine;

public class ItemSO : ScriptableObject
{
    public enum ItemType
    {
        Weapon,
        MedKit,
        Throwables
    }

    public ItemType itemType;
    public int amount = 1;
}
