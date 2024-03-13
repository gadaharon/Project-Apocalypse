using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    Dictionary<AmmoSO, int> ammoInventory = new Dictionary<AmmoSO, int>();

    void Awake()
    {
        // Persist this
    }

    public void AddAmmo(AmmoSO ammo, int amount)
    {
        if (!ammoInventory.ContainsKey(ammo))
        {
            ammoInventory[ammo] = 0;
        }
        ammoInventory[ammo] += amount;
    }

    public bool UseAmmo(AmmoSO ammo, int amount)
    {
        if (ammoInventory.ContainsKey(ammo) && ammoInventory[ammo] >= amount)
        {
            ammoInventory[ammo] -= amount;
            return true;
        }
        return false; // incase of empty clip make empty clip sound
    }

    public int GetCurrentAmmoCount(AmmoSO ammo)
    {
        if (ammoInventory.ContainsKey(ammo))
        {
            return ammoInventory[ammo];
        }
        return 0;
    }
}
