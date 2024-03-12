using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static Action<Gun> OnShoot;

    public WeaponSO.WeaponType WeaponType => weaponSO.weaponType;
    public int AmmoCapacity => weaponSO.ammoCapacity;
    public int CurrentAmmo => currentAmmo;

    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] Bullet bullet;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] int bulletsNumberPerShoot = 1;
    [SerializeField] float bulletCD = .5f; // fire cool down
    [SerializeField] WeaponSO weaponSO;


    int currentAmmo;
    Vector2 mousePos;
    float lastFireTime = 0f;

    void Awake()
    {
        currentAmmo = weaponSO.ammoCapacity;
    }

    void Update()
    {
        RotateGun();
        Shoot();
    }

    void RotateGun()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = PlayerController.Instance.transform.InverseTransformPoint(mousePos);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time >= lastFireTime)
        {
            // PlayMuzzleFlashVFX();
            OnShoot?.Invoke(this);
            ProcessShooting();
            ResetLastFireTime();
        }
    }

    void ProcessShooting()
    {
        if (currentAmmo > 0)
        {
            if (bulletsNumberPerShoot > 1)
            {
                ShootMultiple();
            }
            else
            {
                ShootProjectile();
            }
        }
        ReduceCurrentAmmo();
    }

    void ReduceCurrentAmmo()
    {
        if (weaponSO.weaponType != WeaponSO.WeaponType.Pistol && currentAmmo > 0)
        {
            currentAmmo -= 1;
        }
    }

    void ShootProjectile()
    {
        Bullet newBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        newBullet.Init(this, (Vector2)bulletSpawnPoint.position, mousePos, weaponSO.damage);
    }

    void ShootMultiple()
    {
        Vector2 direction = (mousePos - (Vector2)bulletSpawnPoint.position).normalized;
        float angleStep = bulletsNumberPerShoot * 2;
        float startAngle = -(bulletsNumberPerShoot - 1) * angleStep / 2;
        float distanceBetweenSpawnPoint = .5f;

        for (int i = 0; i < bulletsNumberPerShoot; i++)
        {
            float currentAngle = startAngle + (i * angleStep);
            Vector2 directionRotation = Quaternion.Euler(0, 0, currentAngle) * direction;
            Vector2 spawnPosition = (Vector2)bulletSpawnPoint.position + directionRotation.normalized * distanceBetweenSpawnPoint;
            Bullet newBullet = Instantiate(bullet, spawnPosition, Quaternion.identity);
            newBullet.Init(this, spawnPosition, spawnPosition + directionRotation, weaponSO.damage);
        }
    }

    void ResetLastFireTime()
    {
        lastFireTime = Time.time + bulletCD;
    }


    // FIXME - Muzzle flash VFX not working when flipping character
    // void PlayMuzzleFlashVFX()
    // {
    //     // muzzleFlashVFX.main.startRotation = Quaternion.Euler(0, 0, angle);
    //     // muzzleFlashVFX.startRotation = angle;
    //     muzzleFlashVFX.Play();
    // }
}
