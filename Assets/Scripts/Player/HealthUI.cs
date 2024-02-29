using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Image[] hearts;

    int numberOfHearts = 0;
    Health health;

    void Awake()
    {
        health = GetComponent<Health>();
        numberOfHearts = health.StartingHealth;
    }

    void Start()
    {
        InitPlayerHearts();
    }

    void Update()
    {
        HandleHealthUIStatus();
    }

    void OnEnable()
    {
        health.OnDeath += HandleOnDeath;
    }

    void OnDisable()
    {
        health.OnDeath -= HandleOnDeath;
    }

    void HandleOnDeath(Health sender)
    {
        HandleHealthUIStatus();
    }

    void InitPlayerHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void HandleHealthUIStatus()
    {
        for (int i = 0; i < numberOfHearts; i++)
        {
            if (i < health.CurrentHealth)
            {
                hearts[i].color = Color.white;
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }
}
