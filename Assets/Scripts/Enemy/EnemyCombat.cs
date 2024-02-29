using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] int damageAmount = 1;
    [SerializeField] float knockBackThrust = 10f;

    KnockBack knockBack;

    void Awake()
    {
        knockBack = GetComponent<KnockBack>();
    }

    void HandleEnemyKnockBack()
    {
        if (knockBack != null)
        {
            Vector3 directionToPlayer = (transform.position - PlayerController.Instance.transform.position).normalized;
            knockBack.GetKnockBack(directionToPlayer, knockBackThrust);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HandleEnemyKnockBack();
            Flash flash = other.GetComponent<Flash>();
            Health health = other.GetComponent<Health>();
            CinemachineImpulseSource impulseSource = other.GetComponent<CinemachineImpulseSource>();
            flash?.StartFlash();
            impulseSource?.GenerateImpulse();
            health?.TakeDamage(damageAmount);
        }
    }
}
