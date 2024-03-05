using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    public static Action<Coin> OnCoinCollected;
    public int CoinAmount => coinAmount;

    [SerializeField] int coinAmount = 10;

    public void Collect()
    {
        Destroy(gameObject);
        OnCoinCollected?.Invoke(this);
    }
}
