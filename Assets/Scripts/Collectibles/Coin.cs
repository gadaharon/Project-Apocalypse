using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    public static Action<Coin> OnCoinCollected;
    public int CoinAmount => coinAmount;

    [SerializeField] int coinAmount = 10;
    [SerializeField] ParticleSystem coinFVX;

    public void Collect()
    {
        Destroy(gameObject);
        Instantiate(coinFVX, transform.position, Quaternion.identity);
        OnCoinCollected?.Invoke(this);
    }
}
