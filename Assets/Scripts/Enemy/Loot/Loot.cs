using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public GameObject lootPrefab;
    public string lootName;
    public int dropChance;
}
