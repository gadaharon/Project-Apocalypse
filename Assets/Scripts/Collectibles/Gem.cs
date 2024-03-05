using System;
using UnityEngine;

public class Gem : MonoBehaviour, ICollectible
{
    public static Action OnGemCollected;

    [SerializeField] ParticleSystem gemVFX;

    public void Collect()
    {
        Destroy(gameObject);
        Instantiate(gemVFX, transform.position, Quaternion.identity);
        OnGemCollected?.Invoke();
    }
}
