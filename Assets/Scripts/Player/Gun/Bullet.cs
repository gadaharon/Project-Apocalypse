using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] int damageAmount = 1;

    Gun _gun;
    Vector2 fireDirection;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    void FixedUpdate()
    {
        rb.velocity = fireDirection * bulletSpeed;
    }

    public void Init(Gun gun, Vector2 bulletSpawnPos, Vector2 mousePos)
    {
        _gun = gun;
        transform.position = bulletSpawnPos;
        fireDirection = (mousePos - bulletSpawnPos).normalized;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Flash flash = other.GetComponent<Flash>();
            Health health = other.GetComponent<Health>();
            flash?.StartFlash();
            health?.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
