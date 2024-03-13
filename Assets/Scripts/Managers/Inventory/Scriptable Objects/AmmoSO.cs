using UnityEngine;

[CreateAssetMenu(fileName = "New Ammunition", menuName = "Scriptable Objects/Items/New Ammunition", order = 5)]
public class AmmoSO : ItemSO
{
    public int maxCapacity;
    void OnEnable()
    {
        itemType = ItemType.Ammunition;
    }
}
