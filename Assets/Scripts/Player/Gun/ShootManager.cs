using System;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public static Action OnShoot;

    readonly int SHOOT_ANIMATION = Animator.StringToHash("Shoot");

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        OnShoot += HandleShootAnimation;
    }

    void OnDisable()
    {
        OnShoot -= HandleShootAnimation;
    }

    void HandleShootAnimation()
    {
        animator.Play(SHOOT_ANIMATION, 0, 0f);
    }


}
