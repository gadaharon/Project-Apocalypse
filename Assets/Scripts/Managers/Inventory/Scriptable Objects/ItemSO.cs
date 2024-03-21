using UnityEngine;

public class ItemSO : ScriptableObject
{
    public enum ItemType
    {
        Weapon,
        MedKit,
        Throwables,
        Ammunition
    }

    protected virtual void Init()
    {
        // override this
    }

    public string itemId;
    public ItemType itemType;
    public int amount = 1;
}
