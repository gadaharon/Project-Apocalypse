using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;

    Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.left * bulletSpeed;
    }


    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
