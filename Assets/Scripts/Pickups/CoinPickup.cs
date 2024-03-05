using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int coinAmount = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Collect VFX
            // Add to player coins
            Destroy(gameObject);
        }
    }
}
